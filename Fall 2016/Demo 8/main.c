#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include "cards.h"
#include "util.h"

int main()
{
  //Initialize random number thingee
  srand(time(NULL));

  Card * deck = AllocateDeck(); //Deck on the heap
  if(!deck)
    {
      fprintf(stderr,"Error: memory allocation failure.");
      return -1;
    }

  printf("\nInitial Deck:\n" );
  PrintCards(deck,52);

  Shuffle(deck,52);
  printf("\nShuffled Deck:\n" );
  PrintCards(deck,52);

  Card key = RandomCard();
  int location = SeqSearch(key,deck,52);
  printf("Card ");
  PrintCard(key);
  printf(" is at location %d.\n",location);

  //Sort(deck,52);
  Quicksort(deck,52);
  printf("\nSorted Deck:\n" );
  PrintCards(deck,52);
  location = BinSearch(key,deck,0,51);
  printf("Card ");
  PrintCard(key);
  printf(" is at location %d.\n",location);


  if(deck)
  {
    free(deck);
    deck = NULL;
  }
  return 0;
}
