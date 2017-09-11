#include <stdlib.h>
#include <stdio.h>

int main(int argc, char** argv)
{
	int n = 0;
	//Check that I got an argument
	if (argc != 2)
	{
		fprintf(stderr, "I need an argument.");
		return -1;
	}

	//Set n to be my argument
	n = atoi(argv[1]); //convert argument 1 to an integer (it's a string now).

	printf("Argument: %d\n", n);

	for (int i = 0; i < n; ++i)
	{
		for (int j = i + 1; j > 0; --j)
			printf("*");
		printf("\n");
		fflush(stdout);
	}

	//Pause display only while debugging
#ifdef _DEBUG
	fflush(stdin); //Make sure there's nothing lurking in the buffer.
	printf("Press Enter to Exit");
	fgetc(stdin);
#endif
	return 0;
}