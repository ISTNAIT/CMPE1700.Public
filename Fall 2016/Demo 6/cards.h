#ifndef CARDSH
#define CARDSH
#include <stdlib.h>
#include <stdio.h>
typedef unsigned int uint;

//Define new Suit enum
typedef enum suit {Clubs, Diamonds, Hearts, Spades} Suit;

//Define new Face enum
typedef enum face
{
  Ace = 1,
  Deuce, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
  Jack, Queen, King
} Face; // "enum face" and "Face" now same thing

typedef struct card
{
  Suit suit; //I can reuse "suit" because internal to card
  Face face; //Ditto
} Card;

//Comparisons
int equal(Card one, Card two);
int lessthan(Card one, Card two);

//Take a deck of 52 cards and set them to the appropriate
//52 distinct cards
void PopulateDeck(Card deck[]);

//Create a populatated deck of 52 cards on the heap
Card * AllocateDeck();
Card RandomCard();
void PrintCard(Card c);
void PrintCards(Card deck[], uint size);
void SwapCards(Card deck[], uint first, uint second);
uint FindSmallest(Card deck[], uint first, uint last);

#endif
