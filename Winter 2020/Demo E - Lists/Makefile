CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o list.o
	$(CC) main.o list.o -o list

main.o: main.c list.h
	$(CC) $(CFLAGS) -c main.c

list.o: list.c list.h
	$(CC) $(CFLAGS) -c list.c

clean:
	rm -f *.o *~ list

debug: all
	cgdb ./list

ddd: all
	ddd ./list
