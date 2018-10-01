#define _CRT_SECURE_NO_WARNINGS

//Main should only have your main function
#include <stdlib.h> //System library
#include <stdio.h>
#include "Complex.h" //Literal path
#include "Complex.h"

//Declaration(syntax note)
void SayHi(int); //function without a body

//Main
int main(int argc, char ** argv)
{
	SayHi(10);

	Compl thing = { 3,4 };
	Compl thang;
	thang.real = 3;
	thang.imag = 4;
	char buffer[255] = "";

	sprintf(buffer, "%f , %f", thang.real,thang.imag);
	printf(buffer);

	sprintf(buffer, "%f , %f, %f", magnitude(thang),conjugate(thang).real,
		conjugate(thang).imag);
	printf(buffer);
	return EXIT_SUCCESS;
}

//Definition
void SayHi(int count)
{
	for(int i = 0; i < count; ++i)
	printf("Hi");
}