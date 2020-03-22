#include <stdlib.h>
#include <stdio.h>
#include "vect.h"


int main(int argc, char** argv)
{
    //Create a vector of int

    Vect v = {0,0,NULL}; //You can use initializers to set initial state

    for (int i = 0; i < 100; ++i)
        Add(&v,i,1);

    Print(&v,stdout);

    //Clean up my toys
    if(v.store) free(v.store);
    return EXIT_SUCCESS;
}
