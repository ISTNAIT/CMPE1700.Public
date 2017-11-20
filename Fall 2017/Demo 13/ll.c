#include <stdlib.h>
#include <stdio.h>
#include "ll.h"

//Print List
void PrintList(Node * head)
{
    while (head)
    {
        printf("%d->",head->val);
        head = head->next;
    }
    printf("NULL\n");
}

//Free List memory
Node * Delete(Node * head)
{
    Node * curr = head;
    while(curr)
    {
        curr = head->next;
        free (head);
        head = curr;
    }
    return NULL;
}

//Add an item to end of List.
Node * Add(Node * head, int val)
{
    //I'm going to a new node
    Node * new = (Node *) malloc(sizeof(Node));
    new->val = val;
    new->next = NULL;

    //Put this new node at the end of my list
    //Do I even have a list?
    if(!head)
        return new;

    //Find the end of my list.
    Node * curr = head;
    while(curr->next) curr=curr->next;
    //Insert at end, curr points to last node (not the NULL)
    curr->next = new;
    return head;
}

//Insert an item that will be after node at loc.
Node * InsertAfter(Node * loc, int val)
{
  //I'm going to a new node
    Node * new = (Node *) malloc(sizeof(Node));
    new->val = val;
    new->next = NULL;
    if(! loc) return new;

    new->next = loc->next;
    loc->next = new;
    return loc;
}

//Insert an item before the first item greater than
//its value
Node * InsertInOrder(Node * head, int val)
{
    //Find the node BEFORE the first node greater than val.
    //First case, empty list.

    if(! head) return (InsertAfter(NULL,val));

    //Second case, insert at head.
    if (head->val > val)
    {
        Node * new = (Node *) malloc(sizeof(Node));
        new->val = val;
        new->next = head;
        return new;
     }

    //Otherwise, just find my insertion point.
    Node * curr = head;
    //Check the value of the node after my current node
    //Take advantage of lazy evaluation to only check next val
    //if next exists.
    while (curr->next && curr->next->val < val) curr = curr->next;
    //At insertion pont
    InsertAfter(curr,val);
    return head;
}
