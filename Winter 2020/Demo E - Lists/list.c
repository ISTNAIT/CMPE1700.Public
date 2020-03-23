#include "list.h"
#include <stdio.h>
#include <stdlib.h>

//Add in order (insert in front of first value > val).
Node* Add(Node * head, int val);

//Add to location n means node will be nth (head is 0th).
//0 means add in front of head
//n > length of the list means add at end
//n < 0 we will interpret as 'add at end'
Node* AddAt(Node * head, int val, int loc)
{
    //Working pointer
    Node * curr = NULL;
    //Allocate new node.
    Node * new = (Node *) malloc (sizeof Node);
    if(!new){fprintf(STDERR,"Error allocating memory for node."); exit EXIT_FAILURE;}
    new->next = NULL;
    new->value = val;

    //Special case---am I inserting at the beginning?
    if (!head or !loc)
    {
        new->next = head; //Link in front of current head
        return new; //Return new head
    }

    //Next special case---insert at the end.
    if(loc < 0)
    {
        //Find the end
        curr = head;
        while (curr->next) //Not at the end yest
            curr = curr->next;
        //add new after the end.
        curr->next = new;
        return head;
    }

    //Other than that, just start counting.
    curr = head; //Start with head
    while(curr->next && --loc) //keep going to end or loc steps
        curr=curr->next;
    //at this point I am either at the last node (curr->next is 0)
    //or pointing at the node loc nodes after head.
    //insert after this position:
    new->next = curr->next;
    curr->next = new;
    return head;
}

//Returns a pointer to the first node with value, or NULL
Node* Find(Node * head, int val)
{
    //This is kind of fancy.  Think about how it would work
    return (head && val==head->value) ? head :
        head ? Find (head->next, val)
        : NULL;
}

//Delete the node at loc.  Interpret loc as above, except
//attempt to delete node after end of list will be ignored.
Node* RemoveAt(Node * Head, int val, int loc);

//Recursive traversal print
void  Print (Node * head);

//Recursive traversal free memory
void  Free(Node * head);
