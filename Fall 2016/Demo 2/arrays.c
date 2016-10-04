#include "arrays.h"
#include <stdio.h>
#include <stdlib.h>

void printarray(int[] a, int count)
{
  for (int i=0; i < count; ++i)
    printf("%d ",a[i]);
  printf("\n");
}
