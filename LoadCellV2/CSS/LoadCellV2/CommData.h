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

struct SCommDownloaderRequest
{
    unsigned int Offset;
    unsigned int Size;
};


#endif /* A2CODE_COMMDATA_H_ */
