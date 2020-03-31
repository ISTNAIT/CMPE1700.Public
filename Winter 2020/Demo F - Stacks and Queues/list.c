#include "list.h"
#include <stdio.h>
#include <stdlib.h>

//Add in order (insert in front of first value > val).
Node* Add(Node * head, int val)
{
    //Working pointer
    Node * curr = NULL;
    //Allocate new node.
    Node * new = (Node *) malloc (sizeof(Node));
    if(!new)
    {
        fprintf(stderr,"Error allocating memory for node.");
        exit(EXIT_FAILURE);
    }

    new->next = NULL;
    new->value = val;

    //Special case---am I inserting at the beginning?
    if (!head || head->value >= val)
    {
        new->next = head; //Link in front of current head
        return new; //Return new head
    }

    //Other than that, find my insertion point
    //I NEED THE NODE *BEFORE* THE INSERTION POINT
    //Hence all the looking ahead using .next

    curr = head; //Start with head
    while(curr->next && curr->next->value < val) //keep going to end or insertpoint
        curr=curr->next;
    //at this point I am either at the last node (curr->next is 0)
    //or pointing at the node ahead of my insertion point.
    //insert after this position:
    new->next = curr->next;
    curr->next = new;
    return head;
}

//Add to location n means node will be nth (head is 0th).
//0 means add in front of head
//n > length of the list means add at end
//n < 0 we will interpret as 'add at end'
Node* AddAt(Node * head, int val, int loc)
{
    //Working pointer
    Node * curr = NULL;
    //Allocate new node.
    Node * new = (Node *) malloc (sizeof(Node));
    if(!new)
    {
        fprintf(stderr,"Error allocating memory for node.");
        exit(EXIT_FAILURE);
    }

    new->next = NULL;
    new->value = val;

    //Special case---am I inserting at the beginning?
    if (!head || !loc)
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


//Returns the index to the  first node with value, or negative
int Find(Node * head, int val)
{
    int loc = 0;

    //Traverse to first value or end
    while(head && head->value != val)
    {
        head = head-> next;
        loc++;
    }

    if (!head)//not found or empty list
        return -1;
    return loc;
}

//Returns a pointer to the first node with value, or NULL
Node* FindNode(Node * head, int val)
{
    //This is kind of fancy.  Think about how it would work
    return (head && val==head->value) ? head :
        head ? FindNode (head->next, val)
        : NULL;
}

//Delete the node at loc.  Interpret loc as above, except
//attempt to delete node after end of list will be ignored.
Node* RemoveAt(Node * head, int loc)
{
    //Scratch pointers
    Node * curr = head;
    Node * temp = NULL;

    //Special case: empty list
    if (!head) return NULL;

    //Special case: Remove head
    if (!loc)
    {
        curr = head->next;
        free(head);
        return curr;
    }

    //Traverse to node before one to be deleted
    while (curr->next && --loc) curr = curr->next;
    if(!curr->next) return head; //At end of list

    //Delete the node after current
    temp = curr->next->next;
    free(curr->next);
    curr->next = temp;

    return head;
}

//Recursive traversal print
void  Print (Node * head)
{
    if(head)
    {
        printf("%d->",head->value);
        Print(head->next);
    }
    else //special case--last node
    {
        printf("NULL\n");
    }
}


//Recursive traversal free memory
void  Free(Node * head)
{
    //Traverse to end (preorder recursion)
    if(head)
        Free(head->next);

    //This section will start from the last node and work backwards We
    //do this because if we go forward, we'll free nodes before we
    //traverse to the next one, which is a bad idea (especially in
    //multi-threaded applications).

    //My last "head" will be NULL, so don't try to free it.

    if(head) free(head);

    return;  //Don't actually need a return in a void function, but whatever.
}
