#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main(int argc, char** argv)
{
	char Set[] = "ABCDEEFG";
	int count = 1;

	for (int i = 0; i < strlen(Set); ++i)
	{
		for (int j = 0; j < strlen(Set); ++j)
		{
			if (j == i) continue;
			for (int k = 0; k < strlen(Set); ++k)
			{
				if (k == i || k == j) continue;
				printf("%d:%c%c%c\n", count++, Set[i], Set[j], Set[k]);
			}
		}
	}
	printf("\n");
	fflush(stdout);

#ifdef _DEBUG
	fflush(stdin); //Make sure there's nothing lurking in the buffer.
	printf("Press Enter to Exit");
	fgetc(stdin);
#endif



	return 0;
}