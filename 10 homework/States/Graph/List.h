#pragma once
#include <stdbool.h>

typedef struct List List;

// Returns value of the head item
int getTheValue(List *list);

// Returns length of the head item
int getLength(List* list);

// Changes pointer to the next item
void nextItem(List* list);

// Makes a new list
List* makeList(void);

// Add new element into its position
void addItem(List* list, const int value, const int length);

// Removes elment from the list. Recieves value of the element
bool removeValue(List* list, const int value);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Removes all list
void freeList(List** list);