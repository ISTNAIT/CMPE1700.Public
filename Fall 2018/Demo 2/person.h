#pragma once
#ifndef _PERSONH_
#define _PERSONH_
typedef unsigned int uint;

typedef enum {brown, blue, green, hazel, purple, pink, grey} EyeColour;
typedef enum {brunette=100, blonde, black, white, red} HairColour;

typedef struct {
    char Name[255];
    uint ID;
    EyeColour Eyes;
    HairColour Hair;
    double Height; //cm
    double Mass; //kg
} Person;

void PrintPerson(Person);
void PrintColour(int);

#endif
