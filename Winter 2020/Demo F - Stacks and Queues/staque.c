#include "staque.h"
#include <stdio.h>
#include <stdlib.h>

void ErrorOut(char * message) //Print an error message and exit.
{
    fprintf(stderr, message);
    fprintf(stderr, "\n");
    exit(EXIT_FAILURE);
}

int Empty(List * l) //Returns 0 unless list is empty. Used for checking.
{
    return l?1:0; //Check if l is a NULL pointer.
}

int Empty(Vect v) //Returns 0 unless vector is empty. Used for checking.
{
    return v.size?1:0; //check if vector size > 0.
}

int Size(List * l) //Returns number of items in list.
{
    //My list implementation doesn't have this, but recursion to the
    //rescue;
    if(!l) return 0;
    return 1 + Size(l->Next);
}

int Size(Vect v) //Returns number of items in vector.
{
    //This is already built in to my vector.
    return v.Size;
}

//Both stacks and queues can support peek (just read the value at the
//top/front, without modifying the data.)

int Peek(List * l) //Called for both StackL and QueueL
{
    if(!Empty(l)) return l->value;
    else ErrorOut("Attempt to peek empty list.");
}

//For the vector-based stack, we use the BOTTOM of the store
//As the top of the stack, because otherwise we end up having
//to move everything up by one when we pop.
int Peek(Vect v) //As above, but for StackV and QueueV
{
    if(!Empty(v)) return v.store[size-1];
    else ErrorOut("Attempt to peek empty store.");
}

//Stacks


int Pop(StackV * s) //Remove item from "top" of stack (bottom of
                  //list). Because this method modifies the stack, we
                  //send it by address.
{
    if(Empty(*s)) ErrorOut("Attempt to pop empty store.");
    //Shrink by 1
    s->size--;
    return s->store[size]; //Item we just 'removed' is still valid, so return.
}

int Pop(StackL * s) //Remove item from top of stack. For lists, top is front.
{
    int retval = 0;
    if(Empty(*s)) ErrorOut("Attempt to pop empty list.");
    retval = (*s)->Value; //Weird star arrow thing is because StackL*
                         //is really List**, so I double dereference to
                         //get to the Value field.
    *s = RemoveAt(*s,0); //Just use my existing 'remove at head' code
    return retval;
}

int Push(StackV * s, int val) //Add a value to the top of the stack.
{
    //In our implementation, the action is at the end of the vector.
    //So we can just use our standard add.
    Add(s, val, 0);
    return val;
}

int Push(StackL * s, int val) //Add a value to the top of the stack.
{
    //I already have insert-at-head code, so...
    *s = AddAt(*s , val, 0);
    return val;
}
//Queues

int Dequeue(StackV * s); //Remove front item.


Z Dequeue(StackL * s); //Remove front item.


int Enqueue(StackV * s, int val); //Add a value to the back of the queue.


int Enqueue(StackL * s, int val); //Add a value to the back of the queue.
