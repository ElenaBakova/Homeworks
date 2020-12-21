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

// Returns value of the head item
int getTheValue(List *list);

// Returns length of the head item
int getLength(List* list);

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