//Simple Demo of some basic UDTs

//Typedefs

#include <stdio.h>
#include <math.h>

typedef unsigned int uint;

//Enumerations

enum color
{
	red,
	green = 2,
	blue
};

typedef enum color Color;

typedef enum bool {false,true} Bool;

typedef struct point
{
	double x;
	double y;
} Point; 

char * ColorName(Color c)
{
	switch (c)
	{
	case red: return "Red";
	case green: return "Green";
	case blue: return "Blue";
	}
}

double DisttoOrigin(Point p)
{
	double x2 = pow(p.x, 2);
	double y2 = pow(p.y, 2);
	return sqrt(x2 + y2);
}

void PrintPoint(Point p)
{
	printf("The point is at (%g,%g) and %g units from the origin.\n",
		p.x, p.y, DisttoOrigin(p));
}



int main(int argc, char** argv)
{

	enum color c = blue;

	printf("Color is %d\n", c);
	printf("Color is %s\n", ColorName(c));

	Bool b = true;
	printf("b is %d\n", b);

	Point p = {3.14, 2.27 }; //Note curly braces.
	PrintPoint(p);

	fflush(stdout);
	fflush(stdin);
	fgetc(stdin);
}