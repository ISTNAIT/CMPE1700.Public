#include "Bits.h"
#include <stdio.h>

typedef unsigned int uint;
typedef unsigned char byte;

int main(int argc, char** argv)
{

	uint test = 0xDEADBEEF;
	PrintHexMess(test, "Just testing");

	//
	PrintHexMess(test & ~(0xFFFF0000), "Clear the first four nibbles");

	//
	PrintHexMess(test ^ 0x55555555, "Toggle alternating bits");

	//
	PrintHexMess(test ^ 0xAAAAAAAA, "Same thing, but the other bits.");

	//
	PrintHexMess(test | 0x80000001, "Set high and low bits");

	//
	PrintHexMess(test & ~0x80000001, "Good job.  Maybe clear them?");

	//Print out individual nibbles
	for (int i = 7; i >= 0; --i)
	{
		printf("%X\n", (test & (0xF << 4 * i)) >> 4*i);
	}

	//Pause display only while debugging
#ifdef _DEBUG
	fflush(stdin); //Make sure there's nothing lurking in the buffer.
	//printf("-------------------------------------------------------\n");
	//printf("If you got here, your program meets expectations.  Yay!\n");
	//printf("-------------------------------------------------------\n");
	printf("             Press Enter to Exit:");
	fgetc(stdin);
#endif


	return 0;
}
