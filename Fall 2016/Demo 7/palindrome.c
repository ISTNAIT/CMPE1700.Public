#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <ctype.h>

char * clean(char * str) //Remove whitespace, punct, convert to lowercase
{
  int curr = 0; //Index of current writing point
  for(int i = 0; i < strlen(str); ++i)
  {
    if(isalnum(str[i]))
     {
       str[curr] = tolower(str[i]);
       curr++;
     }
  }
  str[curr] = '\0';
  return str;
}

int palindromer(char * str, int first, int length)
{
  //Base cases
  if(length < 2) //Length 0 or 1
    return 1;
  if(str[first] == str[first + (length - 1)]) //Inductive case
    return palindromer(str,first + 1, length - 2);
  return 0;
}

//Palindrome?  0 means nope.
int palindrome(char * str)
{
  return palindromer(str, 0, strlen(str));
}


int main(int argc, char** argv)
{
  if(argc != 2)
  {
    fprintf(stderr,"Dude.  I need a string command line arg.");
    return -1;
  }

  if (palindrome(clean(argv[1])))
    printf("Palindrome\n");
  else
    printf("Not a Palindrome\n");
  return 0;
}
