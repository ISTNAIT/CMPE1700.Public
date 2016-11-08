#include "util.h"

//Fisher-Yates Shuffle
void Shuffle(Card deck[], uint size)
{
    for(int i = 0; i < size; ++i)
    {
      int swap = rand()%(size-i) +  i;
      SwapCards(deck,i,swap);
    }
}

//Selection Sort
void Sort(Card deck[], uint size)
{
    for(uint i = 0; i < size; ++i)
    {
      uint s = FindSmallest(deck,i,size);
      SwapCards(deck,i,s);
    }
}
