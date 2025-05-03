#include <stdio.h>
#include <stdlib.h>
#include "generateTower.h"

int main(int argc, char **argv) {

    printf("Hanoi Game - by BPatrik\n");
    
    int diskNumber = 0;

    if (argc > 1 && argv[1] != NULL) {
        diskNumber = atoi(argv[1]);
    }

    while (diskNumber < 3)
    {
        printf("Please enter the disk number (Greater than 2): \n");
        scanf("%d", &diskNumber);
        if (diskNumber < 3)
        {
            printf("You have entered an incorrect value.\n");
        }
        
    }

    //Game starts
    //Initialize the towers

    int *tower1 = GenerateTower(diskNumber);  // already returns allocated memory
    if (tower1 == NULL) {
        return 1;  // Exit if memory allocation failed
    }

    //int *tower2 = (int*)calloc(diskNumber, sizeof(int));  // Initialized to zero
    //int *tower3 = (int*)calloc(diskNumber, sizeof(int));

    //Test
    for (int i = 0; i < diskNumber; i++)
    {
        printf("%d\n", tower1[i]);
    }
    
    //Free Up the Memory
    free(tower1);
    return 0;
}