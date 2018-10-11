#include "person.h"
#include <stdio.h>

//Print a person in
void PrintPerson(Person p)
{
    printf("%s (%d)\n\tHair:", p.Name,p.ID);
    PrintColour(p.Hair);
    printf(" Eyes:");
    PrintColour(p.Eyes);
    printf("\n");
    return;
}

void PrintColour(int c)
{
    switch(c)
    {
    case brown:
        printf("Brown"); break;
    case blue:
        printf("Blue"); break;

    case green:
        printf("Green"); break;

    case hazel:
        printf("Hazel"); break;

    case purple:
        printf("Purple"); break;

    case pink:
        printf("Pink"); break;

    case grey:
        printf("Grey"); break;

    case brunette:
        printf("Brunette"); break;

    case blonde:
        printf("Blonde"); break;

    case black:
        printf("Black"); break;
    case white:
        printf("White"); break;
    case  red:
        printf("Red"); break;
    default:
        printf("None");

    }
}
