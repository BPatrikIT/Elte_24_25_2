#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Függvények a minimum és maximum kereséséhez
int find_min(int a, int b) {
    return (a < b) ? a : b;
}

int find_max(int a, int b) {
    return (a > b) ? a : b;
}

// Kereső algoritmus, amely függvénypointert használ
int search(int *array, int size, int (*compare)(int, int)) {
    int result = array[0];
    for (int i = 1; i < size; i++) {
        result = compare(result, array[i]);
    }
    return result;
}

int main(int argc, char *argv[]) {
    if (argc != 3) {
        fprintf(stderr, "Használat: %s <MIN|MAX> <méret>\n", argv[0]);
        return 1;
    }

    // Feltétel és méret feldolgozása
    char *condition = argv[1];
    int size = atoi(argv[2]);

    if (size <= 0) {
        fprintf(stderr, "A méretnek pozitív egész számnak kell lennie.\n");
        return 1;
    }

    // Dinamikus memóriafoglalás a tömbhöz
    int *array = (int *)malloc(size * sizeof(int));
    if (array == NULL) {
        perror("Memóriafoglalási hiba");
        return 1;
    }

    // Bemeneti adatok bekérése
    printf("Adjon meg %d egész számot:\n", size);
    for (int i = 0; i < size; i++) {
        if (scanf("%d", &array[i]) != 1) {
            fprintf(stderr, "Hibás bemenet.\n");
            free(array);
            return 1;
        }
    }

    // Keresési feltétel beállítása
    int (*compare)(int, int) = NULL;
    if (strcmp(condition, "MIN") == 0) {
        compare = find_min;
    } else if (strcmp(condition, "MAX") == 0) {
        compare = find_max;
    } else {
        fprintf(stderr, "A feltétel csak MIN vagy MAX lehet.\n");
        free(array);
        return 1;
    }

    // Keresés és eredmény kiírása
    int result = search(array, size, compare);
    printf("Eredmény: %d\n", result);

    // Memória felszabadítása
    free(array);
    return 0;
}