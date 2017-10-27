CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o perm.o
	$(CC) main.o perm.o -o perm

main.o: main.c perm.c perm.h
	$(CC) $(CFLAGS) -c main.c

perm.o: perm.c perm.h
	$(CC) $(CFLAGS) -c perm.c

clean:
	rm -f *.o *~ perm

debug: all
	cgdb ./perm

ddd: all
	ddd ./perm
