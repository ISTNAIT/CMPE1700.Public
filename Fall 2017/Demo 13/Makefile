CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o ll.o
	$(CC) main.o ll.o -o ll

main.o: main.c ll.c ll.h
	$(CC) $(CFLAGS) -c main.c

ll.o: ll.c ll.h
	$(CC) $(CFLAGS) -c ll.c

clean:
	rm -f *.o *~ ll

debug: all
	cgdb ./ll

ddd: all
	ddd ./ll
