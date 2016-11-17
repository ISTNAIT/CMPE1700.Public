#ifndef UTILH
#define UTILH
#include "cards.h"

typedef unsigned int uint;

//Fisher-Yates Shuffle
void Shuffle(Card deck[], uint size);

//Selection Sort
void Sort(Card deck[], uint size);

//Quicksort wrapper
void Quicksort(Card deck[], uint size);

//Recursive Quicksort
void Quicksortr(Card deck[], uint left, uint right);

//Linear Search - return index of key in deck, or -1
int SeqSearch(Card key, Card deck[], uint size);

//Binary Search - return index of key in deck, or -1
int BinSearch(Card key, Card deck[], uint beginning, uint end);

#endif
