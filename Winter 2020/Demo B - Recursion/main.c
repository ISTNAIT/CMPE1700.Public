#include <stdlib.h>
#include <stdio.h>
#include "recursion.h"

int main(int argc, char** argv)
{
    if (argc != 2)
    {
        fprintf(stderr, "%s requires a single argument\n",argv[0] )
        return EXIT_FAILURE;
    }

    printf("\n%s - $d\n", argv[1], PrefixCalc(argv[1],0));
    return EXIT_SUCCESS;
}
