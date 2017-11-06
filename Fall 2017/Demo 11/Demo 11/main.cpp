/***************************************
*  Simple demo of pointers, pass-by
*  value, and DMA
****************************************/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int pbv(int x)
{
	++x;
	return x;
}

int pba(int * p)
{
	++(*p);
	return *p;
}

void printarray(int * a, int size)
{
	//Fun with pointer arithmetic
	int * p = a; //Pointer to the first element
	while (p - a < size)  //Difference is the number of ints between p and a
		printf("%d ", *(p++)); //print current value of p, then increment to next

	printf("\n");

	//We can also just treat our pointer as an array
	for (int i = 0; i < size; ++i)
		printf("%d ", a[i]);

	printf("\n");

}

//Get a random array of int of arbitrary size
//***NB: RETURNS DMA'D MEMORY.  YOU MUST 
//REMEMBER TO FREE THE POINTER YOU GET BACK.

int * GetMeSomeInts(int size)
{
	int * p = (int *)malloc(sizeof(int) * size);
	for (int i = 0; i < size; ++i)
		p[i] = rand() % size;
	return p;
}


int main(int argc, char** argv)
{
	int x = 0;
	int retval = 0;

	srand(time((unsigned int) NULL));

	retval = pbv(x);
	printf("PBV: Return value->%d, value of x->%d\n", retval, x);
	retval = pba(&x);
	printf("PBA: Return value->%d, value of x->%d\n", retval, x);


	//Let's get an array from the heap!
	//Remember malloc just gives me a certain number of bytes.
	//void * must be cast to the type of interst.  Sizeof is
	//your friend (don't assume you know how big things are).

	int * a = (int *) malloc(sizeof(int) * 10);
	for (int i = 0; i < 10; ++i)
		//Fill it with random!
		a[i] = rand() % 100;
	printarray(a, 10); 

	int * stuff = GetMeSomeInts(1000);
	printarray(stuff, 1000);
	free(stuff);

	free(a);
	a = NULL;

	fflush(stdout);
	//Press enter to not make debug window go away
#ifdef _DEBUG
	fflush(stdin); //Make sure there's nothing lurking in the buffer.
	printf("Press Enter to Exit");
	fgetc(stdin);
#endif
}