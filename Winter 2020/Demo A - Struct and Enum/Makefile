CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o chess.o
	$(CC) main.o chess.o -o chess

main.o: main.c chess.h
	$(CC) $(CFLAGS) -c main.c

chess.o: chess.c chess.h
	$(CC) $(CFLAGS) -c chess.c

clean:
	rm -f *.o *~ chess

debug: all
	cgdb ./chess

ddd: all
	ddd ./chess
