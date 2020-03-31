#include "staque.h"
#include <stdio.h>
#include <stdlib.h>

//Both stacks and queues can support peek (just read the value at the
//top/front, without modifying the data.)

int Peek(List * l); //Called for both StackL and QueueL
int Peek(Vect v); //As above, but for StackV and QueueV


int Empty(List * l); //Returns 0 unless list is empty. Used for checking.
int Empty(Vect v); //Returns 0 unless vector is empty. Used for checking.

int Size(List * l); //Returns number of items in list.
int Size(Vect v); //Returns number of items in vector.

//Stacks

int Pop(StackV* s); //Remove item from top of stack. Because this method
                  //modifies the stack, we send it by address.
Z Pop(StackL* s); //Remove item from top of stack. Because this method

int Push(StackV * s, int val); //Add a value to the top of the stack.
int Push(StackL * s, int val); //Add a value to the top of the stack.


//Queues

int Dequeue(StackV* s); //Remove front item.
Z Dequeue(StackL* s); //Remove front item.
int Enqueue(StackV * s, int val); //Add a value to the back of the queue.
int Enqueue(StackL * s, int val); //Add a value to the back of the queue.
