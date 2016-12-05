#include "list.h"
#include "util.h"
#include <stdio.h>
#include <stdlib.h>
//Add a value to end of list
Node * AddToTail(Node * head, int value)
{
  Node * new = malloc(sizeof(Node));
  if(!new)
  {
    PrintError("Error Allocating Node.  Unrecover.  Dying....<Gack>");
    exit(-1);
  }
  new->value = value;
  new->next = NULL;

  if(!head)
  return new;

  Node * current = head;

  while(current->next)
  current = current->next;

  current->next = new;
  return head;
}

//Add a value to head of list
Node * AddToHead(Node * head, int value)
{
  //Replacing the head of my list.
  //1. Create a new node
  Node * new = malloc(sizeof(Node));
  if(!new)
  {
    PrintError("Error Allocating Node.  Unrecover.  Dying....<Gack>");
    exit(-1);
  }
  new->value = value;
  new->next = head;
  //Return new head
  return new;
}

//Insert a value (sorted - inserts before first node > value).
Node * Insert(Node * head, int value)
{
  //Special case: I neead to insert in front of the current
  //head
  if(head && value < head->value)
  return AddToHead(head,value);

  Node * new = malloc(sizeof(Node));
  if(!new)
  {
    PrintError("Error Allocating Node.  Unrecover.  Dying....<Gack>");
    exit(-1);
  }
  new->value = value;
  new->next = NULL;

  if(!head)
  return new;

  //Find insertion point
  Node * current = head;
  while(current->next && current->next->value < value)
  current=current->next;

  //Insert
  new->next = current->next;
  current->next = new;

  return head;
}

//Delete first node of value
Node * Delete(Node * head, int value)
{
  //Find the item.
  //Special case 1: no list
  if(!head) return head;

  //Special case 2:delete head
  if(head->value == value)
  {
    Node * second = head->next;
    free(head);
    return second;
  }

  //Go to node in front of node to be deleted
  Node * current = head;
  while(current->next && current->next->value != value)
    current=current->next;

  if(current->next)
  {
    //Delete it
    Node * doomed = current->next; //Grab a handle
    current->next = current->next->next; //Cut current->next out
    free(doomed); //DIE!!
  }

  return head;
}

//Sort the list contents, ascending
//Your problem, ha, ha.
//Rules:  NO REBUILDING THE LIST WITH MY INSERT!
//Must sort by re-arranging the existing nodes (no making any new nodes)
//Google "Insertion Sort"
Node * Sort(Node * head)
{
  return head;
}

//Print the List, Iterative
void Print(Node * head)
{
  while(head)
  {
    printf("%d->",head->value);
    head = head->next;
  }
  printf("\n");
}

//Print the List, Recursive
void PrintRecur(Node * head)
{
    if(!head)
    {
      printf("\n");
      return;
    }
    printf("%d->",head->value);
    PrintRecur(head->next);
}

//Release the stored memory in a list
Node * Release(Node * head)
{
  while(head)
  {
    Node * doomed = head;
    head = head->next;
    free(doomed);
  }
  return head;
}
