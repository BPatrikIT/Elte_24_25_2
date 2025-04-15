#include <stdio.h>
#include "person.h"

int main() {
    Person p1, p2;

    // Initialize p1
    initializePerson(&p1, "John Doe", 25);

    // Shallow copy (direct assignment)
    p2 = p1;
    printf("Shallow Copy:\n");
    printf("p1: Name = %s, Age = %d\n", p1.name, *(p1.age));
    printf("p2: Name = %s, Age = %d\n", p2.name, *(p2.age));

    // Modify p1's age
    *(p1.age) = 30;
    printf("\nAfter modifying p1's age:\n");
    printf("p1: Name = %s, Age = %d\n", p1.name, *(p1.age));
    printf("p2: Name = %s, Age = %d\n", p2.name, *(p2.age));

    // Deep copy
    Person p3;
    copyPersonDeep(&p3, &p1);
    printf("\nDeep Copy:\n");
    printf("p1: Name = %s, Age = %d\n", p1.name, *(p1.age));
    printf("p3: Name = %s, Age = %d\n", p3.name, *(p3.age));

    // Modify p1's age again
    *(p1.age) = 35;
    printf("\nAfter modifying p1's age again:\n");
    printf("p1: Name = %s, Age = %d\n", p1.name, *(p1.age));
    printf("p3: Name = %s, Age = %d\n", p3.name, *(p3.age));

    // Free allocated memory
    freePerson(&p1);
    freePerson(&p3);

    return 0;
}