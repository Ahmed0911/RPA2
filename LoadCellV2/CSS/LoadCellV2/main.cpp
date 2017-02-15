/*
 * main.c
 */
#include <stdint.h>
#include <stdbool.h>
#include <string.h>
#include "inc/hw_memmap.h"
#include "inc/hw_types.h"
#include "driverlib/gpio.h"
#include "driverlib/pin_map.h"
#include "driverlib/rom.h"
#include "driverlib/rom_map.h"
#include "driverlib/interrupt.h"
#include "driverlib/sysctl.h"
#include "driverlib/systick.h"
#include "driverlib/uart.h"
#include "driverlib/fpu.h"

#include "Drivers/DBGLed.h"
#include "Drivers/Timer.h"
#include "Drivers/WpnOutputs.h"
#include "Drivers/PWMDrv.h"
#include "Drivers/SerialDriver.h"
#include "Drivers/SBUSComm.h"
#include "Drivers/ADCDrv.h"
#include "Drivers/BaroDrv.h"
#include "Drivers/MPU9250Drv.h"
#include "Drivers/LSM90DDrv.h"
#include "Drivers/UBloxGPS.h"
#include "Drivers/EtherDriver.h"
#include "Drivers/HopeRF.h"
#include "Drivers/IMU.h"
#include "Drivers/EEPROMDrv.h"

#include "CommData.h"
#include "Parameters.h"
#include "LLConverter.h"
#include "LaunchMgr.h"
#include "CRC32.h"
#include "Comm433MHz.h"

uint32_t g_ui32SysClock;

// Drivers
DBGLed dbgLed;
Timer timerLoop;
WpnOutputs wpnOut;

SerialDriver serialU2;
SerialDriver serialU3;
SerialDriver serialU5;
SBUSComm sbusRecv;
ADCDrv adcDrv;
EtherDriver etherDrv;
HopeRF	hopeRF;
LaunchMgr launch;
CRC32 crc;
Comm433MHz comm433MHz;

// Global Data
int MainLoopCounter;
float PerfLoopTimeMS;
float PerfCpuTimeMS;
float PerfCpuTimeMSMAX;

unsigned int ADCValue = 0;

// Systick
#define SysTickFrequency 1000
volatile bool SysTickIntHit = false;

void main(void)
{
	// Enable lazy stacking for interrupt handlers.  This allows floating-point
	FPULazyStackingEnable();

	// Ensure that ext. osc is used!
	SysCtlMOSCConfigSet(SYSCTL_MOSC_HIGHFREQ);

	// set clock
	g_ui32SysClock = SysCtlClockFreqSet((SYSCTL_XTAL_25MHZ | SYSCTL_OSC_MAIN | SYSCTL_USE_PLL | SYSCTL_CFG_VCO_480), 120000000);

	// Init
	dbgLed.Init();
	timerLoop.Init();
	crc.Init();
	adcDrv.Init();
	wpnOut.Init();
	launch.Init();
	serialU5.Init(UART5_BASE, 115200);

	// Systick
	SysTickPeriodSet(g_ui32SysClock/SysTickFrequency);
	SysTickIntEnable();
	SysTickEnable();

	// Master INT Enable
	IntMasterEnable();

	while(1)
	{
		timerLoop.Start(); // start timer
		MainLoopCounter++;

		/////////////////////////////////
		// INPUTS
		/////////////////////////////////
		// ADC + Current Calc
		adcDrv.Update();
		ADCValue = adcDrv.GetValue(ADCBATTCURRENT);

		// read serial data
		BYTE inputBuff[255];
		int dataReceived = serialU5.Read(inputBuff, 255);
		comm433MHz.NewRXPacket(inputBuff, dataReceived);

		/////////////////////////////////
		// OUTPUTS
		/////////////////////////////////
		// Launch Process
		launch.Update();

		// DBG LED
		dbgLed.Set(true);



		// Get CPU Time
		PerfCpuTimeMS = timerLoop.GetUS()/1000.0f;
		if( PerfCpuTimeMS > PerfCpuTimeMSMAX ) PerfCpuTimeMSMAX = PerfCpuTimeMS;
		// wait next
		while(!SysTickIntHit);
		SysTickIntHit = false;
		// Get total loop time
		PerfLoopTimeMS = timerLoop.GetUS()/1000.0f;
	}
}

void ProcessCommand(int cmd, unsigned char* data, int dataSize)
{
    switch( cmd )
    {
        case 0x10: // PING
        {
            // Send Data
            SCommEthData dataToSend;
            dataToSend.LoopCounter = MainLoopCounter;
            dataToSend.ADCValue = ADCValue;
            dataToSend.LaunchStatus1 = launch.WpnState[0];
            dataToSend.LaunchStatus2 = launch.WpnState[1];

            BYTE outputBuff[255];
            int bytesToSend = comm433MHz.GenerateTXPacket(0x20, (BYTE*)&dataToSend, sizeof(dataToSend), outputBuff);
            serialU5.Write(outputBuff, bytesToSend);

            break;
        }

        case 0x30: // Launch codes
        {
            // fill data
            SCommLaunch launchCmd;
            memcpy(&launchCmd, data, dataSize);

            if( launchCmd.Command == 1) launch.Arm(launchCmd.Index, launchCmd.CodeTimer);
            else if( launchCmd.Command == 2  ) launch.Fire(launchCmd.Index, launchCmd.CodeTimer);
            else if( launchCmd.Command == 3  ) launch.Dearm(launchCmd.Index, launchCmd.CodeTimer);

            break;
        }
    }
}

///////////////
// INTERRUPTS
///////////////
extern "C" void UART2IntHandler(void)
{
	serialU2.IntHandler();
}

extern "C" void UART3IntHandler(void)
{
	serialU3.IntHandler();
}

extern "C" void UART5IntHandler(void)
{
	serialU5.IntHandler();
}

extern "C" void IntGPIOA(void)
{
	//lsm90Drv.MotionINTG();
	//lsm90Drv.MotionINTX();
}

extern "C" void IntGPIOH(void)
{
	//lsm90Drv.MotionINTM();
}

extern "C" void IntGPIOK(void)
{
	//mpu9250Drv.MotionINT();
}

extern "C" void IntGPION(void)
{
	hopeRF.IntHandler();
}

extern "C" void SysTickIntHandler(void)
{
	SysTickIntHit = true;
}
