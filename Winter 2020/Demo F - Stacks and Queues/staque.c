#include "staque.h"
#include <stdio.h>
#include <stdlib.h>

void ErrorOut(char * message) //Print an error message and exit.
{
    fprintf(stderr, message);
    fprintf(stderr, "\n");
    exit(EXIT_FAILURE);
}

int EmptyL(Node * l) //Returns 0 unless list is empty. Used for checking.
{
    return l?0:1; //Check if l is a NULL pointer.
}

int EmptyV(Vect v) //Returns 0 unless vector is empty. Used for checking.
{
    return v.size?0:1; //check if vector size > 0.
}

int SizeL(Node * l) //Returns number of items in list.
{
    //My list implementation doesn't have this, but recursion to the
    //rescue;
    if(!l) return 0;
    return 1 + SizeL(l->next);
}

int SizeV(Vect v) //Returns number of items in vector.
{
    //This is already built in to my vector.
    return v.size;
}

//Both stacks and queues can support peek (just read the value at the
//top/front, without modifying the data.)

int PeekL(Node * l) //Called for both StackL and QueueL
{
    if(EmptyL(l))
        ErrorOut("Attempt to peek empty list.");
    return l->value;
}

//For the vector-based stack, we use the BOTTOM of the store
//As the top of the stack, because otherwise we end up having
//to move everything up by one when we pop.
int PeekV(Vect v) //As above, but for StackV and QueueV
{
    if(EmptyV(v)) ErrorOut("Attempt to peek empty store.");
    return v.store[v.size-1];
}

//Stacks


int PopV(StackV * s) //Remove item from "top" of stack (bottom of
                  //list). Because this method modifies the stack, we
                  //send it by address.
{
    if(EmptyV(*s)) ErrorOut("Attempt to pop empty store.");
    //Shrink by 1
    s->size--;
    return s->store[s->size]; //Item we just 'removed' is still valid, so return.
}

int PopL(StackL * s) //Remove item from top of stack. For lists, top is front.
{
    int retval = 0;
    if(EmptyL(*s)) ErrorOut("Attempt to pop empty list.");
    retval = (*s)->value; //Weird star arrow thing is because StackL*
                         //is really List**, so I double dereference to
                         //get to the Value field.
    *s = RemoveAt(*s,0); //Just use my existing 'remove at head' code
    return retval;
}

int PushV(StackV * s, int val) //Add a value to the top of the stack.
{
    //In our implementation, the action is at the end of the vector.
    //So we can just use our standard add.
    Add(s, val, 0);
    return val;
}

int PushL(StackL * s, int val) //Add a value to the top of the stack.
{
    //I already have insert-at-head code, so...
    *s = AddAt(*s , val, 0);
    return val;
}
//Queues

int DequeueV(StackV * s) //Remove front item.
{
    //This is pretty easy.  We're going to map Dequeue to Pop.
    return PopV(s);
}

int DequeueL(StackL * s) //Remove front item.
{
    //This is pretty easy.  We're going to map Dequeue to Pop.
    return PopL(s);
}


int EnqueueV(StackV * s, int val) //Add a value to the back of the queue.
{
    //Like push, but at the opposite end. In the case of our vector,
    //This means I have to slide the entire set down by one.
    //First, create a new entry at the bottom to make sure I have
    //space. Just add a 0, because it's going to get overwritten
    Add(s, 0, 0);
    //Now slide everything forward
    for(int i = s->size-1 ; i > 0; --i)
        s->store[i] = s->store[i-1];
    //Add our new value at the top
    s->store[0] = val;
    return val;
}

int EnqueueL(StackL * s, int val) //Add a value to the back of the queue.
{
    //Like push, but at the opposite end.
    //I already have insert-at-tail code, so...
    *s = AddAt(*s , val, -1);
    return val;
}
