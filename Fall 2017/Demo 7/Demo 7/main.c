#include "dice.h"
#include <stdio.h>

int main(int argc, char** argv)
{
	char buffer[256];
	Dice rolls[36];
	int count = 0;
	//Create an array of all possibe rolls
	for(Die d = One; d <= Six; d++)
		for (Die e = One; e <= Six; e++)
		{
			rolls[count].Die1 = d;
			rolls[count++].Die2 = e;
		}
	for (int i = 0; i < 36; ++i)
		printf("%s\n", GetDiceName(rolls[i], buffer));

	fflush(stdout);
	fflush(stdin);
	gets();

	return 0;
}

