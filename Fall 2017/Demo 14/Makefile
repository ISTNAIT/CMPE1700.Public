CC=gcc
CFLAGS=-g -Wall

all: d14

d14: main.o staque.o ll.o
	$(CC) main.o staque.o ll.o -o d14

main.o: main.c staque.h ll.h
	$(CC) $(CFLAGS) -c main.c

staque.o: staque.c staque.h
	$(CC) $(CFLAGS) -c staque.c

ll.o: ll.c ll.h
	$(CC) $(CFLAGS) -c ll.c

clean:
	rm -f *.o *~ d14

debug: all
	cgdb ./d14

ddd: all
	ddd ./d14
