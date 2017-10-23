#include <stdlib.h>
#include <stdio.h>
#include "dice.h"

char * GetDieName(Die d, char * buffer)
{
	buffer[0] = 0; //Force to empty string
	switch (d)
	{
	case One: strcat(buffer, "One"); break;
	case Two: strcat(buffer, "Two"); break;
	case Three: strcat(buffer, "Three"); break;
	case Four: strcat(buffer, "Four"); break;
	case Five: strcat(buffer, "Five"); break;
	case Six: strcat(buffer, "Six"); break;
	default: strcat(buffer, "That die don't look right to me."); break;
	}
	return buffer;
}

char * GetDiceName(Dice dc, char * buffer)
{
	char localbuffer1[256] = "";
	char localbuffer2[256] = "";
	buffer[0] = 0;
	if (dc.Die1 + dc.Die2 == 2)
	{
		strcat(buffer, "Snake Eyes!");
		return buffer;
	}
	if (dc.Die1 + dc.Die2 == 12)
	{
		strcat(buffer, "Boxcars!");
		return buffer;
	}
	if (dc.Die1 + dc.Die2 == 7)
	{
		strcat(buffer, "Lucky Seven!");
		return buffer;
	}
	sprintf(buffer, "Roll: a %s and a %s for a total of %d.",
		GetDieName(dc.Die1,localbuffer1),GetDieName(dc.Die2,localbuffer2), (int)(dc.Die1 + dc.Die2));
	return buffer;
}