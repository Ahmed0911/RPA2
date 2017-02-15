/*
 * CommData.h
 *
 *  Created on: Jan 10, 2016
 *      Author: Ivan
 */

#ifndef A2CODE_COMMDATA_H_
#define A2CODE_COMMDATA_H_

struct SCommEthData
{
	unsigned int LoopCounter;

	unsigned int ADCValue;
	unsigned int DataBufferIndex;

	// Launch
	unsigned short LaunchStatus1;
	unsigned short LaunchStatus2;
};

struct SCommLaunch
{
	unsigned char Command;
	unsigned char Index;
	unsigned char _dummy1;
	unsigned char _dummy2;
	unsigned int CodeTimer;
};

// Ethernet packets
// data[0] = 0x42; // magic codes
// data[1] = 0x24; // magic codes
// data[2] = TYPE; // [0x10 - PING, 0x20 - DATA...]
// data[3] = data....
#endif /* A2CODE_COMMDATA_H_ */
