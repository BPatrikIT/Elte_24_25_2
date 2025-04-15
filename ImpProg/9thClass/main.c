#include <stdio.h>
#include "box.h"

int main() {
    initialize();

    push(10);
    push(20);
    push(30);

    printf("Top element: %d\n", peek());

    copyTop();
    printf("Top element after copy: %d\n", peek());

    pop();
    printf("Top element after pop: %d\n", peek());

    return 0;
}