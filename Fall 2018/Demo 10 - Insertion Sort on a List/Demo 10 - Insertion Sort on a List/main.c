#include <stdlib.h>
#include <time.h>
#include <stdio.h>
#include <crtdbg.h>
#include "ll.h"

int main(int argc, char** argv)
{
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);
	_CrtSetReportMode(_CRT_ERROR, _CRTDBG_MODE_DEBUG);

	srand((unsigned int) time(NULL));

	Node * head = NULL;

	for (int i = 0; i < 20; ++i)
	{
		if (i % 2) head = AddToHead(head,rand()%10);
		else head = AddToTail(head,rand()%10);
		//head = AddInOrder(head, rand() % 10);
		/*Node* newNode = (Node*)malloc(sizeof(Node));
		if (newNode) 
		{ 
			newNode->value = rand() % 10;
			newNode->next = NULL;
			head = InsertNodeInOrder(head, newNode);
		}*/
	}

	PrintList(head);
	head = SortAscending(head);
	PrintList(head);
	head = CleanUp(head);

	return EXIT_SUCCESS;
}