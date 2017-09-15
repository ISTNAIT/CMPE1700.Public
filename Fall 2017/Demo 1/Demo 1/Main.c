#include <stdio.h> //I want to use printf and stuff
#include "Number.h"


int main(int argc, char** argv)
{
	//Check how many arguments I got
	//Issue an error if I didn't get any explicit
	//There's always 1 free (implicit) one

	if (argc == 1) //Only got implicit arg
	{
		//Generate an error message
		//and exit with error
		//Errors should always go to stderr
		fprintf(stderr, "Error, expected explicit argument.\n");
		fflush(stderr);
		//Press enter to not make debug window go away
#ifdef _DEBUG
		fflush(stdin); //Make sure there's nothing lurking in the buffer.
		printf("Press Enter to Exit");
		fgetc(stdin);
#endif
		return -1;
	}

	//If I got here,  I have some arguments.  Let's print them out.
	for (int i = 0; i < argc; ++i)
	{
		//Could go fprintf(stdout, ..), but that's what printf defaults to
		printf("%d) %s", i, argv[i]);
		printf("\n");
	}
	printf("The answer is %d.\n", Number());
	fflush(stdout);

	//Press enter to not make debug window go away
#ifdef _DEBUG
	fflush(stdin); //Make sure there's nothing lurking in the buffer.
	printf("Press Enter to Exit");
	fgetc(stdin);
#endif

	return 0;
}
