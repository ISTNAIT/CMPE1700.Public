#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <string.h>
#include "vect.h"

int main(int argc, char** argv)
{
    Vector vect = {NULL,0,0}; //Initialize to NULL.
    srand((unsigned int)time(NULL)); //Init rand generator

    for(int i = 0; i < 100; ++i)
        vect = Add(vect,rand()%100);

    //Let's see!
    for(int i = 0; i < vect.size; ++i)
        printf("%d ", vect.store[i]);

    printf("\n");

    //Remember to clean up your toys.
    vect = Release(vect);

    fflush(stdout);
    //Press enter to not make debug window go away
#ifdef _DEBUG
    fflush(stdin); //Make sure there's nothing lurking in the buffer.
    printf("Press Enter to Exit");
    fgetc(stdin);
#endif

    return EXIT_SUCCESS;
}
