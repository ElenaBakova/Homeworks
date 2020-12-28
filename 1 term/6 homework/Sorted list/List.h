#pragma once
#include <stdbool.h>

typedef struct ListElement ListElement;

typedef struct ListElement* Position;

typedef struct List List;

// Returns element int the head of the list
Position getFirst(List* list);

// Changes pointer to the next element
Position nextItem(Position position);

// Returns true if pointer reached end of the list
bool isEnd(Position position);

// Returns value by position
int getValue(Position position);

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