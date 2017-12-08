#include <stdlib.h>
#include <stdio.h>
#include "staque.h"


//Sort using selection sort
void Sort(Staque sq)
{
    //Iterate through places from front, moving smallest item in remaining set
    for(int i = sq.top;i < sq.bottom; ++i)
    {
        //Assume first one is smallest
        int smallest = i;
        //See if we're wrong about that
        for(int j = i + 1; j < sq.bottom; ++j)
            if(sq.store[j] < sq.store[smallest])
                smallest = j;
        //Swap if necessary
        if(smallest != i)
        {
            int temp = sq.store[i];
            sq.store[i] = sq.store[smallest];
            sq.store[smallest] = temp;
        }
    }
    return;
}

//Sort using quicksort
void QuickSort(Staque sq, int first, int last)
{
    //This version uses some int pointers, instead of index values,
    //because I already had some code lying around.
    //Remember: the first virtue of an engineer is laziness
    int iTemp = 0;
    if(last-first>2)
    {
        int * piPivot = &(sq.store[first]); //Pivot Location
        int * piLeft = &(sq.store[first+1]);//Left Pointer
        int * piRight =&(sq.store[last-1]);//Right Pointer
        while(piLeft < piRight)//Unutil pointers meet
        {
            while((*piRight>=*piPivot) && (piLeft<piRight))
            {
                piRight--;//Find right item in wrong set
            }
            while((*piLeft<=*piPivot) && (piLeft<piRight))
            {
                piLeft++;//Find left item in wrong set
            }
            if (*piLeft > *piRight)
            {
                //Swap left and right if out of order
                iTemp = *piRight;
                *piRight = * piLeft;
                *piLeft = iTemp;
            }
        }
        //Move pivot into proper location
        if(*piPivot > * piLeft) //Make sure pivot shouldn't be at far left
        {
            iTemp = *(piLeft);
            *(piLeft) = *piPivot;
            *piPivot=iTemp;
        }
        else //pivot was smallest
            piLeft=piPivot;
        //Call quicksort on two sublists
        int pivotloc = first + (piLeft - piPivot); //Pointer arithmetic to find offset
        QuickSort(sq,first,pivotloc);
        QuickSort(sq,pivotloc+1,last);
    }
    else if (last-first == 2) //Trivial list - not enough for three distinct pointers.
    {
        if(sq.store[first]>sq.store[first+1])//Sort if out of order
        {
            iTemp=sq.store[first+1];
            sq.store[first+1]=sq.store[first];
            sq.store[first]=iTemp;
        }
    }
    return;
}


//Search using bsearch.  Returns index of item or -1 for not found
//NB: last is one AFTER the range being searched
int BSearch(Staque sq, int val, int first, int last)
{
    if (last-first < 1) return -1; //Empty
    if (last==first+1) return (sq.store[first]==val?first:-1);//One item
    int mid = (first + last - 1)/2;
    if(sq.store[mid] == val) return mid;
    if(sq.store[mid] > val) return BSearch(sq, val, first, mid);
    return BSearch(sq, val, mid+1, last);
}


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
        //printf("Growing staque from %d to %d\n",sq.max,Size(sq)*2);
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
