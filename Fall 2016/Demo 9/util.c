#include "util.h"
#define ANSI_COLOR_RED     "\x1b[31m"
#define ANSI_COLOR_GREEN   "\x1b[32m"
#define ANSI_COLOR_YELLOW  "\x1b[33m"
#define ANSI_COLOR_BLUE    "\x1b[34m"
#define ANSI_COLOR_MAGENTA "\x1b[35m"
#define ANSI_COLOR_CYAN    "\x1b[36m"
#define ANSI_COLOR_RESET   "\x1b[0m"

//Print out an array of int
void PrintArray(int array[], int size)
{
  for (int i=0; i < size; ++i)
    printf("%d ",array[i]);
  printf("\n");
}

//Print an error message to stderr
void PrintError(char * message)
{
  fprintf(stderr,ANSI_COLOR_RED "Error:" ANSI_COLOR_RESET);
  fprintf(stderr,"%s",message);
  fprintf(stderr,"\n");
}

//Print our standard usage message
void PrintUsage(char * appname)
{
  printf(ANSI_COLOR_BLUE "Usage:" ANSI_COLOR_RESET);
  printf("%s <n>",appname);
  //TODO:  Change this message to reflect your program
  printf(" - appropriate message about how to use this program.\n");
}
