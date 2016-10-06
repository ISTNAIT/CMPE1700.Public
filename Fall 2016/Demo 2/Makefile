CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o arrays.o
	$(CC) main.o arrays.o -o arraydemo

main.o: main.c arrays.h
	$(CC) $(CFLAGS) -c main.c

arrays.o: arrays.c arrays.h
	$(CC) $(CFLAGS) -c arrays.c

clean:
	rm -f *.o *~ arraydemo

debug: all
	cgdb arraydemo

ddd: all
	ddd arraydemo
