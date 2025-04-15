#ifndef BOX_H
#define BOX_H

typedef struct Box {
    int weight;
    struct Box* next;
} Box;

void initialize();
int isEmpty();
int peek();
void push(int weight);
void pop();
void copyTop();

#endif