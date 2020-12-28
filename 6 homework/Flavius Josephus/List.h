#pragma once
#include <stdbool.h>

typedef struct ListElement ListElement;

typedef struct ListElement* Position;

typedef struct List List;

// Returns list head
Position getFirst(List* list);

// Returns pointer to the next item
Position nextItem(Position position);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Returns position of the element
int getPosition(Position position);

// Makes a new list
List* makeList();

// Add new element into its position
void addItem(List* list, const int position);

// Removes elment from the list. Recieves value of the element
bool removePosition(List* list, const int position);

// Removes all list
void freeList(List** list);