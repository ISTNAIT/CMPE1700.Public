#include "arrays.h"
#include <stdio.h>
#include <stdlib.h>

void printarray(int a[], int count)
{
  //printf("Size of array a in printarray is: %d\n", sizeof(a));

  for (int i=0; i < count; ++i)
    printf("%d ",a[i]);
  printf("\n");
}

void printarrayc(char a[], int count)
{
  for (int i=0; i < count; ++i)
    printf("%c",a[i]);
  printf("\n");
}

void printstring(char sz[])
{
  for (int i=0; sz[i] ; ++i) //Print as long as sz[i] not 0
    printf("%c",sz[i]);
  printf("\n");
}
