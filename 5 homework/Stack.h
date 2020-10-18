#pragma once
#include <stdbool.h>

// Pushes new element
struct StackElement* push(struct StackElement* head, int value);

// Removes top elment from stack. Returns its value
int pop(struct StackElement** head);

// Returns 'true' if stack is emty
bool empty(struct StackElement* head);

// Removes all stack
void freeStack(struct StackElement** head);