//#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
//#include <crtdbg.h>
#include <stdio.h>
#include <time.h>
#include "dma.h"

int main(int argc, char** argv)
{
	//Seed RNG
	//srand((int)time(NULL));

	//Grab an int
	int * pi = (int *)malloc(sizeof (int));
	if (!pi) //DMA Failure
	{
		fprintf(stderr,
			"Memory allocation failure. Your computer is borked.");
		exit(EXIT_FAILURE);
	}
	//*** Remember to dereference(*) to access the memory!
	*pi = 42;

	//Another handle to the same memory:
	int* pb = pi; //Note: no dereference - sharing location, not value

	pi = NULL; //Cut the balloon string.

	//Print our value
	printf("%d\n", *pb);// Note the dereference * again. 

	//Put our toys away

	//free(pb);
	pb = NULL;
	//_CrtDumpMemoryLeaks();
	return EXIT_SUCCESS;
}