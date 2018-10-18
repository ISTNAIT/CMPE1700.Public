#pragma once
#ifndef _DICEH_
#define _DICEH_

#include <stdlib.h>
#include <string.h>

#define DICEBUFFERSIZE 255

typedef enum die{One=1, Two, Three, Four, Five, Six} Die;
typedef struct dice {
	Die First;
	enum die Second;
} Dice;

char * GetName(Dice,char *);
int GetValue(Dice);
Dice Roll();

#endif