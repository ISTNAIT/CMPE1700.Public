#include "recursion.h"
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
//Parse
char* PrefixCalc(char* token, double * result)
{
    //State variables
    char * next = 0; //Token after this one
    double left = 0.0; //Result of left subtree
    double right = 0.0; //Result of right subtree
    char op = 0; //Operation

    if (!token) //Hey, that's a null ptr, not a string!
    {
        fprintf (stderr,"If you gaze long into an abyss,/n"
                 "the abyss will gaze back into you./n");
        exit(EXIT_FAILURE);
    }

    //Am I at the end of my string?
    if(!(*token)) //null character
        return token;

    //Split off the first token by replacing the first space with a null.
    next = token;
    while(*next && *next != ' ') next++;
    *next = 0;
    next++; //Point to next token

    //Is token a value?
    if (isdigit(*token)) //Got a value here
    {
        *result = strtod(token,NULL);
        return next;
    }

    //Assume an operation
    op = *token;
    next = PrefixCalc(next,&left);
    next = PrefixCalc(next,&right);

    switch (op)
    {
    case '+': *result = left + right; break;
    case '-': *result = left - right; break;
    case '*': *result = left * right; break;
    case '/': *result = left / right; break;
    default: //I have no idea what this is.
        fprintf (stderr,"And he said sibboleth,\n"
                 "for he could not frame to pronounce it right./n");
        exit(EXIT_FAILURE);
    }
    return next;
}
