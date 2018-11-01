#include "recur.h"
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char** argv)
{
	if (argc < 2) fprintf(stderr, "Need a string there, bud.");
	PrintString(argv[1]);
	printf("\n");
	PrintStringReverse(argv[1]);
	printf("\n");
	if (Palindromep(argv[1]))
		printf("Yep, palindromic");
	printf("\n");
	return EXIT_SUCCESS;
}