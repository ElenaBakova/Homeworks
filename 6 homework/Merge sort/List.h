#pragma once
#include <stdbool.h>

typedef struct List List;

typedef struct Pair {
	char name[100];
	char number[100];
} Pair;

// Changes pointer to the next item
void nextItem(List* list);

// Makes a new list
List* initListItem(Pair pair);

// Add new element into its position
void addItem(List** list, Pair pair);

// Removes elment from the list. Recieves value of the element
bool removeItem(List* list);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Removes all list
void freeList(List** list);

// Prints all list
void printList(List* list);

// Sorts list. code = 0 - sort by number. 1 - by name
void sortList(List* list, const bool code);