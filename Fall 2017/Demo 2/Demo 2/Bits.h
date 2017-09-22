#ifndef BITSH
#define BITSH
#pragma once

#include <stdio.h>

typedef unsigned int uint;
typedef unsigned char byte;

//Print out a value as a series of bits
//To a stream
void FPrintBits(FILE* stream, uint value);

//Print out a value as a series of bits to stdout
void PrintBits(uint value);

//Print out a value in hex
//To a stream
void FPrintHex(FILE* stream, uint value);

//Print out a value in hex to stdout
void PrintHex(uint value);

//As above prefaced with message
void PrintHexMess(uint value, char* message);

//Count how many 1 bits
byte CountSet(uint val);

//Count how many 0 bits
byte CountClear(uint val);

//Set bit n (bit 0 is lsb)
uint SetN(uint val, byte n);

//Clear bit n (bit 0 is lsb)
uint ClearN(uint val, byte n);

//Toggle bit n (bit 0 is lsb)
uint ToggleN(uint val, byte n);

#endif