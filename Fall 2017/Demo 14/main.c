#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <string.h>
#include "staque.h"
#include "ll.h"

int main(int argc, char** argv)
{

    //Staque staq = {NULL,-1,0}; //Initialize to NULL.
    Node * list = NULL;
    srand((unsigned int)time(NULL)); //Init rand generator

    for(int i = 0; i < 50; ++i)
        list = AddNodeToHead(list,rand()%100);

    PrintList(list);

    list = SortList(list);
    PrintList(list);

    //Clean up toys
    list = DeleteList(list);

    fflush(stdout);
    //Press enter to not make debug window go away
#ifdef _DEBUG
    fflush(stdin); //Make sure there's nothing lurking in the buffer.
    printf("Press Enter to Exit");
    fgetc(stdin);
#endif

    return EXIT_SUCCESS;
}
