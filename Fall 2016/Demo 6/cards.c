#include "cards.h"
#include <stdlib.h>
#include <stdio.h>

//Populates a deck of 52 cards.
void PopulateDeck(Card deck[])
{
  int i = 0; //Index
  for(Suit s = Clubs; s <= Spades; s++)
  {
    for (Face f = Ace; f <= King; f++)
    {
      deck[i].suit=s;
      deck[i].face=f;
      i++;
    }
  }
}

//Create a deck on the heap
Card * AllocateDeck()
{
  Card * deck = malloc(sizeof(Card) * 52);
  if(deck) PopulateDeck(deck);
  return deck;
}

void PrintCard(Card c)
{
  //Print one character of the Face
  switch(c.face)
  {
    case Ace:
    printf("A"); break;
    case King:
    printf("K"); break;
    case Queen:
    printf("Q"); break;
    case Jack:
    printf("J"); break;
    case Ten:
    printf("T"); break;
    default:
    printf("%d",c.face); break;
  }

  switch(c.suit)
  {
    case Clubs:
    printf("C"); break;
    case Diamonds:
    printf("D"); break;
    case Hearts:
    printf("H"); break;
    case Spades:
    printf("S"); break;
  }
}

//Print a set of cards on one line
void PrintCards(Card deck[], uint size)
{
  for(int i = 0 ; i < size; ++i)
  {
    PrintCard(deck[i]);
    printf(" ");
  }
  printf("\n");
}

//Generate a random card
Card RandomCard()
{
  Card c;
  c.suit = rand()%4;
  c.face = rand()%13 + 1;
  return c;
}

//Swap two cards
void SwapCards(Card deck[], uint first, uint second)
{
  if (first == second) return; //Nothing to do
  Card temp = deck[first]; //note: you can assign structs!
  deck[first] = deck[second];
  deck[second] = temp;
}

//Find the location of the smallest card in range, not including last
uint FindSmallest(Card deck[], uint first, uint last)
{
  uint smallest = first; //Just assumin'
  for (uint i = first; i < last; ++i)
  {
    if (deck[i].suit < deck[smallest].suit)
    {
      smallest = i;
    }
    else if (deck[i].suit == deck[smallest].suit)
    {
      if(deck[i].face < deck[smallest].face)
        smallest = i;
    }
  }
  return smallest;
}

int equal(Card one, Card two)
{
  if(one.face == two.face && one.suit == two.suit) return 1;
  return 0;
}

int lessthan(Card one, Card two)
{
  if(one.suit < two.suit) return 1;
  if(one.suit == two.suit && one.face < two.face) return 1;
  return 0;
}
