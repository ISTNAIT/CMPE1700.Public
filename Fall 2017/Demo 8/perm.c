#include "perm.h"
#include <string.h>

//Simple selection sort
void Sort(char * vals)
{
    int smallest = 0;
    char tmp = 0; //For swap
    for(int i = 0; i < strlen(vals) - 1; ++i)
    {
        //Find the smallest in i to end
        smallest = i;
        for(int j = i+1; j < strlen(vals); ++j)
            if(vals[j]<vals[smallest]) smallest = j;
        //If necessary, swap smallest to pos i
        if(smallest != i)
        {
            tmp = vals[i];
            vals[i] = vals[smallest];
            vals[smallest] = tmp;
        }
    }
}

//Find the highest valued item that is greater than
//the next item in whichever direction it is pointing.
int LargestMobile(char * vals, int *  direct)
{
    int lm = -1;  //Negative means no mobile found
    for(int i=0; i < strlen(vals); ++i)
        //Is it mobile?
        if(i + direct[i] >= 0 && i+direct[i] < strlen(vals) ) //Not at end
            if (vals[i] > vals[i+direct[i]]) //Larger than neighbor
                if(lm<0 || vals[lm] < vals[i]) //Bigger than last one
                    lm = i;
    return lm;
}

//Reverse the direction of any values larger than the one at lm
void ReverseLarger(char * vals , int * direct, int lm)
{
    for(int i =0; i < strlen(vals); ++i)
        if(vals[i] > vals[lm]) direct[i] *= -1;
}

//Move the value at lm (and it's direction value).  Just a swap.
void MoveLargestMobile(char * vals, int *  direct, int lm)
{
    int d = direct[lm];
    char tmpv = vals[lm];
    int tmpd = direct[lm];
    vals[lm] = vals[lm+d];
    direct[lm] = direct [lm+d];
    vals[lm+d] = tmpv;
    direct[lm+d] = tmpd;
}
