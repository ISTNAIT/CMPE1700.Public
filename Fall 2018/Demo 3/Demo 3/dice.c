#include "dice.h"
#define _CRT_SECURE_NO_WARNINGS
#pragma warning(disable:4996)

char * GetName(Dice d, char * szbuffer)
{
	switch (GetValue(d))
	{
	case 2: strncpy(szbuffer, "Snake Eyes", DICEBUFFERSIZE); break;
	case 3: strncpy(szbuffer, "Three", DICEBUFFERSIZE); break;
	case 4: strncpy(szbuffer, "Four", DICEBUFFERSIZE); break;
	case 5: strncpy(szbuffer, "Five", DICEBUFFERSIZE); break;
	case 6: strncpy(szbuffer, "Six", DICEBUFFERSIZE); break;
	case 7: strncpy(szbuffer, "Seven", DICEBUFFERSIZE); break;
	case 8: strncpy(szbuffer, "Eight", DICEBUFFERSIZE); break;
	case 9: strncpy(szbuffer, "Nine", DICEBUFFERSIZE); break;
	case 10: strncpy(szbuffer, "Ten", DICEBUFFERSIZE); break;
	case 11: strncpy(szbuffer, "Eleven", DICEBUFFERSIZE); break;
	case 12: strncpy(szbuffer, "Boxcars", DICEBUFFERSIZE); break;
	default: strncpy(szbuffer, "Great.  You broke the universe.  Good job", 
		DICEBUFFERSIZE); break;
	}
	return szbuffer;
}

int GetValue(Dice d)
{
	return d.First + d.Second;
}

Dice Roll()
{ 
	Dice d;
	d.First = rand() % 6 + 1;
	d.Second = rand() % 6 + 1;
	return d;
}