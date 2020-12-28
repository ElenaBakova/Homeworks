#pragma once
#include <stdbool.h>

typedef struct ListElement ListElement;

typedef struct ListElement* Position;

typedef struct List List;

// Returns element in the head of the list
Position getFirst(List* list);

// Changes pointer to the next element
Position nextItem(Position position);

// Returns true if pointer reached end of the list
bool isEnd(Position position);

// Returns value by position
char* getValue(Position position);

// Returns frequency by position
int getFrequency(Position position);

// Returns 0 if list is empty, list length otherwise
int getListLength(List* list);

// Makes a new empty list
List* makeList(void);

// Add new element into its position or increases frequency. Returns 'true' if new item was added in the list
bool addItem(List* list, char* value);

// Removes elment from the list. Recieves value of the element
bool removeValue(List* list, char* value);

// Returns 'true' if list is empty
bool isEmpty(List* list);

// Removes whole list
void freeList(List** list);