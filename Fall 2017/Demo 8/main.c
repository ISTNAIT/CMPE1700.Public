#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "perm.h"

//Demo of Steinhaus-Johnson-Trotter Algorithm (with Evans' adjustment)
//Takes exactly one command-line argument and generates all permutations
//of the characters in the string
int main(int argc, char** argv)
{
    int * direct = 0; //Pointer for array of ints that will store direction
    int lm = 0;  //Index of current largest mobile item

    if(argc != 2)
    {
        fprintf(stderr, "Error: Expected a single argument to permute.");
        return -1;
    }

    //If we got here, we have a string to permute.  I'll also need some way of
    //tracking the current direction of each character in the permutation.  I
    //could do that with a structure, but we can also do it with a parallel
    //array.  I'll just create one using DMA (more on that later)

    direct = (int *) malloc (strlen(argv[1])); //Space to store ints.
    //Initialize everything as going left
    for(int i = 0; i < strlen(argv[1]); ++i)
        direct[i] = -1;

    //For this algorithm, you have to start with the ordered set.
    Sort(argv[1]);

    //Our first permutation is, obviously, the sorted string
    printf("%s\n", argv[1]);

    //Ready to begin.  Keep doing this until nothing still mobile.
    while((lm=LargestMobile(argv[1],direct)) >= 0)
    {
        ReverseLarger(argv[1],direct,lm);
        MoveLargestMobile(argv[1],direct,lm);
        printf("%s\n", argv[1]);
    }

    //Clean up the memory I borrowed
    free(direct);
    direct=0;

    fflush(stdout);
    return 0;
}
