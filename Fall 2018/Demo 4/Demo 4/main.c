#include <stdio.h>
#include <stdlib.h>
#define _CRT_SECURE_NO_WARNINGS
#pragma warning(disable:4996)

typedef unsigned int uint;

int main(int arg, char** argv)
{
	char set[] = "ABCDEFG";
	int size = sizeof(set) / sizeof(set[0]); //iuncluding null
	size = size - 1;  //ignore null

	//Every permutation of three
	int i, j, k;
	for (i = 0,j=0,k=0; i < size; i++)
		for (j = 0; j < size; j++)
			for (k = 0; k < size; k++)
				printf("%c%c%c ", set[i], set[j], set[k]);
	printf("\n\n\n");

	//Every Combination, no replacement
	for(i = 0; i< size ; ++i )
		for(j = i+1 ; j < size; ++j)
			for(k = j+1 ; k < size; ++k)
				printf("%c%c%c ", set[i], set[j], set[k]);
	printf("\n\n\n");
	
	//Every permutation of three

	for (i = 0, j = 0, k = 0; i < size; i++)
	{
		for (j = 0; j < size; j++)
		{
			if (j == i) continue; //Go to next iteration of loop
			//This skips any duplicates of ther first in the second
			for (k = 0; k < size; k++)
			{
				if (k == i || k == j) continue;
				printf("%c%c%c ", set[i], set[j], set[k]);
			}
		}
	}
	printf("\n\n\n");

	fflush(stdin);
	fscanf(stdin,"\n");
}
