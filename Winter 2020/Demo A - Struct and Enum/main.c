#include <stdlib.h>
#include <stdio.h>
#include "chess.h"

int main(int argc, char* argv)
{
	//Reserve memory for an array of Pieces and a board
	ChessPiece Pieces[32];
	wchar_t Board[64] = {0};
	//Add the pieces
	GetPieces(Pieces);
	PopulateBoard(Pieces,Board);
	PrintBoard(Board);

	return EXIT_SUCCESS;
}