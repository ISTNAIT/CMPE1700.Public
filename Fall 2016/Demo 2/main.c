#include <stdlib.h>
#include <stdio.h>
#include <time.h> /* For time() Function */
#include "arrays.h"

int main()
{
  //Some variables
  int a[10] = {0}; //Array of 10 integers
  char c[]={'A','J','A',0};
  //Seed the random number generator (do only once!)
  srand(time(NULL));

  //size of array/size of member = number of elements
  for (int i = 0; i < (sizeof(a)/sizeof(int)) ; ++i)
    a[i] = rand() % 100; //Random number from 0 - 99

  //printf("Size of array a in main is: %d\n", sizeof(a));

  printarray(a,10);

  
  printarrayc(c,10);
  printstring("AJA");

  return 0;
}
