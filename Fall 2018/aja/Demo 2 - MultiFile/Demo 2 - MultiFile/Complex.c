#include "Complex.h"
#include <math.h>


double magnitude(Compl c)
{
	return (sqrt(c.real*c.real + c.imag*c.imag));
}

Compl conjugate(Compl c)
{
	c.imag = -c.imag;
	return c;
}