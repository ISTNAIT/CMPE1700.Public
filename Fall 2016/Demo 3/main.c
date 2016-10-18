#include <stdlib.h>
#include <stdio.h>
#include <time.h> /* For time() Function */
#include "pointers.h"

#define ARRAYSIZE 1000

int main()
{
  //Some variables

  //Seed the random number generator (do only once!)
  srand(time(NULL));

  int * p = 0; //Pointer to DMA'd int
  p = (int *) malloc(sizeof(int));
  if(!p)
  {
    printf ("Memory Allocation Error.  Your computer sucks.");
    return -1;
  }
  //If I got here, I got memory
  *p = 42;
  printf("The answer to life, the universe and everything is %d\n",*p);

  //Give my memory back
  if (p) free(p);
  p = 0;

  //You can reuse pointers if you're cool (and careful!)
  //A pointer to int can point to an int, or an array of ints
  p = MakeArray(ARRAYSIZE);
  printf("Uninitialized array:\n");
  PrintArray(p,ARRAYSIZE);
  InitializeArray(p,ARRAYSIZE);
  printf("Initialized array:\n");
  PrintArray(p,ARRAYSIZE);

  //Put away your toys!
  if (p) free(p); //Free don't care how big it is.
  p = 0;

  return 0;
}
