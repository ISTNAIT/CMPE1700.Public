CC=gcc
CFLAGS=-g -Wall -O2

all:main

main: main.o pointers.o
	$(CC) main.o pointers.o -o mallocdemo

main.o: main.c pointers.h
	$(CC) $(CFLAGS) -c main.c

pointers.o: pointers.c pointers.h
	$(CC) $(CFLAGS) -c pointers.c

clean:
	rm -f *.o *~ mallocdemo

debug: all
	cgdb mallocdemo

ddd: all
	ddd mallocdemo
