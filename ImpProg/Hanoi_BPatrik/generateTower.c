#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stdbool.h>
#include "generateTower.h"

int *GenerateTower(int N){
    srand(time(NULL));

    int *generateTower = (int*)malloc(sizeof(int)*N);

    if (generateTower == NULL)
    {
        perror("Memory allocation is failed.");
        return NULL;
    }
    
    generateTower[0] = rand() % N +1;
    for (int i = 1; i < N; i++) {
        bool newNumber = true;
        do
        {
            newNumber = true;
            int temp = rand() % N + 1;
            for (int j = 0; j < N; j++)
            {
                if (temp == generateTower[j])
                {
                    newNumber = false;
                    break;
                }
            }
            if (newNumber)
            {
                generateTower[i] = temp;
            }
        } while (!newNumber);
    }
    
    return generateTower;
}