#include <stdio.h>
#include "exam.h"

//Print a value, followed by that
//value as a bit pattern.  Optionally
//(for more marks) add a space between
//nibbles.  DOES NOT PRINT A NEWLINE
void printbits(unsigned char u)
{

  printf("%d: ",u);
  for (int i=0; i < sizeof(u)*8; ++i)
    {
      if(!(i%4)) printf(" ");
      if(u & (0x80>>i))
          printf("1");
      else
          printf("0");
    }
}

//Return the value, left shifted by one
unsigned char lshift(unsigned char u)
{
  return u << 1;
}


//Return the value, right rotated by one
unsigned char rrotate(unsigned char  u)
{
  int lsb = u & 0x1;
  u >>=1;
  u += (unsigned char)(lsb?0x80:0);
  return u;
}

//Print one line of output.  Calls
//the functions above. DOES PRINT A
//NEWLINE.
void printvals(unsigned char u)
{
  printbits(u);
  printf(" LS> ");
  printbits(lshift(u));
  printf(" RR> ");
  printbits(rrotate(u));
  printf("\n");
}
