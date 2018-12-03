#include "ll.h"
#include <stdlib.h>
#include <stdio.h>

Node * AddToHead(Node * head, int val)
{
	Node * shiny = NULL;
	if (!(shiny = (Node *)malloc(sizeof(Node))))
	{
		fprintf(stderr, "Memory allocation failure. (AddToHead).");
		exit(EXIT_FAILURE);
	}
	//If I make it here, I have a new node for the head.
	//Connect it to the old list.
	shiny->next = head;
	shiny->value = val;

	return shiny;
}

Node * AddToTail(Node * head, int val)
{
	//Is this a llist?
	if (!head)
		return AddToHead(head, val);
	//Otherwise //find the tail
	Node * tail = head;
	while (tail->next) tail = tail->next;
	//Add a new node
	tail->next = (Node *)malloc(sizeof(Node));
	if (tail->next)
	{
		tail->next->value = val;
		tail->next->next = NULL;
	}
	else
	{
		fprintf(stderr, "Memory allocation failure. (AddToTail).");
		exit(EXIT_FAILURE);
	}
	return head;
}

Node * CleanUp(Node * head)
{
	if (head) CleanUp(head->next);
	if (!head) return NULL;
	free(head);
	return NULL;
}

Node * AddInOrder(Node * head, int val)
{
	Node * ip = head;
	//3 Cases: (1) Empty List, (2) Insert at head, (3) insert later
	//(1)
	if (!head) return AddToHead(head,val);
	//(2)
	if (val <= head->value) // Insert at front
		return AddToHead(head, val);
	//If we got here, the node goes somewhere in the existing list.
	//Find the insertion point
	while (ip->next && ip->next->value < val) ip = ip->next;
	//Currently ip points to node before insertion point.
	//Set value

	Node * newby = (Node *)malloc(sizeof(Node));
	if (!newby) {
		fprintf(stderr, "Gurgle. Dying...");
		exit(EXIT_FAILURE);
	}
	newby->value = val;
	//Hand off balloon string
	newby->next = ip->next;
	//insert
	ip->next = newby;
	return head;
}

Node * InsertNodeInOrder(Node * head, Node * valnode)
{
	Node* insPoint = NULL;

	//Take the node I was handed, and insert it into the list
	//Sanity checks:
	if (!valnode) return head; //Ain't nuthin' to do
	//I only want a node, not a freaking list!
	if (valnode->next)
	{
		fprintf(stderr, "Cowardly refusing to corrupt the list you gave me instead of a node.  Pillock.");
		return head;
	}
	//3 Choices
	
	//(1) Empty list?
	if (!head) return valnode;  //Easy enough.  I only have one node.
	
    //(2) Insert in front of head?
	if(head->value > valnode->value)
	{
		valnode->next = head;
		return valnode;
	}

	//(3) Find insertion point
	insPoint = head;
	while (insPoint->next && 
		insPoint->next->value < valnode->value)
		insPoint = insPoint->next;
	//If I got here, I can insert at inspoint
	valnode->next = insPoint->next;
	insPoint->next = valnode;
	return head;
}

Node * SortAscending(Node * head)
{
	//Just rearranging the list.  No need to create new nodes.
	Node * newHead = NULL;
	Node * toBeInserted = NULL;
	while (head)
	{
		toBeInserted = head;
		head = head->next;
		toBeInserted->next = NULL; //Cut the head off
		newHead = InsertNodeInOrder(newHead, toBeInserted);
	}
	return newHead;
}

void PrintList(Node * head)
{
	if (!head) {
		printf("\n");  return;
	}
	printf("%d ", head->value);
	PrintList(head->next);
}


