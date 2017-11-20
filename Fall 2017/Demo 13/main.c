#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <string.h>
#include "ll.h"

int main(int argc, char** argv)
{
    Node * head = NULL;
    srand((unsigned int)time(NULL));

    for(int i = 0; i < 10; ++i)
        head = Add(head,rand()%100);

    PrintList(head);

    head = Delete(head);

    for(int i = 0; i < 10; ++i)
        head = InsertInOrder(head,rand()%100);

    PrintList(head);

    head = Delete(head);

    fflush(stdout);
    //Press enter to not make debug window go away
#ifdef _DEBUG
    fflush(stdin); //Make sure there's nothing lurking in the buffer.
    printf("Press Enter to Exit");
    fgetc(stdin);
#endif

    return EXIT_SUCCESS;
}
