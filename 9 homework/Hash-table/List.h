#pragma once
#include <stdbool.h>

typedef struct List List;

// Returns value of the item
int getTheValue(List *list);

// changes pointer to the next item
void nextItem(List* list);

// Makes a new list
List* initListItem(int value);

// Add new element into its position
void addItem(List* list, const int value);

// Removes elment from the list. Recieves value of the element
bool removeValue(List* list, const int value);

// Returns 'true' if stack is emty
bool isEmpty(List* list);

// Removes all stack
void freeList(List** list);

// Prints all list
void printList(List* list);