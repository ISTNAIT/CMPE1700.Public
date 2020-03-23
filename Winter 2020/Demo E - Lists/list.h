#pragma once
#ifndef LISTH
#define LISTH

#include <stdio.h>

//Our main type will be the node, which contains data (in this case,
//an int), and pointer to node.

//Forward declare my structure name. The first Vect is part of the
//official typename (struct Node), the second is the typedef alias
//I.e, this typedef uses "Node" as an alias for "struct Node"
//THis is particularly important, because in order to declare a
//pointer to Node (Node *) inside the definition, the compiler
//needs to have seen this Forward Declaration.

typedef struct Node Node;

//Now define my Vect structure. Note that the Node type will serve as
//the container for a list node and the Node * type as the pointer to
//a node --- and, of course and pointer to a node is also a pointer to
//the list it is the head of, an important symmetry for our algorithms.

struct Node //List node of int
{
    int value; //Data contained in node
    int * next; //Pointer to the next node, NULL means end of list
}; //Don't forget the semi at the end of struct definitions.

//Below are the API functions for my list type.
//In general, unless otherwise specified, method returning Node * will
//return the head of the modified (or not) list.

//Add in order (insert in front of first value > val).
Node* Add(Node * head, int val);

//Add to location n means node will be nth.
//0 means add in front of head
//n > length of the list means add at end
//n < 0 we will interpret as 'add at end'
Node* AddAt(Node * head, int val, int loc);

//Returns a pointer to the first node with value, or NULL
Node* Find(Node * head, int val);

//Delete the node at loc.  Interpret loc as above, except
//attempt to delete node after end of list will be ignored.
Node* RemoveAt(Node * Head, int val, int loc);

//Recursive traversal print
void  Print (Node * head);

//Recursive traversal free memory
void  Free(Node * head);

#endif
