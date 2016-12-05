CC=gcc
CFLAGS=-g -Wall

all: main

demo9: main

main: util.o list.o main.o
	$(CC) main.o list.o util.o -o demo9

main.o: main.c list.h util.h
	$(CC) $(CFLAGS) -c main.c

list.o: list.c list.h
	$(CC) $(CFLAGS) -c list.c

util.o: util.c util.h
		$(CC) $(CFLAGS) -c util.c

clean:
	rm -f *.o *~ demo9

debug: all
	cgdb demo9

ddd: all
	ddd demo9
