#include <stdlib.h>
#include <stdio.h>
#include "vect.h"

//Grow using doubling algorithm
Vector Grow(Vector v)
{
    Vector w = {NULL,0,0};
    //Do I have an old vector?
    if(!v.store)
    {
        //I have an empty vector.  Create one of the default size
        v.store = (int *) malloc(sizeof(int) * INITVECTSIZE);
        if(!v.store)//Didn't get memory for some reason
        {
            fprintf(stderr, "Memory allocation error in Grow. Unable to continue.");
            exit(EXIT_FAILURE);
        }
        v.size = 0;
        v.max = INITVECTSIZE;
        return v;
    }

    //I have an existing one.  Create a new one twice as big.
    w.max = 2* v.max;
    printf("Growing vector from %d to %d\n",v.max,w.max);
    w.size = v.size;
    w.store = (int *) malloc(sizeof(int)*w.max);
    if(!w.store)//Didn't get memory for some reason
    {
        fprintf(stderr, "Memory allocation error in Grow. Unable to continue.");
        exit(EXIT_FAILURE);
    }

    //Time to copy my array over
    for(int i = 0; i < v.size; ++i)
        w.store[i] = v.store[i];

    //I could now set the remainder to 0, if I want valid numbers
    for(int i = w.size; i < w.max; ++i)
        w.store[i] = 0;

    //Clean up my mess
    v = Release(v);
    return w;
}

//Release dma'd memory.  Should return NULL.
Vector Release(Vector v)
{
    free(v.store);
    v.store = NULL;
    v.size = 0;
    v.max = 0;
    return v;
}

//Add an item to end of Vector.  May call grow.
Vector Add(Vector v, int val)
{
    if(v.size == v.max) v = Grow(v);
    v.store[v.size++]=val;
    return v;
}

//Insert an item that will be at location loc.
Vector Insert(Vector v, int val, int loc)
{
//FIXME
    return v;
}

//Insert an item before the first item greater than
//its value
Vector InsertInOrder(Vector v, int val)
{
//FIXME
    return v;
}
