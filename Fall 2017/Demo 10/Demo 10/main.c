#include "dice.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int main(int argc, char** argv)
{
	char buffer[256];
	Dice rolls[36];
	int count = 0;
	//Seed rand
	srand((unsigned int)time(NULL));
	//Create an array of all possibe rolls
	for(Die d = One; d <= Six; d++)
		for (Die e = One; e <= Six; e++)
		{
			rolls[count].Die1 = rand()%6 + 1;
			rolls[count++].Die2 = rand()%6 + 1;
		}
	
	printf("Random\n------\n");
	for (int i = 0; i < 36; ++i)
		printf("%s\n", GetDiceName(rolls[i], buffer));

	SortDice(rolls, 36);

	printf("Sorted\n------\n");
	for (int i = 0; i < 36; ++i)
		printf("%s\n", GetDiceName(rolls[i], buffer));

	fflush(stdout);
	fflush(stdin);
	gets();

	return 0;
}

