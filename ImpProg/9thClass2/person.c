#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "person.h"

void initializePerson(Person* p, const char* name, int age) {
    strcpy(p->name, name);
    p->age = (int*)malloc(sizeof(int));
    if (p->age) {
        *(p->age) = age;
    }
}

void copyPersonDeep(Person* dest, const Person* src) {
    strcpy(dest->name, src->name);
    dest->age = (int*)malloc(sizeof(int));
    if (dest->age) {
        *(dest->age) = *(src->age);
    }
}

void freePerson(Person* p) {
    if (p->age) {
        free(p->age);
        p->age = NULL;
    }
}