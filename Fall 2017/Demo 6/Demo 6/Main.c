
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
	char set[] = "ABCDEFG";
	int count = 1;
	for (int i = 0; i < strlen(set); ++i)
		for (int j = i + 1; j < strlen(set); ++j)
			for (int k = j + 1; k < strlen(set); ++k)
				printf("%d:%C%C%C\n", count++, set[i], set[j], set[k]);

	printf("\n");
	fflush(stdout);
	fflush(stdin);
	gets();

	return 0;
}