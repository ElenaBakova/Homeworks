#pragma once
#include <stdbool.h>

typedef struct List List;

// Returns value of the head item
int getTheValue(List *list);

// Returns length of the head item
int getLength(List* list);

// Changes head pointer to the next item
void nextItem(List* list);

// Makes a new empty list
List* makeList(void);

// merges two lists in one
void mergeLists(List* destination, List* source, int destinationIndex, int sourceIndex);

// Add new element into its position
void addItem(List* list, const int value, const int length);

// Removes elment from the list. Recieves value of the element
bool removeValue(List* list, const int value);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Searches for value in the list. If it's found - returns length, otherwise -INT_MAX
int findValue(List* list, int value);

// Deletes list
void freeList(List** list);