#include <stdlib.h>
#include <stdio.h>
#include <time.h>
#include "staque.h"


int main(int argc, char** argv)
{
    //Testing our stack interfaces.

    //Stack based on Vector

    printf("\n---------------\nStack on Vector\n---------------\n");

    StackV vStack = {0, 0, NULL};
    printf("Pushing values from 1 to 50\n");
    for (int i = 1; i < 51; ++i)
        PushV(&vStack, i);

    printf("Vector size: %d\n", SizeV(vStack));

    printf("Value at top: %d\n", PeekV(vStack));

    for(int i = 0; i < 10; ++i)
        printf("Popping %d, ", PopV(&vStack));

    printf("\nValue at top: %d\n", PeekV(vStack));

    printf("Printing remaining values in vector, top to bottom.:\n");

    Print(&vStack, stdout);

    //Stack based on List

    printf("\n---------------\n Stack on List \n---------------\n");

    StackL lStack = NULL;
    printf("Pushing values from 1 to 50\n");
    for (int i = 1; i < 51; ++i)
        PushL(&lStack, i);

    printf("Vector size: %d\n", SizeL(lStack));

    printf("Value at top: %d\n", PeekL(lStack));

    for(int i = 0; i < 10; ++i)
        printf("Popping %d, ", PopL(&lStack));

    printf("\nValue at top: %d\n", PeekL(lStack));

    printf("Printing remaining values in list, front to back:\n");

    PrintList(lStack);


    //And now for the Queue

    //Queue based on Vector
    printf("\n---------------\nQueue on Vector\n---------------\n");

    QueueV vQueue = {0, 0, NULL};
    printf("Enqueuing values from 1 to 50\n");
    for (int i = 1; i < 51; ++i)
        EnqueueV(&vQueue, i);

    printf("Vector size: %d\n", SizeV(vQueue));

    printf("Value at front: %d\n", PeekV(vQueue));

    for(int i = 0; i < 10; ++i)
        printf("Dequeuing %d, ", DequeueV(&vQueue));

    printf("\nValue at front: %d\n", PeekV(vQueue));

    printf("Printing remaining values in vector, top to bottom:\n");

    Print(&vQueue, stdout);

    //Queue based on List
    printf("\n---------------\n Queue on List \n---------------\n");

    QueueL lQueue = NULL;
    printf("Enqueuing values from 1 to 50\n");
    for (int i = 1; i < 51; ++i)
        EnqueueL(&lQueue, i);

    printf("List size: %d\n", SizeL(lQueue));

    printf("Value at front: %d\n", PeekL(lQueue));

    for(int i = 0; i < 10; ++i)
        printf("Dequeuing %d, ", DequeueL(&lQueue));

    printf("\nValue at front: %d\n", PeekL(lQueue));

    printf("Printing remaining values list, front to back:\n");

    PrintList(lQueue);

    //Clean up toys
    if(vStack.store) free (vStack.store);
    vStack.store = NULL;

    if(lStack) Free(lStack);
    lStack = NULL;

    if(vQueue.store) free (vQueue.store);
    vQueue.store = NULL;

    if(lQueue) Free(lQueue);
    lQueue = NULL;

    return EXIT_SUCCESS;
}
