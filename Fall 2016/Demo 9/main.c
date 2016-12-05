#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include "util.h"
#include "list.h"

int main(int argc, char** argv)
{
  srand(time(NULL));
  Node * head = NULL;

  for(int i = 0; i < 10; ++i)
  {
    head = AddToHead(head,i);
  }
  Print(head);
  head=Delete(head,7);
  PrintRecur(head);
  head = Release(head);

  for(int i = 0; i < 10; ++i)
    head = AddToTail(head,i);
  Print(head);
  head = Release(head);

  for(int i=0; i < 10 ; ++i)
    head = Insert(head,rand()%10);
  Print(head);

  for(int i=0; i < 3 ; ++i)
  {
    int kill = rand()%10;
    printf("Deleting %d\n",kill);
    head = Delete(head,kill);
  }
  Print(head);
  head = Release(head);

  return 0;
}
