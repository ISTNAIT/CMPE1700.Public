#include "Bits.h"

//Print out a value as a series of bits
//To a stream
void FPrintBits(FILE* stream, uint value)
{
	//Iterate from msb (bit 31) to lsb (bit 0)
	for (char b = sizeof(value) * 8 - 1; b >= 0; b--)
		//Use and mask -- result will be 0 (false) iff bit is 0
		fprintf(stream, "%c", (value & (1 << b)) ? '1' : '0');
	fflush(stream);
}

//Print out a value as a series of bits to stdout
void PrintBits(uint value)
{
	FPrintBits(stdout, value);
}

//Print out a value in hex
//To a stream
void FPrintHex(FILE* stream, uint value)
{
	fprintf(stream, "0x%08X\n", value);
	fflush(stream);
}

//Print out a value in hex to stdout
void PrintHex(uint value)
{
	FPrintHex(stdout, value);
}

//As above prefaced with message
void PrintHexMess(uint value, char* message)
{
	printf("%s: ", message);
	PrintHex(value);
}

//NB: YOU ARE TO COMPLETE THE FUNCTION BELOW
//Count how many 1 bits
byte CountSet(uint val)
{
	byte retval = 0; //accumulator
	for (char b = sizeof(val) * 8 - 1; b >= 0; b--) //char for exit state
		if (val & 1 << b) ++retval;  //if set (andmask non-0)
	return retval;
}

//This should work if the function above is correct.
//Count how many 0 bits
byte CountClear(uint val)
{
	return sizeof(val)*8 - CountSet(val);
}

//NB: YOU ARE TO COMPLETE THE FUNCTION BELOW
//Set bit n (bit 0 is lsb)
//Returns the val, modified so bit n is 1
//(If bit n was already 1, it will be unmodified)
uint SetN(uint val, byte n)
{
	return val | 1<<n;
}

//NB: YOU ARE TO COMPLETE THE FUNCTION BELOW
//Clear bit n (bit 0 is lsb)
//Returns the val, modified so bit n is 0
//(If bit n was already 0, it will be unmodified)
uint ClearN(uint val, byte n)
{
	return val & ~(1<<n);
}

//NB: YOU ARE TO COMPLETE THE FUNCTION BELOW
//Toggle bit n (bit 0 is lsb)
//Returns the val, modified so bit n is different
uint ToggleN(uint val, byte n)
{
	return val ^ 1<<n;
}