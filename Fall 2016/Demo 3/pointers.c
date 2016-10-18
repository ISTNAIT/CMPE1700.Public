#include <stdlib.h>
#include <stdio.h>
#include "pointers.h"

//Very, very verbose version of
/*
int * MakeArray(size_t size)
{
  return (int *) malloc (size * sizeof(int));
}
*/

int * MakeArray(size_t size)
{
  void * v = 0;
  v = malloc(size * sizeof(int)); //Need this much for an array of that many int
  if (v)
  return (int *) v;
  else
    return 0;
}

void InitializeArray(int * a, size_t size)
{
  //Do it without pointer arithmetic, if you're a small, small person.
  for (int i = 0; i < size; ++i)
    a[i] = rand() % size; //Value between 0 and size-1
}

//Fun fact:  a[i] and *(a+i) are EXACTLY the same thing
void PrintArray(int * a, size_t size)
{
  //Pointer arithmetic is for the mighty!
  printf("---------------------------------------------\n");
  for (int i = 0; i < size; ++i)
    printf("%d ", *(a+i)); // a+i is the integer i places after the one at a
  printf("---------------------------------------------\n");
}
