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

//Linear Search - return index of key in deck, or -1
int SeqSearch(Card key, Card deck[], uint size)
{
  for(int i = 0; i < size; ++i)
      if(deck[i].face == key.face && deck[i].suit == key.suit) //Found it!
          return i;
  return -1;
}

//Binary Search - return index of key in deck, or -1
int BinSearch(Card key, Card deck[], uint beginning, uint end)
{
  //Sanity Check
  if (end < beginning) return -1;

  //Do I only have one?
  if (end == beginning)
  {
    if(equal(key,deck[beginning])) return beginning;
    else return -1;
  }

  //Check middle item
  int middle = (end-beginning)/2 + beginning;
  if (equal(key,deck[middle])) return middle;

  //Not here.  Recurse to find it in one of my halves
  if(lessthan(key,deck[middle])) return BinSearch(key,deck,beginning,middle-1);
  return BinSearch(key,deck,middle+1,end);
}
