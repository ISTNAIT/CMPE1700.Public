#ifndef DICEH
#pragma once

typedef enum die
{
	One = 1,
	Two,
	Three,
	Four,
	Five,
	Six
}Die;

typedef struct dice
{
	Die Die1;
	Die Die2;
}Dice;

char * GetDieName(Die d, char * buffer);
char * GetDiceName(Dice dc, char * buffer);
Dice * SortDice(Dice * dice, int length);
int OutofOrder(Dice Roll1, Dice Roll2);
void Swap(Dice * dice, int x, int y);



#endif