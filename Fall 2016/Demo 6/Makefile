CC=gcc
CFLAGS=-g -Wall

all: main

demo6: main

main: util.o cards.o main.o
	$(CC) main.o cards.o util.o -o demo6

main.o: main.c cards.h
	$(CC) $(CFLAGS) -c main.c

cards.o: cards.c cards.h
	$(CC) $(CFLAGS) -c cards.c

util.o: util.c util.h
		$(CC) $(CFLAGS) -c util.c

clean:
	rm -f *.o *~ demo6

debug: all
	cgdb demo6

ddd: all
	ddd demo6
