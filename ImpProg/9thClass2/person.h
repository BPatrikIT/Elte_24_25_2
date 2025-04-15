#ifndef PERSON_H
#define PERSON_H

typedef struct {
    char name[30];
    int* age;
} Person;

void initializePerson(Person* p, const char* name, int age);
void copyPersonDeep(Person* dest, const Person* src);
void freePerson(Person* p);

#endif