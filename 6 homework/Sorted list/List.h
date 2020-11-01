#pragma once
#include <stdbool.h>

typedef struct ListElement {
	int value;
	//int position;
	struct ListElement* next;
} ListElement;

// Makes a new list
ListElement* initListItem(int value);

// Add new element into its position
void addItem(ListElement** head, const int value);

// Removes elment from the list. Recieves value of the element
bool pop(ListElement** head, const int value);

// Returns 'true' if stack is emty
bool isEmpty(ListElement* head);

// Removes all stack
void freeList(ListElement** head);

// Prints all list
void printList(ListElement* head);