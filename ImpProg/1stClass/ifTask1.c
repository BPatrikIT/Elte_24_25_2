#include <stdio.h>
#include <string.h>

#define NAMESIZE 50

int main() {

    char name[NAMESIZE];
    int age;
    printf("Please enter your name: ");
    fgets(name, sizeof(name), stdin);
    printf("Please enter your age: ");
    scanf("%i", &age);
    
    size_t len = strlen(name);
    if (len > 0 && name[len-1] == '\n')
    {
        name[len-1] = '\0';
    }

    printf("Name: %s, and age: %i\n", name, age);
    

    return 0;
}