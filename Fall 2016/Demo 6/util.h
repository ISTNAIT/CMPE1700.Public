#ifndef UTILH
#define UTILH
#include "cards.h"

typedef unsigned int uint;

//Fisher-Yates Shuffle
void Shuffle(Card deck[], uint size);

//Selection Sort
void Sort(Card deck[], uint size);

#endif
