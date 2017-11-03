#include <stdlib.h>
#include <stdio.h>

#define ARRSIZE 100

int main(int argc, char ** argv)
{

	//Some variables to play with
	int i = 42;
	int j = 43;
	int k = 44;
	double d = 3.14;
	char c = 'a';
	char s[] = "AJ Armstrong";

	//Integer pointers
	int * p = NULL;
	
	//BAD AJ! Do not do this
	p = i;
	// printf("%d\n", *p ); //This throws an exception from the OS

	//This is what you meant:
	p = &i;
	int * q = p; //Point at the same thing that p points.

	printf("p (%p -> %d) points to the same thing as q (%p -> %d)\n", p, *p, q, *q);
	
	//Void pointers are versatile:

	void * v = &i;
	void * w = &d;
	void * u = &s;

	//But, if you want to use them you have to cast them to whatever they point at

	printf("%d, %f, %s\n", *(int *)v, *(double *)w, (char*)u);

	//Why do we care?
	//Because we can just get memory to play with.

	void * a = malloc(ARRSIZE * sizeof(int)); // Gimme 40 bytes!  (Enough for some ints);

	int* x =   a;  //Pointerto pointer.
	for (i = 0; i < ARRSIZE; ++i)
	{
		x[i] = i;
	}

	for (i = 0; i < ARRSIZE; ++i)
	{
		printf("%d, ", x[i]);
	}
	printf("\n");

	//If you take it out, you're responsible for putting it back
	free(a);
	//Null out the pointers so I don't accidentally use that location
	a = NULL;
	x = NULL; 

	//Do the pausy thing.
	fflush(stdout);
	fflush(stdin);
	gets();

	return 0;

}