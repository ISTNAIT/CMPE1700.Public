#include <stdlib.h>
#include <stdio.h>

#define STRINGSIZE 10
typedef unsigned int uint;
int main()
{
  //variables
  int a;
  uint c;
  float d;
  double e;
  char k;
  char s[STRINGSIZE];

  //Get some values from user
  printf("Gimme a number:");
  scanf("%d", &a);
  printf("%d is a stupid number.\n",a);

  printf("Gimme a number with whitespace:");
  scanf(" %d", &a);
  printf("%d is a lovely number.\n",a);

  printf("Gimme a couple of numbers:");
  scanf(" %d %d", &a, &c);
  printf("Those add up to %d.\n", (uint)a + c);

  printf("How many molecules are in your body (in moles)?");
  scanf("%f",&d);
  printf("Dude.  Go on a diet. %8.2f is waaaay too many.\n", d);

  printf("What's your first initial?");
  fpurge(stdin);
  scanf("%c",&k);
  printf("%c? What the heck?\n", k);

  printf("What is your name?");
  fpurge(stdin);
  scanf("%10s",&s);
  printf("Sod off, %s\n",s);


  return 0;
}
