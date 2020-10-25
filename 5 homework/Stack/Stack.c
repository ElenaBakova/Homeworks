#include "Stack.h"
#include <stdlib.h>
#include <stdbool.h>

StackElement* push(StackElement* head, int value)
{
	StackElement* newElement = malloc(sizeof(StackElement));
	if (newElement == NULL)
	{
		return NULL;
	}
	newElement->value = value;
	newElement->next = head;
	head = newElement;
	return head;
}

int pop(StackElement** head)
{
	if (*head == NULL)
	{
		return 0;
	}
	int value = (*head)->value;
	StackElement* oldElement = *head;
	*head = (*head)->next;
	free(oldElement);
	return value;
}

bool empty(StackElement* head)
{
	return head == NULL;
}

void freeStack(StackElement** head)
{
	while (!empty(*head))
	{
		pop(head);
	}
}