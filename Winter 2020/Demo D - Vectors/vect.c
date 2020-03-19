#include "vect.h"
#include <stdio.h>
#include <stdlib.h>

int Value(Vect v, int index) //Return the value of the item at index.
{
    if(index < 0 || index >= v.capacity)
    {
        fprintf(stderr, "Error: Attempt to access memory out-of-bounds");
        exit(EXIT_FAILURE);
    }

    return v.store[index];
}

void Grow(Vect v, int scale = 2);//Increase size of store by factor of scale
{
    int newCapacity = v.capacity * scale;
    if(scale <= 0) return; //Don't use grow to shrink.

    if(!v.store || newCapacity < VECTOR_INITIAL_CAPACITY)//Need to initialize
        newCapacity = VECTOR_INITIAL_CAPACITY;
    int* newStore = (int*)malloc(sizeof(int) * newCapacity);
    if(!newStore)
    {
        fprintf(stderr, "Error: Unable to reserve memory for growth.");
        exit(EXIT_FAILURE);
    }

    //Copy old store into new
    for(int i = 0; i < v.size; ++i)
        newStore[i] = v.store[i];
    //release old memory (Make sure you do this before you change the pointer)
    if (v.store) free(v.store); //Don't try to free a null pointer.
    //Point to new store
    v.store = newStore;
    //Reset capacity
    v.capacity = newCapacity;
}

void Add(Vect v, int val);//Add value to end of store.
{
    //Do I have room?
    if(v.size >= v.capacity) Grow(v);
    v.store[v.size] = val; //add at end
    v.capacity++;
}

void Print(Vect v, File * stream = stdout) //Print the content of v to stream.
{

}
