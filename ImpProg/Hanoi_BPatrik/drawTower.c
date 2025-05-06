#include <stdio.h>
#include <stdlib.h>
#include "drawTower.h"

void drawTower(int *tower, int diskNumber) {
    // Draw the tower lines
    for (int i = diskNumber-1; i >= 0; i--)
    {
        for (int j = 1; j <= (diskNumber*2)+1; j++)
        {
            if (j < (diskNumber+1) - tower[i] || j > (diskNumber + tower[i] + 1))
            {
                printf(" ");
            }
            else if (j == diskNumber+1) 
            {
                printf("|");
            } else
            {
                printf("=");
            }            
        }
        printf("\n");
    }
    
}