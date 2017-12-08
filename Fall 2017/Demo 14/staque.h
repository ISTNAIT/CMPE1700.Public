#ifndef STAQUEH
#define STAQUEH
#pragma once

//How big should our first vector be?
#define INITSTAQUESIZE 10

typedef struct staque
{
    int * store; //Link to dma'd store
    int top; //index of first useful item (-1 for none)
    int bottom; //index one after last useful item (0 for none)
    int max; //Maximum number of elements in store (bottom < max)
}Staque;

//Sort using selection sort
void Sort(Staque sq);

//Sort using quicksort
void QuickSort(Staque sq, int first, int last);

//Search using bsearch.  Returns index of item or -1 for not found
int BSearch(Staque sq, int val, int first, int last);

//Get the value loc after the first item
int Get(Staque sq, int loc);

//Just return the current storage size of staque
int Size(Staque sq);

//Print the current contents of stack
void PrintStaque(Staque sq);

//Add an item to end of staque
//just a wrapper for add
Staque Push(Staque sq, int val);

//Retrieve value at bottom.  Doesn't modify
int Peek(Staque sq);

//Pop value off of bottom.
Staque Pop(Staque sq, int * pval);

//Grow using doubling algorithm if necessary,
//also move data to front
Staque Grow(Staque sq);

//Release dma'd memory.  Should return NULL'd store.
Staque Release(Staque sq);

//Add an item to end of Staque.  May call grow.
Staque Add(Staque sq, int val);

//Remove an item from top/front of Staque.
Staque Remove(Staque sq, int * pval);

//Insert an item that will be at location loc.
Staque Insert(Staque sq, int val, int loc);

//Insert an item before the first item greater than
//its value
Staque InsertInOrder(Staque sq, int val);

#endif
