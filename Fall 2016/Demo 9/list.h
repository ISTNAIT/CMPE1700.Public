#ifndef LISTH
#define LISTH
typedef unsigned int uint;

//Our list container
typedef struct node
{
  int value;
  struct node * next;
} Node;

//Add a value to end of list
Node * AddToTail(Node * head, int value);

//Add a value to head of list
Node * AddToHead(Node * head, int value);

//Insert a value (sorted - inserts before first node > value).
Node * Insert(Node * head, int value);

//Delete first node of value
Node * Delete(Node * head, int value);

//Sort the list contents, ascending
Node * Sort(Node * head);

//Print the List, Iterative
void Print(Node * head);

//Print the List, Recursive
void PrintRecur(Node * head);

//Release the stored memory in a list
Node * Release(Node * head);

#endif
