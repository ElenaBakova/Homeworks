#pragma once
#include <stdbool.h>

typedef struct List List;
typedef struct ListElement Position;

// Returns list head
struct ListElement* getHead(List* list);

// Returns position of the item
int getThePosition(struct ListElement* list);

// Changes pointer to the next item
struct ListElement* nextItem(struct ListElement* list);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Makes a new list
List* initListItem();

// Add new element into its position
void addItem(List* list, const int position);

// Removes elment from the list. Recieves value of the element
bool removePosition(List* list, const int position);

// Removes all list
void freeList(List** list);