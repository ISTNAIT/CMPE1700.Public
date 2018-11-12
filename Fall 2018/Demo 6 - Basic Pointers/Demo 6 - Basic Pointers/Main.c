#include <stdlib.h>
#include <stdio.h>

void foo(int i)
{
	int x = 42;
	int * p = &x;
	int ** pp = &p;

	printf("\n%s%s%s%s\n", "Variable  ", "Value     ", "Locat    ", "Derefs    ");
	printf("%s%s%s%s\n",   "========  ", "========  ", "=======  ", "========  ");
	printf("%s%-10d%-10p%s\n", "x         ", x, &x, "N/A");
	printf("%s%-10p%-10p%-10d\n", "p         ", p, &p, *p);
	printf("%s%-10p%-10p%-10p\n", "pp        ", pp, &pp, *pp);

	if (i) foo(--i);
}

int main(int argc, char** argv)
{
	char ** a = argv;

	//NB: Must NULL check! I don't necessarily know if
	// argv actually points to an array.  It could also be
	//NULL (for pointers, that's 0).
	//Trivia:  NULL is usually defined (void *) 0.  void * is the
	//special pointer that can point to anything, but can never
	//be dereferenced.  (More later).

	char * a0 = argv ? *argv : NULL;

	//AJ's obfuscated code demo!  This prints the argv strings.
	while (a < argv + argc)
	{
		a0 = *a++;
		if (a0 && *a0) do printf("%c", *(a0++)); while (*a0);
		printf("\n");
	}

	//is the same as

	for (int i = 0; i < argc; ++i)
		printf("%s\n", argv[i]);

	foo(5);

	return EXIT_SUCCESS;
 }