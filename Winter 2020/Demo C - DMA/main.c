#include <stdlib.h>
#include <stdio.h>
#include "dma.h"

int main(int argc, char** argv)
{
    double result = 0.0;
    if (argc != 2)
    {
        fprintf(stderr, "%s requires a single argument\n",argv[0] );
        return EXIT_FAILURE;
    }

    PrefixCalc(argv[1], &result);
    printf("%f\n",result);
    return EXIT_SUCCESS;
}
