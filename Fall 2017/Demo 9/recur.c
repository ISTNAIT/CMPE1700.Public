#include "recur.h"
#include <string.h>
#include <stdio.h>

int palin(char * val)
{
    return palind(val,0,strlen(val)-1);
}

int palind(char * val, int first, int last)
{
    if(last - first < 2) return 1;
    if(val[first] == val[last])
        return palind(val,first+1,last-1);
    return 0;
}

int Fib(int val)
{
    printf("Fib(%d)\n",val);
    if (val < 2) return 1;
    return Fib(val - 1) + Fib (val -2);
}
