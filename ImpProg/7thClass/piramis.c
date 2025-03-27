#include <stdio.h>

int main() {
    int n;
    scanf("%d", &n);

    if (n < 1) {
        return 0;
    }

    for (int i = 1; i <= n; i++) {
        // Print leading spaces
        for (int j = 0; j < n - i; j++) {
            printf(" ");
        }

        // Print left half of the pyramid
        for (int j = 0; j < i; j++) {
            printf("X");
        }

        // Print gap between the two halves
        printf("  ");

        // Print right half of the pyramid
        for (int j = 0; j < i; j++) {
            printf("X");
        }

        // Move to the next line
        printf("\n");
    }

    return 0;
}