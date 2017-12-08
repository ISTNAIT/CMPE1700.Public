#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <string.h>
#include "staque.h"
#include "ll.h"

int main(int argc, char** argv)
{

    Staque staq = {NULL,-1,0}; //Initialize to NULL.
    Node * list = NULL;
    srand((unsigned int)time(NULL)); //Init rand generator

    //List tests

    for(int i = 0; i < 50; ++i)
        list = AddNodeToHead(list,rand()%100);

    printf("Random list:\n");
    PrintList(list);
    printf("\n");

    printf("Sorted list:\n");
    list = SortList(list);
    PrintList(list);
    printf("\n");

    //Staque tests

    printf("Random vector:\n");
    for(int i = 0; i < 50; ++i)
        staq = Add(staq,rand()%100);
    PrintStaque(staq);
    printf("\n");

    printf("Sorted vector:\n");
    //Sort(staq);
    QuickSort(staq,staq.top,staq.bottom);
    PrintStaque(staq);
    printf("\n");
    int searchval = rand()%100;
    int searchloc = BSearch(staq,searchval,staq.top,staq.bottom);
    printf("\n");
    printf("The value %d was %s (loc:%d)\n", searchval, (searchloc == -1)?"not found":"found",searchloc);

    printf("\n");

    int testsize = 1000;
    int testfactor = 2;
    int testmax = 250000;
    for(int n = testsize; n <= testmax; n*=testfactor)
    {
        printf("Comparing two sorts for n = %d :\n",n);
        staq = Release(staq);
        for(int i = 0; i < n; ++i)
            staq = Add(staq,rand()%100);

        printf("Quicksorting vector...");
        fflush(stdout);
        QuickSort(staq,staq.top,staq.bottom);
        printf("Done\n");
        fflush(stdout);

        staq = Release(staq);
        for(int i = 0; i < n; ++i)
            staq = Add(staq,rand()%100);
        printf("Selection sorting vector...");
        fflush(stdout);
        Sort(staq);
        printf("Done\n\n");
        fflush(stdout);
    }

    //Clean up toys
    list = DeleteList(list);
    staq = Release(staq);
    fflush(stdout);
    //Press enter to not make debug window go away
#ifdef _DEBUG
    fflush(stdin); //Make sure there's nothing lurking in the buffer.
    printf("Press Enter to Exit");
    fgetc(stdin);
#endif

    return EXIT_SUCCESS;
}
