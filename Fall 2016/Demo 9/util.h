#ifndef UTILH
#define UTILH
#include "stdlib.h"
#include "stdio.h"
#include "time.h"

typedef unsigned int uint;


//Print out an array of the sort above
void PrintArray(int array[], int size);

//Print an error message to stderr
void PrintError(char * message);

//Print our standard usage message
void PrintUsage();

//Test function that is used to demonstrate how Timefunction works
void CountTo(uint upperlimit);

#endif
