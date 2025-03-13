#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 10
#define MIN_MINES 3
#define MAX_MINES 30

void printBoard(int board[SIZE][SIZE], int revealed[SIZE][SIZE]) {
    printf("  ");
    for (int i = 0; i < SIZE; i++) {
        printf("%d ", i);
    }
    printf("\n");

    for (int i = 0; i < SIZE; i++) {
        printf("%c ", 'A' + i);
        for (int j = 0; j < SIZE; j++) {
            if (revealed[i][j]) {
                printf("%d ", board[i][j]);
            } else {
                printf(". ");
            }
        }
        printf("\n");
    }
}

void placeMines(int board[SIZE][SIZE], int numMines) {
    srand(time(NULL));
    int placedMines = 0;

    while (placedMines < numMines) {
        int row = rand() % SIZE;
        int col = rand() % SIZE;

        if (board[row][col] == 0) {
            board[row][col] = -1;
            placedMines++;
        }
    }
}

void fillNumbers(int board[SIZE][SIZE]) {
    int dx[] = {-1, -1, -1, 0, 0, 1, 1, 1};
    int dy[] = {-1, 0, 1, -1, 1, -1, 0, 1};

    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            if (board[i][j] == -1) continue;

            int mineCount = 0;
            for (int k = 0; k < 8; k++) {
                int ni = i + dx[k];
                int nj = j + dy[k];

                if (ni >= 0 && ni < SIZE && nj >= 0 && nj < SIZE && board[ni][nj] == -1) {
                    mineCount++;
                }
            }
            board[i][j] = mineCount;
        }
    }
}

int main(int argc, char *argv[]) {
    if (argc != 2) {
        printf("Usage: %s <number_of_mines>\n", argv[0]);
        return 1;
    }

    int numMines = atoi(argv[1]);
    if (numMines < MIN_MINES || numMines > MAX_MINES) {
        printf("Number of mines must be between %d and %d\n", MIN_MINES, MAX_MINES);
        return 1;
    }

    int board[SIZE][SIZE] = {0};
    int revealed[SIZE][SIZE] = {0};

    placeMines(board, numMines);
    fillNumbers(board);

    while (1) {
        printBoard(board, revealed);

        char input[3];
        printf("Enter coordinates (e.g., A9): ");
        scanf("%2s", input);

        int row = input[0] - 'A';
        int col = input[1] - '0';

        if (row < 0 || row >= SIZE || col < 0 || col >= SIZE) {
            printf("Invalid coordinates. Try again.\n");
            continue;
        }

        if (board[row][col] == -1) {
            printf("Boom! You hit a mine. Game over.\n");
            break;
        }

        revealed[row][col] = 1;

        int allRevealed = 1;
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                if (board[i][j] != -1 && !revealed[i][j]) {
                    allRevealed = 0;
                    break;
                }
            }
            if (!allRevealed) break;
        }

        if (allRevealed) {
            printf("Congratulations! You've revealed all safe squares.\n");
            break;
        }
    }

    return 0;
}