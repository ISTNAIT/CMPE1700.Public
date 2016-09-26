CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o bitwise.o
	$(CC) main.o bitwise.o -o bwdemo

main.o: main.c bitwise.c bitwise.h
	$(CC) $(CFLAGS) -c main.c

bitwise.o: bitwise.c bitwise.h
	$(CC) $(CFLAGS) -c bitwise.c

clean:
	rm -f *.o *~ bwdemo

debug: all
	cgdb bwdemo
