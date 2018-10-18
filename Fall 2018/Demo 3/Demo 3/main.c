#define _CRT_SECURE_NO_WARNINGS
#pragma warning(disable:4996)
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <time.h>
#include "dice.h"

typedef unsigned int uint;

int main(int argc, char** argv)
{
	srand((uint)time(NULL));
	char szbuffer[255] = { 0 };

	for (int i = 0; i < 10; ++i)
	{
		Dice d = Roll();
		GetName(d, szbuffer);
		printf("%d - %s\n", GetValue(d), szbuffer);
	}

	fflush(stdout);
	fflush(stdin);
	gets();

	return EXIT_SUCCESS;
}