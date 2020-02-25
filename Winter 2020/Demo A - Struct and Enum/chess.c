#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
#include "chess.h"

//Populate my Pieces buffer with a complete set.
ChessPiece* GetPeices(ChessPiece* pieces)
{
	//Create an array (declared in header)
	//That contains a complete set.
	int index = 0;
	int length = 0;
	for (Colour c = white; c <= black; c++)
	{
		//Eight Pawns
		for (int i = 0; i < 8; ++i)
		{
			pieces[index++] = (ChessPiece){ c,pawn,1,'a',c ? '♟' : '♙' };
		}

		//Two each of rook, bishop, knight
		for (PieceType pt = rook; pt <= knight; ++pt)
		{
			pieces[index++] = (ChessPiece){ c,pt,1,'a','💩' };
			pieces[index++] = (ChessPiece){ c,pt,1,'a','💩' };
		}

		//One each of queen, king
		pieces[index++] = (ChessPiece){ c,queen,1,'a',c ? '♛' : '♕' };
		pieces[index++] = (ChessPiece){ c,king,1,'a',c ? '♚' : '♔' };
	}
	//Now, fix locations. 
	length = index;
	for (int i = 0; i < length; ++i)
	{
		switch (pieces[i].name)
		{
		case pawn:
			//I know I have eight pawns, first eight white, second black
			pieces[i].rank = pieces[i].colour ? 2 : 7;
			pieces[i].file = i % 8; //Fancy idiom.  Why does this work?
			break;
		case rook:
			pieces[i].symbol = pieces[i].colour ? '♖':'♜';
			pieces[i].rank = pieces[i].colour ? 1 : 8;
		default:
			fprintf(stderr, "Error: Elder gods have"
				"infested board. Aborting.\n");
			exit(EXIT_FAILURE);
		}

	}

	return Pieces;
}

int ReinFieldValue(ChessPiece cp)
{
	switch (cp.name)
	{
	case pawn: return 1;
	case rook: return 5;
	case bishop: return 3;
	case knight: return 3;
	case queen: return 9;
	case king: return 100;
	default: return 0;
	}
}


char* Name(ChessPiece cp) //Get string name for a peices
{
	return Names[cp.name];
}
char* ColourName(ChessPiece cp) //Get string name for colour.
{
	return cp.colour ? "Black" : "White";
}

