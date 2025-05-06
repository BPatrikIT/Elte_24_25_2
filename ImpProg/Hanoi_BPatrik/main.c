#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include "generateTower.h"
#include "drawTower.h"

bool checkForWin(int *tower3, int diskNumber) {
    // Check if all disks are in tower 3 in the correct order
    for (int i = 0; i < diskNumber; i++) {
        if (tower3[i] != diskNumber - i) { // Ensure the largest disk is at the bottom
            return false;
        }
    }
    return true;
}

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
        while (getchar() != '\n'); // flush the newline from stdin
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
    int *tower2 = (int*)calloc(diskNumber, sizeof(int));  // Initialized to zero
    int *tower3 = (int*)calloc(diskNumber, sizeof(int));

    printf("For exiting the game, please press 'q' or 'Q'.\n");
    printf("For moving the disks, please enter the tower numbers.\n");
    printf("The first number is the source tower, and the second number is the destination tower.\n\n");
    printf("\n");
    printf("Game Rules:\n");
    printf("1. Move the disks from tower 1 to tower 3 using tower 2 as an auxiliary.\n");
    printf("2. You can only move one disk at a time.\n");
    printf("3. A disk can only be placed on top of a larger disk.\n");
    printf("4. The game is won when all disks are moved to tower 3.\n\n");
    printf("\nGood Luck & Have Fun!\n\n");

    printf("Tower 1: \n\n");
    drawTower(tower1, diskNumber); // Draw the initial state of the tower
    printf("\nTower 2: \n\n");
    drawTower(tower2, diskNumber); // Draw the initial state of the tower
    printf("\nTower 3: \n\n");
    drawTower(tower3, diskNumber); // Draw the initial state of the tower

    //Game Loop
    // The game loop continues until the user wins or exits
    int steps = 0; // Initialize the number of steps taken
    do
    {
        char input[10];
        printf("\n\nEnter the tower numbers (e.g., 1 2): ");
        fflush(stdin); // Clear the input buffer to avoid leftover characters
        fgets(input, sizeof(input), stdin); // Read user input

        if (input[0] == 'q' || input[0] == 'Q') {
            printf("Exiting the game.\n");
            break; // Exit the loop if 'q' or 'Q' is entered
        }

        int fromTower, toTower;
        sscanf(input, "%d %d", &fromTower, &toTower); // Parse the input

        // Validate tower numbers
        if (fromTower < 1 || fromTower > 3 || toTower < 1 || toTower > 3) {
            printf("\nInvalid tower numbers. Please enter numbers between 1 and 3.\n");
            continue; // Skip to the next iteration of the loop
        }

        // Move the disk from one tower to another
        int *sourceTower = (fromTower == 1) ? tower1 : (fromTower == 2) ? tower2 : tower3;
        int *destTower = (toTower == 1) ? tower1 : (toTower == 2) ? tower2 : tower3;

        int sourceIndex = diskNumber - 1;
        while (sourceIndex >= 0 && sourceTower[sourceIndex] == 0) {
            sourceIndex--; // Find the top disk in the source tower
        }
        if (sourceIndex < 0) {
            printf("No disks to move from tower %d.\n", fromTower);
            continue; // Skip to the next iteration if no disks are available
        }

        int diskToMove = sourceTower[sourceIndex]; // Get the disk to move
        sourceTower[sourceIndex] = 0; // Remove the disk from the source tower
        int destIndex = 0;
        while (destIndex < diskNumber && destTower[destIndex] != 0) {
            destIndex++; // Find the first empty position in the destination tower
        }
        if (destIndex == diskNumber) {
            printf("No space to move the disk to tower %d.\n", toTower);
            sourceTower[sourceIndex] = diskToMove; // Put the disk back in the source tower
            continue; // Skip to the next iteration if no space is available
        }

        // Check if the move is valid (cannot place a bigger disk on a smaller one)
        if (destIndex > 0 && destTower[destIndex - 1] < diskToMove) {
            printf("Invalid move: Cannot place disk %d on top of smaller disk %d.\n", diskToMove, destTower[destIndex - 1]);
            sourceTower[sourceIndex] = diskToMove; // Put the disk back in the source tower
            continue; // Skip to the next iteration if the move is invalid
        }

        destTower[destIndex] = diskToMove; // Place the disk in the destination tower
        // Draw the updated state of the towers
        printf("\n\nTower 1: \n");
        drawTower(tower1, diskNumber); // Draw the updated state of the tower
        printf("\n\nTower 2: \n");
        drawTower(tower2, diskNumber); // Draw the updated state of the tower
        printf("\n\nTower 3: \n");
        drawTower(tower3, diskNumber); // Draw the updated state of the tower
        printf("\nMoved disk %d from tower %d to tower %d.", diskToMove, fromTower, toTower);
        steps++; // Increment the number of steps taken
        if (checkForWin(tower3, diskNumber)) {
            printf("\n\nCongratulations! You have won the game!\n\n");
            printf("All disks are moved to tower 3.\n\n");
            printf("You have completed the game with %d disks in %d steps.\n\n", diskNumber, steps);
            printf("Thank you for playing!\n\n");
            printf("Exiting the game.\n\n");
            // Free the allocated memory before exiting
            free(tower1);
            free(tower2);
            free(tower3);
            return 0; // Exit the program successfully
        }
    } while (1); // Infinite loop for the game
    
    /*
    //Test
    printf("\n\nDebugging Test\n\n");
    for (int i = diskNumber-1; i >= 0; i--)
    {
        printf("%d\n", tower1[i]);
    }
    */
    
    //Free Up the Memory
    free(tower1);
    free(tower2);
    free(tower3);
    return 0;
}