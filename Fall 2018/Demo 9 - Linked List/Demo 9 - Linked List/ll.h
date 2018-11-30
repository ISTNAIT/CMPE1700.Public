#pragma once
#ifndef _LLH_
#define _LLH_

//Note, depending on how C compliant your compiler is (VS is not very)
//You may need to predeclare (forward declare) the node type before you can have a pointer
//to it in its own definition.
struct node;

struct node 
{
	int value;
    struct node * next;
};

//I hate typing struct so much in C
typedef struct node Node;

Node * AddToHead(Node * head, int val);
Node * AddToTail(Node * head, int val);
Node * AddInOrder(Node * head, int val);
Node * CleanUp(Node * head);
void PrintList(Node * head);

#endif