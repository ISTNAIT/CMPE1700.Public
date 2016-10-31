#include <stdlib.h>
#include <stdio.h>
#include "enum.h"

int main()
{

  enum booleoid b = bfalse;

  if(b) printf("Truly the value %d is true.\n",b);
  else printf("Verily, the value %d is false.\n", b);

  enum qualities q = strange|sullen|haunted;
  printf("The qualities of q are %d.\n",q);

  printf("Actually, they are: ");
   if( q & tall ) printf ("tall, ");
   if( q & happy ) printf ("happy, ");
   if( q & fussy ) printf ("fussy, ");
   if( q & strange ) printf ("strange, ");
   if( q & sullen ) printf ("sullen, ");
   if( q & haunted ) printf ("haunted, ");
  printf("and nothing else.\n");

  return 0;
}
