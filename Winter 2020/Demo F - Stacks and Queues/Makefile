CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o list.o vect.o staque.o
	$(CC) main.o list.o vect.o staque.o -o staque

main.o: main.c list.h vect.h staque.h
	$(CC) $(CFLAGS) -c main.c

staque.o: staque.c stack.h list.h vect.h
	$(CC) $(CFLAGS) -c main.c

list.o: list.c list.h
	$(CC) $(CFLAGS) -c list.c

vect.o: vect.c vect.h
	$(CC) $(CFLAGS) -c vect.c

clean:
	rm -f *.o *~ staque

debug: all
	cgdb ./staque

ddd: all
	ddd ./staque
