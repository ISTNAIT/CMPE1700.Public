#include <stdlib.h>
#include <stdio.h>


int main(int argc, char** argv)
{
    //Command line arguments
    //argc is the number of arguments (always 1 default)
    //argv is just an array of strings, with the arguments
    //argv[0] is the implicit "name" argument you always get.

    int arg1 = 0; //First integer
    int arg2 = 0; //Second integer
    char* end = NULL; //String pointer for detecting errors in strtol

    printf("You supplied %d explicit arguments\n", argc-1);
    printf("This program thinks its name is %s\n", argv[0]);

    if(argc != 3)
    {
        //I want exactly two integers.  This just won't do
        fprintf(stderr,"Just give me two numbers.  Not rocket science.");
    }

    //If I got here, I have two explicit arguments.  Are they integers?

    arg1 = strtol(argv[1], &end, 10);
    if (end == argv[1]) //Couldn't parse
    {
        fprintf(stderr, "A number. Nuuuumbeeerr. Figure it out.\n");
        exit(1); //Exit and throw and error.
    }

    arg2 = strtol(argv[2], &end, 10);
    if (end == argv[2]) //Couldn't parse
    {
        fprintf(stderr, "A number. Nuuuumbeeerr. Figure it out.\n");
        exit(1); //Exit and throw and error.
    }

    printf("The sum of %d and %d is %d\n", arg1, arg2, arg1+arg2);
    printf("ARE WE NOT GODS?!\n");
    fflush(stdout);

#ifdef DEBUG
//Pause to avoid console closing in debug mode.
//Because Microsoft sucks.
    fflush(stdin); //Make sure there's nothing lurking in the buffer.
    printf("\nPress Enter to Exit:");
    fflush(stdout);
    fgetc(stdin);
#endif //DEBUG

    return 0;
}
