#ifndef LLH
#define LLH
#pragma once

//Forward declaration so that "Node *" makes sense
struct node;

typedef struct node
{   int val;
    struct node * next;
}Node;

//Add an item to end of List.
Node * Add(Node * head, int val);

//Insert an item that will be after node at loc.
Node * InsertAfter(Node * loc, int val);

//Insert an item before the first item greater than
//its value
Node * InsertInOrder(Node * head, int val);

#endif
