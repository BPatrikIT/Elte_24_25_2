#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

void uploadData(int size, int* tempArray){
    for (int i = 0; i < size; i++)
    {
        tempArray[i] = i*2;
    }
}

void writeOut(int* writeArray, int size){
    for (int i = 0; i < size; i++)
    {
        printf("%d: %d\n", i, writeArray[i]);
    }
    printf("\n\n");
}

bool memoryAllocationTest(int* checkArray){
    if (checkArray != NULL)
    {
        printf("The memory was allocated successfully!\n");
        return true;
    } else
    {
        printf("The memory was not allocated succesfully!\n");
        return false;
    }
}

int main(){

    //Memory Allocation
    int numItems = 10;
    int* myArray = malloc(numItems * sizeof(int));

    //Checking if the memory allocation was correct.
    memoryAllocationTest(myArray);

    uploadData(numItems, myArray);
    writeOut(myArray, numItems);

    //Upload data to the Array
    for (int i = 0; i < numItems; i++)
    {
        myArray[i] = i;
    }
    writeOut(myArray, numItems);

    //Realloc
    for (int i = numItems; i < numItems*2; i++)
    {
        int * tmp = realloc(myArray, (numItems + 1) * sizeof(int));
        if (memoryAllocationTest(tmp))
        {
            myArray = tmp;
            myArray[i] = i;
            numItems++;
        }
    }

    writeOut(myArray, numItems / sizeof(myArray[0]));

    //Free up arrays
    free(myArray);
    return 0;
}