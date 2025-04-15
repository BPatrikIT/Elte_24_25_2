#include <stdio.h>
#include <stdlib.h>
#include "box.h"

Box* top = NULL;

void initialize() {
    top = NULL;
}

int isEmpty() {
    return top == NULL;
}

int peek() {
    if (isEmpty()) {
        printf("Stack is empty!\n");
        return -1; // Indicate error
    }
    return top->weight;
}

void push(int weight) {
    Box* newBox = (Box*)malloc(sizeof(Box));
    if (!newBox) {
        printf("Memory allocation failed!\n");
        return;
    }
    newBox->weight = weight;
    newBox->next = top;
    top = newBox;
}

void pop() {
    if (isEmpty()) {
        printf("Stack is empty, cannot pop!\n");
        return;
    }
    Box* temp = top;
    top = top->next;
    free(temp);
}

void copyTop() {
    if (isEmpty()) {
        printf("Stack is empty, cannot copy!\n");
        return;
    }
    push(top->weight);
}