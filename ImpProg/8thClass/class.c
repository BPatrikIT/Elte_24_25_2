#include <stdio.h>
#include <stdlib.h>
#include <time.h>

// Enum for student types
typedef enum {
    BSc,
    MSc,
    PhD
} Type;

// Struct for PhD-specific data
typedef struct {
    double impactFactor;
    int erdosNumber;
} PhDData;

// Union for type-specific data
typedef union {
    int totalCourses;          // BSc
    double correctedIndex;     // MSc
    PhDData phdData;           // PhD
} TypeSpecificData;

// Struct for Student
typedef struct {
    int id;
    double average;
    int age;
    Type type;
    TypeSpecificData typeData;
} Student;

// Typedef alias for Student
typedef Student Student;

// Function to initialize a Student instance with random data
Student* student_init(Type type) {
    Student* student = (Student*)malloc(sizeof(Student));
    if (!student) {
        perror("Failed to allocate memory for Student");
        exit(EXIT_FAILURE);
    }

    student->id = rand() % 1000 + 1;
    student->average = (rand() % 401) / 100.0; // Random average between 0.0 and 4.0
    student->age = rand() % 10 + 18;           // Random age between 18 and 27
    student->type = type;

    switch (type) {
        case BSc:
            student->typeData.totalCourses = rand() % 50 + 1; // Random total courses
            break;
        case MSc:
            student->typeData.correctedIndex = (rand() % 401) / 100.0; // Random corrected index
            break;
        case PhD:
            student->typeData.phdData.impactFactor = (rand() % 1001) / 100.0; // Random impact factor
            student->typeData.phdData.erdosNumber = rand() % 10 + 1;          // Random Erdős number
            break;
    }

    return student;
}

// Function to find the student with the highest average
Student* find_highest_average(Student* students[], int size) {
    if (size == 0) return NULL;

    Student* highest = students[0];
    for (int i = 1; i < size; i++) {
        if (students[i]->average > highest->average) {
            highest = students[i];
        }
    }
    return highest;
}

int main() {
    srand((unsigned int)time(NULL));

    // Create an array of Student pointers
    int numStudents = 10;
    Student* students[numStudents];

    // Initialize students with random data
    for (int i = 0; i < numStudents; i++) {
        Type type = rand() % 3; // Randomly assign a type
        students[i] = student_init(type);
    }

    // Find the student with the highest average
    Student* topStudent = find_highest_average(students, numStudents);
    if (topStudent) {
        printf("Student with highest average:\n");
        printf("ID: %d, Average: %.2f, Age: %d, Type: %d\n",
               topStudent->id, topStudent->average, topStudent->age, topStudent->type);
    }

    // Free allocated memory
    for (int i = 0; i < numStudents; i++) {
        free(students[i]);
    }

    return 0;
}