#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include <string.h>
#include "ll.h"

int main(int argc, char** argv)
{


    fflush(stdout);
    //Press enter to not make debug window go away
#ifdef _DEBUG
    fflush(stdin); //Make sure there's nothing lurking in the buffer.
    printf("Press Enter to Exit");
    fgetc(stdin);
#endif

    return EXIT_SUCCESS;
}
