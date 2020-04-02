#pragma once
#ifndef STAQUEH
#define STAQUEH

#include "list.h"
#include "vect.h"
#include <stdio.h>

//Here we are implementing interfaces for:
// 1) StackV - A stack built on top of a vector
// 2) StackL - A stack built on top of a list
// 3) QueueV - A queue built on top of a vector
// 4) QueueL - A queue built on top of a list

//We will be using the same basic list and vector data structures that
//we implemented in previous demos, lightly tweaked so that we can use
//them for the classic stack interfaces (peek, push, pop) and

//Fundamentally, these can all be done with an underlying data
//structure that supports adding and removing elements at either end
//(sometimes called a deque, short for "Double Ended QUEue") as well
//as retrieving the value at the front/top (for Peek functionality).

//Use some typedefs for the sake of keeping names clear:

typedef Vect StackV;
typedef Node * StackL; //Since I will always be handling the StackL as
                       //a pointer, hide the * in the typedef.  Some
                       //consider this bad practice.  YMMV. I'm doing
                       //it here to show you that we can have
                       //identical interfaces for both List-based and
                       //Vector-based implementations.

typedef Vect QueueV;
typedef Node * QueueL;


//My standard interfaces

//Generic error function, mostly for trying to read empty things:

void ErrorOut(char * message);


//Both stacks and queues can support peek (just read the value at the
//top/front, without modifying the data.)

int PeekL(Node * l); //Because of the magic of overloading and typedef,
                 //this will actually be called for both StackL and
                 //QueueL
int PeekV(Vect v); //As above, but for StackV and QueueV


int EmptyL(Node * l); //Returns 0 unless list is empty. Used for checking.
int EmptyV(Vect v); //Returns 0 unless vector is empty. Used for checking.

int SizeL(Node * l); //Returns number of items in list.
int SizeV(Vect v); //Returns number of items in vector.

//Note, because Peek does not modify the data structures, we don't
//have to pass them by address as we do with Pop below.  However,
//sometimes we pass them by address anyway so that we can have the
//same signature for Peek and Pop.  It's a matter of taste.


//Stacks

int PopV(StackV* s); //Remove item from top of stack. Because this method
                  //modifies the stack, we send it by address.
int PopL(StackL* s); //Again, because this method modifies the stack, we
                  //send it by address.  *** NB: Remember that StackL
                  //is already a pointer (List*), so StackL* is
                  //actually List** (pointer-to-pointer-to-int).  This
                  //is called double indirection, and it allows us to
                  //modify a pointer within a function, just as
                  //passing ordinary types by address does.

int PushV(StackV * s, int val); //Add a value to the top of the stack,
                           //return the value (we could just return
                           //void, but it keeps the symmetry between
                           //Push and Pop)
int PushL(StackL * s, int val);


//Queues

int DequeueV(StackV* s); //Remove front item.
int DequeueL(StackL* s); //Because this method modifies the stack, we send it
                  //by address.  *** NB: Remember that StackL is
                  //already a pointer (List*), so StackL* is actually
                  //List** (pointer-to-pointer-to-int).  This is
                  //called double indirection, and it allows us to
                  //modify a pointer within a function, just as
                  //passing ordinary types by address does.

int EnqueueV(StackV * s, int val); //Add a value to the top of the stack,
                           //return the value (we could just return
                           //void, but it keeps the symmetry between
                           //Push and Pop)
int EnqueueL(StackL * s, int val);

#endif
