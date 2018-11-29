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

void PrintList(Node * head)
{
	if (!head) {
		printf("\n");  return;
	}
	printf("%d ", head->value);
	PrintList(head->next);
}


