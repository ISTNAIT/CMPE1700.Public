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

void PrintList(Node * head)
{
	if (!head) {
		printf("\n");  return;
	}
	printf("%d ", head->value);
	PrintList(head->next);
}


