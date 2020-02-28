#pragma once
#ifndef CHESSH
#define CHESSH
#include <ctype.h>
#include <wchar.h>

typedef unsigned int uint;
typedef enum { white, black } Colour;
typedef enum {
	pawn = 1,
	rook,
	bishop,
	knight,
	queen,
	king
} PieceType;

typedef struct
{
	Colour colour;
	PieceType name;
	uint rank;
	char file;
	wchar_t symbol;
} ChessPiece;

//Look-up table for piece names.
static char * const Names[] = { "Pawn","Rook","Bishop","Knight", "Queen", "King" };
//Look-up table for piece colours.
static char * const Colours[] = { "White","Black" };


int ReinFieldValue(ChessPiece cp); //Scoring
char* Name(ChessPiece cp); //Get string name for a peice
char* ColourName(ChessPiece cp); //Get string name for colour.
void PopulateBoard(ChessPiece Pieces[], wchar_t Board[]);
void PrintBoard(wchar_t Board[]);
#endif
