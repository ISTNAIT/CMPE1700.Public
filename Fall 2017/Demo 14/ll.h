#ifndef LLH
#define LLH
#pragma once

//Forward declaration so that "Node *" makes sense
struct node;

typedef struct node
{   int val;
    struct node * next;
}Node;

//Sort list in ascending order using insertion sort
Node * SortList(Node * head);

void PrintList(Node * head);

Node * DeleteList(Node * head);

//Add an item to the front of the list
Node * AddNodeToHead(Node * head, int val);

//Add an item to end of List.
Node * AddNodeToTail(Node * head, int val);

//Insert an item that will be after node at loc.
Node * InsertNodeAfter(Node * loc, int val);

//Insert an item before the first item greater than
//its value
Node * InsertNodeInOrder(Node * head, int val);

//Find last node
Node * FindUltimateNode(Node * head);

//Find second last node
Node * FindPenultimateNode(Node * head);

//Reverse List (no copying)
Node * ReverseList(Node * head);

//Queue behaviour (using add, above)
Node * RemoveNode (Node * head, int * pval);

//Stack behaviour (wrapper for AddToHead)
Node * PushNode(Node * head, int val);

//Stack behaviour
int PeekNode(Node * head);

//Stack behaviour
Node * PopNode (Node * head, int * pval);

#endif
