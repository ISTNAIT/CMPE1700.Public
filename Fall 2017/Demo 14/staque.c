#include <stdlib.h>
#include <stdio.h>
#include "staque.h"


//Get the value loc after the first item
//Return 0 if invalid location
int Get(Staque sq, int loc)
{
    if(loc < 0 || loc >= Size(sq)) return 0;
    return sq.store[sq.top + loc];
}

//Just return the current storage size of staque
int Size(Staque sq)
{
    if(!sq.store || !sq.max || sq.top < 0) // no storage
        return 0;
    return (sq.bottom - sq.top); //Actual used space
}

//Print the current contents of stack
void PrintStaque(Staque sq)
{
    for(int i = sq.top; i < sq.bottom; ++i)
        printf("%d ", sq.store[i]);
    printf("( Size: %d)\n", Size(sq));
}

//Add an item to end of staque
//just a wrapper for add
Staque Push(Staque sq, int val)
{
    return Add(sq,val);
}

//Retrieve value at bottom.  Doesn't modify
int Peek(Staque sq)
{
    return sq.store[sq.bottom-1];
}

//Pop value off of top.
Staque Pop(Staque sq, int* pval)
{
    *pval = sq.store[--sq.bottom];
    return sq;
}

//Grow using doubling algorithm if necessary,
//also move data to front
Staque Grow(Staque sq)
{
    //Holder for a new one if needed
    Staque sp = {NULL,-1,0,0};

    //Do I have a valid store?
    if(!sq.store)
    {
        //I have an empty staque.  Create one of the default size
        sq.store = (int *) malloc(sizeof(int) * INITSTAQUESIZE);
        if(!sq.store)//Didn't get memory for some reason
        {
            fprintf(stderr, "Memory allocation error in Grow. Unable to continue.");
            exit(EXIT_FAILURE);
        }
        sq.top = -1;
        sq.bottom = 0;
        sq.max = INITSTAQUESIZE;
        return sq;
    }

    //I have an existing one.  Do I need a new one?
    if(Size(sq) * 2 > sq.max)
    {
        printf("Growing staque from %d to %d\n",sq.max,Size(sq)*2);
        sp.max = Size(sq)*2;
        sp.store = (int *) malloc(sizeof(int)*sp.max);
        if(!sp.store)//Didn't get memory for some reason
        {
            fprintf(stderr, "Memory allocation error in Grow. Unable to continue.");
            exit(EXIT_FAILURE);
        }
    }
    else sp.store = sq.store; //Size is fine, just use current store

    //Time to move my array over
    int j = 0;
    for(int i = sq.top; i < sq.bottom; ++i)
        sp.store[j++] = sq.store[i];
    sp.top = 0;
    sp.bottom = j;

    //Clean up my mess
    if(sp.store != sq.store) sq = Release(sq); //If I have a new store, release old store
    sq = sp;
    return sq;
}

//Release dma'd memory.  Should return NULL.
Staque Release(Staque sq)
{
    free(sq.store);
    sq.store = NULL;
    sq.top = -1;
    sq.bottom = 0;
    sq.max = 0;
    return sq;
}

//Add an item to end of Staque.  May call grow.
Staque Add(Staque sq, int val)
{
    if(!sq.store || sq.bottom == sq.max) sq = Grow(sq);
    sq.store[sq.bottom++]=val;
    //Special case, using top = -1 for empty, correct
    if(sq.top == -1) sq.top = 0;
    return sq;
}

//Remove an item from top/front of Staque.
//Value returned by address
Staque Remove(Staque sq, int * pval)
{
    *pval = sq.store[sq.top++];
    return sq;
}

//Insert an item that will be at location loc.
Staque Insert(Staque sq, int val, int loc)
{
    //Top, confirm that the location is valid.
    //I'm going to do mine so that if it is before the front or after the back, item
    //gets moved there.
    if(loc < 0) loc = 0;

    //Handle case of first insertion, or adding to end
    if(!sq.store || loc >= Size(sq))
        return sq = Add(sq,val);

    //OK, if I got here, then I need to do an actual insert.

    //Grow if necessary:
    if(sq.bottom  == sq.max)
        sq = Grow(sq);

    //Move bottom half
    for (int i = sq.bottom; i > sq.top + loc; i--)
        sq.store[i] = sq.store[i-1];

    //Insert
    sq.store[sq.top + loc] = val;
    sq.bottom++;
    return sq;
}

//Insert an item before the first item greater than
//its value
Staque InsertInOrder(Staque sq, int val)
{
    //Special case: empty store
    if(!sq.store || !Size(sq)) return Add(sq,val);

    //Find insertion location
    int loc = sq.top;
    while(loc < sq.bottom && sq.store[loc] < val )
        loc++;
    return Insert(sq,val,loc-sq.top);
}
