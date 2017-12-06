#include <stdlib.h>
#include <stdio.h>
#include "ll.h"

//Sort list in ascending order using insertion sort
Node * SortList(Node * head)
{
    Node * moving = NULL;
    Node * predlarge = NULL;
    Node * new = NULL;
    Node * current = NULL;

    if(head==NULL || head->next==NULL) //Nothing to do
        return head;
    while(head) //Keep going till we run out
    {
        //Find predecessor of largest in unsorted list
        predlarge = head;
        current = head;
        while(current && current->next){
            if( current->next->val > predlarge->next->val)
                predlarge = current;
            current = current-> next;
        }
        //Now should have a pointer to predecessor of largest val
        //Case 1 - Only one item.  Move it.
        if(!predlarge->next) //Last item
        {
            head=predlarge->next;
            predlarge->next = new;
            new = predlarge;
        }

        //Case 2 - head is current largest
        else if(predlarge->next->val < head->val)
        {
            // move head over
            moving = head;
            head = head->next;
            //insert moving in front of new heads
            moving->next = new;
            new = moving;
        }
        //Case 3 - Some other node is getting moved
        else //predlarge precedes my largest
        {
            moving = predlarge->next;
            predlarge->next = predlarge->next->next;
            //Insert moving at the front of the list
            moving->next = new;
            new = moving;
        }
    }
    return new; //New, sorted list
}


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
Node * DeleteList(Node * head)
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

//Add an item to the front of the list
Node * AddNodeToHead(Node * head, int val)
{
    //I'm going to a new node
    Node * new = (Node *) malloc(sizeof(Node));
    new->val = val;
    new->next = head; //Insert in front of head
    return new;
}


//Add an item to end of List.
Node * AddNodeToTail(Node * head, int val)
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
Node * InsertNodeAfter(Node * loc, int val)
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
Node * InsertNodeInOrder(Node * head, int val)
{
    //Find the node BEFORE the first node greater than val.
    //First case, empty list.

    if(! head) return (InsertNodeAfter(NULL,val));

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
    InsertNodeAfter(curr,val);
    return head;
}

//Find last node (return head if < 1 node)
Node * FindUltimateNode(Node * head)
{
    while(head && head->next) head = head->next;
    return head;
}

//Find second last node (return head if < 2 nodes)
Node * FindPenultimateNode(Node * head)
{
    while(head && head->next && head->next->next) head = head->next;
    return head;
}


//Reverse List (no copying)
Node * ReverseList(Node * head)
{
    Node * old = head;
    Node * new = head;
    Node * oldcurr = old;
    Node * newcurr = new;

    //Special cases: 0 or 1 nodes
    if(! head || ! head->next)
        return head;

    //Move one item over to give myself a handle
    oldcurr = FindPenultimateNode(old);
    new = oldcurr->next;
    oldcurr->next = NULL;

    while(old->next) //Until we have only one item left
    {
        oldcurr = FindPenultimateNode(old);
        newcurr = FindUltimateNode(new);
        newcurr->next = oldcurr-> next;
        oldcurr->next = NULL;
    }

    //Move last item over
    newcurr->next->next = old;
    return new;
}

//Queue behaviour (opposite of add, above)
Node * RemoveNode(Node * head, int * pval)
{
    //Remove the front node, return value by address
    if (!head) return NULL; //No list, no behaviour

    *pval = head->val;
    Node * NewHead = head->next;
    free(head);
    return NewHead;
}

//Stack behaviour (wrapper for AddToHead)
Node * PushNode(Node * head, int val)
{
    return AddNodeToHead(head,val);
}

//Stack behaviour (0 if null)
int PeekNode(Node * head)
{
    return head ? head->val : 0;
}

//Stack behaviour (wrapper for Remove)
Node * PopNode(Node * head, int * pval)
{
    return RemoveNode(head,pval);
}
