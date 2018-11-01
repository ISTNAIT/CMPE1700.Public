#include "recur.h"
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include <ctype.h>

//Recursively Print a String
void PrintString(char * sz)
{
	//Base case
	if (sz == NULL) return;
	if (*sz == 0) return; //Exactly the same as sz[0]
	printf("%c", *sz);
	PrintString(sz + 1); //Call for string starting at next char.
}

//Recursively Print a String Backwards
void PrintStringReverse(char * sz)
{
	//Base case
	if (sz == NULL) return;
	if (*sz == 0) return; //Exactly the same as sz[0]
	PrintStringReverse(sz + 1); //Call for string starting at next char.
	printf("%c", *sz);
}

//Make all characters lower-case
void FlattenString(char * sz)
{
	while (sz && sz[0])
	{
		*sz = tolower(*sz);
		sz++;
	}
}

//Get rid of non-alpha characters and whitespace
void SqueezeString(char * sz)
{
	if (!sz) return; //No string

	char* curr = sz; //Character I'm looking at
	char* insertpoint = sz; //Next character to be written
	while (*curr)
	{
		if (isalpha(*curr))
		{
			*insertpoint = *curr;
			insertpoint++;
			curr++;
		}
		else
		{
			curr++;
		}
	}
	*insertpoint = 0; //Terminate string
}

//Is this thing a palindrome? Recursive.
int Palindromep(char* sz)
{
	//Base case
	if (sz == NULL) return 1;
	if (strlen(sz) < 2) return 1;
	//Make my string a set of lowercase letters.
	FlattenString(sz);
	SqueezeString(sz);
	//Iterative case
	//I need my last character
	if (sz[0] == sz[strlen(sz) - 1]) //First and last match
	{
		sz[strlen(sz) - 1] = 0;
		return Palindromep(sz + 1);
	}
	return 0;
}
