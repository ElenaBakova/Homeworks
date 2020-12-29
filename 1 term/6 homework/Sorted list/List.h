#pragma once
#include <stdbool.h>

typedef struct ListElement ListElement;

typedef struct ListElement* Position;

typedef struct List List;

<<<<<<< HEAD:6 homework/Merge sort/List.h
// Returns list size
int getListSize(List* list);

// Returns head of the list
=======
// Returns element int the head of the list
>>>>>>> master:1 term/6 homework/Sorted list/List.h
Position getFirst(List* list);

// Changes pointer to the next element
Position nextItem(Position position);

// Returns true if pointer reached end of the list
bool isEnd(Position position);

<<<<<<< HEAD:6 homework/Merge sort/List.h
// Returns name in the position
char* getName(Position position);

// Returns number in the position
char* getNumber(Position position);
=======
// Returns value by position
int getValue(Position position);
>>>>>>> master:1 term/6 homework/Sorted list/List.h

// Makes a new list
List* makeList(void);

// Add new element into its position
void addItem(List* list, const int value);

// Removes elment from the list. Recieves value of the element
bool removeValue(List* list, const int value);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Removes all list
void freeList(List** list);

// Prints all list
void printList(List* list);