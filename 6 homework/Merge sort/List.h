#pragma once
#include <stdbool.h>

typedef struct ListElement ListElement;

typedef struct ListElement* Position;

typedef struct List List;

// Returns list size
int getListSize(List* list);

// Returns head of the list
Position getFirst(List* list);

// Changes pointer to the next item
Position nextItem(Position position);

// Returns 'true' if position is the end of the list
bool isEnd(Position position);

// Returns name in the position
char* getName(Position position);

// Returns number in the position
char* getNumber(Position position);

// Makes a new list
List* makeList(void);

// Add new element into its position
void addItem(List* list, char* name, char* number);

// Removes elment from the list. Recieves name of the element. Returns 'true' if there was an errors
bool removeValue(List* list, const char* name);

// Returns 'true' if list is emty
bool isEmpty(List* list);

// Removes all list
void freeList(List** list);

// Prints all list
void printList(List* list);