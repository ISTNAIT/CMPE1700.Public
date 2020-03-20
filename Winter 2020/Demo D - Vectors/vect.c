#include "vect.h"
#include <stdio.h>
#include <stdlib.h>

int Value(Vect* v, int index) //Return the value of the item at index.
{
    if(index < 0 || index >= v->capacity)
    {
        fprintf(stderr, "Error: Attempt to access memory out-of-bounds");
        exit(EXIT_FAILURE);
    }

    return v->store[index];
}

void Grow(Vect * v,  int scale , int verbose)//Incr. store size by scale factor
{
    //Verbose flag forces logging to console
    int newCapacity = v->capacity * scale;

    if(!v->store || newCapacity < VECTOR_INITIAL_CAPACITY)//Need to initialize
        newCapacity = VECTOR_INITIAL_CAPACITY;

    if(verbose) printf("Increasing store size to %d\n",newCapacity);

    //Get some new memory
    int* newStore = (int*)malloc(sizeof(int) * newCapacity);
    if(!newStore)
    {
        fprintf(stderr, "Error: Unable to reserve memory for growth.");
        exit(EXIT_FAILURE);
    }

    //Copy old store into new
    for(int i = 0; i < v->size; ++i)
        newStore[i] = v->store[i];

    //release old memory (Make sure you do this before you change the pointer)
    if (v->store) free(v->store); //Don't try to free a null pointer.

    //Point to new store
    v->store = newStore;

    //Reset capacity
    v->capacity = newCapacity;
}

void Add(Vect *v, int val, int verbose ) //Add value to end of store.
{
    //NB: Verbose flag passed to grow to make it chatty or not
    //Make sure I have room.
    if(v->size >= v->capacity) Grow(v,2,verbose);
    v->store[v->size] = val; //add at end
    v->size++;
}

void Print(Vect *v , FILE* stream )//Print the content of v to stream.
{
    if(stream)
        for (int i = 0; i < v->size; ++i)
            fprintf(stream,"%d ", v->store[i]);
    fprintf(stream,"\n");
}
