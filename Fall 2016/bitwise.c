#include "bitwise.h"
#include <stdlib.h>
#include <stdio.h>

//Print the bits in an integer value to console
void PrintBits(unsigned int value)
{
  unsigned int bitcount = 0; //unsigned char = one byte
  unsigned int mask = 0;
  //How many bits in value?
  bitcount = sizeof(value) * 8; //Sizeof returns num bytes
  for (unsigned int i = bitcount; i > 0 ; --i)
  {
    mask = 1 << (i-1);
    //If bit at position of mask is 1, print 1, otherwise 0
    if((value & mask) != 0)
      printf("1");
    else
      printf("0");
  }
  printf("\n");
}

  unsigned int SetN(unsigned int val, unsigned int n)
  {
    return val | (1 << n);
  }

  unsigned int ClearN(unsigned int val, unsigned int n)
  {
      return val & ~(1 << n);
  }

  unsigned int ToggleN(unsigned int val, unsigned int n)
  {
      return val ^ (1 << n);
  }
