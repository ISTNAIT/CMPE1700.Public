//First thing: you NEED and idempotent block. Either #pragma once (which will probably work)
// or #ifndef, which definitely will.  I do both.  So will you.

#pragma once
#ifndef _COMPLEXH_
#define _COMPLEXH_

typedef struct compl{ double real; double imag; } Compl;

double magnitude(Compl);
Compl conjugate(Compl);

#endif

