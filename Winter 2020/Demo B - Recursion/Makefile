CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o recursion.o
	$(CC) main.o recursion.o -o recur

main.o: main.c recursion.h
	$(CC) $(CFLAGS) -c main.c

recursion.o: recursion.c recursion.h
	$(CC) $(CFLAGS) -c recursion.c

clean:
	rm -f *.o *~ recur

debug: all
	cgdb ./recur

ddd: all
	ddd ./recur
