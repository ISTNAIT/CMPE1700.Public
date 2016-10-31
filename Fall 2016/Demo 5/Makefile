CC=gcc
CFLAGS=-g -Wall -O2

all:main

main: main.o
	$(CC) main.o  -o enumdemo

main.o: main.c
	$(CC) $(CFLAGS) -c main.c

clean:
	rm -f *.o *~ enumdemo

debug: all
	cgdb enumdemo

ddd: all
	ddd enumdemo
