#include "person.h"
#include <stdlib.h>
#include <stdio.h>

int main(int argc, char** argv)
{
    Person AJ = {"AJ Armstrong", 826103, brown, brunette, 185, 100};

    //Print out all the possible combinations of hair, eye color
    for(int h = brunette; h <= red; h++)
    {
        for(int e = brown; e <= grey; e++)
        {
            PrintColour(h);
            printf(", ");
            PrintColour(e);
            printf("\n");
        }
    }


    PrintPerson(AJ);

    return EXIT_SUCCESS;

}
