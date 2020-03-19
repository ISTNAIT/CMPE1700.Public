#pragma once
#ifndef VECTH
#define VECTH

//Use a macro constant to set the starting capacity of
//new vectors.
//NOTE: NO SEMICOLON AFTER MACROS. Semicolon will break things
#define VECTOR_INITIAL_CAPACITY 10

//First, we need a container for our new vector type.
//We'll use a struct to contain it.

//Forward declare my structure name. The first Vect is part of the
//official typename (struct Vect), the second is the typedef alias
//I.e, this typedef uses "Vect" as an alias for "struct Vect"
//Weird, I know, but you get used to it.
typedef struct Vect Vect;

//Now define my Vect structure.  Some people move this part to a
//c file, or even a second header file.  I put them in the header

struct Vect //Wrapper around a Vector of int
{
    int capacity; //Total size of reserved memory on heap (number of ints)
    int size;  //Current number of ints stored. size always <= capacity
    int * store; //Pointer to stored array on heap
}; //Don't forget the semi at the end of struct definitions.

//Below are the API functions for my Vector type.

int Value(Vect v, int index); //Return the value of the item at index.
void Add(Vect v, int val); //Add value to end of store.
void Grow(Vect v, int scale); //Increase size of store by factor of scale
void Print(Vect v, File * stream); //Print the content of v to stream.
#endif
