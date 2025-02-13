#include <stdio.h>
#include <stdbool.h>

int main(int arg, char** arg2){

    int argNumber = 0;
    bool arg1Bool = false;

    if (arg < 3)
    {
        argNumber++;
        arg1Bool = true;
    }
    
    if (arg2 != 0)
    {
        argNumber++;
    }
    
    switch (argNumber)
    {
    case 0:
        printf("There is no argument.\n");
        break;
    case 1:
        if (arg1Bool)
        {
            printf("There is an argument, and the value of the argument is: %i.\n", arg);
        } else
        {
            printf("There is an argument, and the value of the argument is: %s.\n", arg2[0]);
        }
        break;
    case 2:
        printf("There are 2 arguments, and the values are the following:\n");
        printf("Arg1: %i, Arg2: %s\n", arg, arg2[0]);
    default:
        break;
    }

    return 0;
}