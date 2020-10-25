#pragma once
#include <stdbool.h>

typedef struct StackElement {
	int value;
	struct StackElement* next;
} StackElement;

// Pushes new element
struct StackElement* push(StackElement* head, int value);

// Removes top elment from stack. Returns its value
int pop(StackElement** head);

// Returns 'true' if stack is emty
bool empty(StackElement* head);

// Removes all stack
void freeStack(StackElement** head);