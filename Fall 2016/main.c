#include <stdlib.h>
#include <stdio.h>
#include "bitwise.h"

int main()
{
  unsigned int val = 27;
  PrintBits(val);
  //Set bit 5
  val = SetN(val,5);
  PrintBits(val);
  //Clear bit 5
  val = ClearN(val,5);
  PrintBits(val);
  //Toggle bit 5
  val = ToggleN(val,5);
  PrintBits(val);

//Toggle alternating bits
PrintBits(val ^ 0x55555555);

  return 0;
}
