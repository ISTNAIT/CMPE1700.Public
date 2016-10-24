CC=gcc
CFLAGS=-g -Wall -O2

all:main

main: main.o
	$(CC) main.o  -o scanfdemo

main.o: main.c
	$(CC) $(CFLAGS) -c main.c

clean:
	rm -f *.o *~ scanfdemo

debug: all
	cgdb scanfdemo

ddd: all
	ddd scanfdemo
