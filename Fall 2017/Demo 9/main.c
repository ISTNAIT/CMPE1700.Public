#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "recur.h"

//Recursive palindrome checker

int main(int argc, char** argv)
{

    if(argc != 2)
    {
        fprintf(stderr,"Expected one string argument.\n");
        return - 1;
    }

    if (atoi (argv[1]) == 0)
    {
        if(palin(argv[1]))
            printf("%s is a palindrome.", argv[1]);
        else
            printf("%s is not a palindrome.", argv[1]);
    }

    else
    {
        printf("%d\n",Fib(atoi(argv[1])));
    }

    fflush(stdout);
    return 0;
}
