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

//Quicksort
void Quicksort(Card deck[], uint size)
{
  Quicksortr(deck,0,size-1); //Call recursive version
}

//Recursive Quicksort
void Quicksortr(Card deck[], uint first, uint last)
{
  //Base case
  if(last <= first) //1 or fewer
    return;
  if (last - first == 1) // 2 cards
  {
    if (lessthan(deck[last],deck[first]));
      SwapCards(deck,last,first);
    return;
  }
  //If I got here, three or more cards,  time for the qs algorithm
  int left = first + 1;
  int right = last;

  //Partition the deck
  do
  {
    while(right > left && greaterthan(deck[right],deck[first])) //Move right pointer while bigger
      right--;

    while(left < right &&  !greaterthan(deck[left],deck[first]))
      left++;

    if(right > left) SwapCards(deck,left,right);
  } while (right>left);

  //Swap the key into the correct location
  //Special case: key already in correct location. (right is used an marker)
  if (right == first + 1 && lessthan(deck[first],deck[right]))
     right --; //Move right pointer so key swaps with itself.
  //Swap em
  SwapCards(deck,first,right);

  //Recursive calls
  //left
  Quicksortr(deck,first,(right>first)?right-1:first);
  //right (but check to make sure I don't go past bounds)
  Quicksortr(deck,(right<last)?right+1:last,last);
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
