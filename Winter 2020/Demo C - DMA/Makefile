CC=gcc
CFLAGS=-g -Wall

all:main

main: main.o dma.o
	$(CC) main.o dma.o -o dma

main.o: main.c dma.h
	$(CC) $(CFLAGS) -c main.c

dma.o: dma.c dma.h
	$(CC) $(CFLAGS) -c dma.c

clean:
	rm -f *.o *~ dma

debug: all
	cgdb ./dma

ddd: all
	ddd ./dma
