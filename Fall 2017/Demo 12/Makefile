CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o vect.o
	$(CC) main.o vect.o -o vect

main.o: main.c vect.c vect.h
	$(CC) $(CFLAGS) -c main.c

vect.o: vect.c vect.h
	$(CC) $(CFLAGS) -c vect.c

clean:
	rm -f *.o *~ vect

debug: all
	cgdb ./vect

ddd: all
	ddd ./vect
