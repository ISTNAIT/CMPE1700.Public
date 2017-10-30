CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o recur.o
	$(CC) main.o recur.o -o recur

main.o: main.c recur.c recur.h
	$(CC) $(CFLAGS) -c main.c

recur.o: recur.c recur.h
	$(CC) $(CFLAGS) -c recur.c

clean:
	rm -f *.o *~ recur

debug: all
	cgdb ./recur

ddd: all
	ddd ./recur
