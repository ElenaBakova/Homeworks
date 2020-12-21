#pragma once
#include <stdbool.h>

typedef struct ListElement ListElement;

typedef struct ListElement* Position;

typedef struct List List;

//
Position getFirst(List* list);

Position nextItem(Position position);

bool isEnd(Position position);

int getValue(Position position);

// Returns value of the item
int getTheValue(List *list);

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