#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include "list.h"


int main(int argc, char** argv)
{
    //Scratch variables.
    int i = 0;
    int loc = 0;
    //We'll use random numbers to illustrate the valuable
    //insert-in-order functionality.
    srand(time(NULL));

    //Create a linked list
    Node* head = NULL; //The simplest possible list is just a NULL
                    //pointer.

    for (int i = 0; i < 50; ++i)
        head = Add(head,rand()%25); //Add a random number between
                                     //0,25. Note that because we
                                     //might be adding a new node in
                                     //front of the head, head might
                                     //change and thus we need this
                                     //head = Add() form.
    Print(head); //Print my list contents.

    //Chose a random value to delete
    i = rand()%25;

    printf("Deleting all nodes with value %d\n",i);

    while((loc = Find(head,i)) >= 0)
        head = RemoveAt(head,loc);

    Print(head);

    printf("Adding some nodes at various spots.\n");

    head = AddAt(head,111,0);
    head = AddAt(head,999,-1);
    head = AddAt(head,555,10);

    Print(head);

    //Clean up my toys.
    Free(head);

    return EXIT_SUCCESS;
}
