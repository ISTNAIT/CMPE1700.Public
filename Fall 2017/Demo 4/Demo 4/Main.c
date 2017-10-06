#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
#include <string.h>

void PrintthoseInts(int vals[], int size)
{
	for (int i = 0; i < size; ++i)
	{
		printf("%d\n", vals[i]);
	}
}

int main(int argc, char * argv[])
{
	srand(time(NULL)); //Initialize a random number generator.

	unsigned int u = 0;
	//Let's see those args
	puts("Arguments:");
	for (int i = 0; i < argc; ++i)
	{
		printf("Argument %d: %s\n", i, argv[i]);
		//Try to convert the arg to a uint.  If it gets
		//a value other than zero, it appears to be a number.
		if ((u = strtoul(argv[i], NULL, 10)) > 0)
		{
			printf("   This appears to be the number %d\n", u);
		}
		//Print out any digits in the arg

		int loc = 0; //Which character am I looking at
		while (argv[i][loc] != 0) //while not at end of string
		{
			if (isdigit(argv[i][loc]))
				printf("I found the digit %c at location %d\n", 
					argv[i][loc], loc);
			loc++;
		}
	}

	//Some strings
	char s1[] = { 'a', 'b', 'c', 0 };
	char s2[] = "abc";
	char notans[] = { 'a', 'b', 'c' };

	puts(s1);
	puts(s2);
	puts(notans);

	int vals[10];
	for (int i = 0; i < 10; ++i)
	{
		vals[i] = rand() % 100;  //random between 0 and 99
	}

	//PrintthoseInts(vals, 10);


	//Here are some hints for doing rotn on  charcters.

	printf("%d\n", 'c' - 'a');
	printf("%d\n", 'a' + 9);
	printf("%c\n", 'a' + 9);

	//this is the really cool one!

	printf("%c\n", 'a' + ('y' - 'a' + 9) % 26);

	// 'y' - 'a' is just the letter number of 'y' (25)
	// (25 + 9) % 26 = 8 (value 34 mod 26)
	// 'a' + 8 gives me letter 8

	return 0;
}