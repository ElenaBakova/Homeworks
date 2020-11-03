#pragma once
#include <stdbool.h>

typedef struct List List;

// Returns value of the item
int getThePosition(List* list);

// Changes pointer to the next item
void nextItem(List* list);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Makes a new list
List* initListItem(int position);

// Add new element into its position
void addItem(List* list, const int position);

// Removes elment from the list. Recieves value of the element
bool removePosition(List* list, const int position);

// Removes all list
void freeList(List** list);