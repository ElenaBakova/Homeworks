#include "Stack.h"
#include <stdlib.h>
#include <stdbool.h>

struct StackElement* push(struct StackElement* head, int value)
{
	struct StackElement* newElement = malloc(sizeof(struct StackElement));
	if (newElement == NULL)
	{
		return NULL;
	}
	newElement->value = value;
	newElement->next = head;
	head = newElement;
	return head;
}

int pop(struct StackElement** head)
{
	if (*head == NULL)
	{
		return 0;
	}
	int value = (*head)->value;
	struct StackElement* oldElement = *head;
	*head = (*head)->next;
	free(oldElement);
	return value;
}

bool empty(struct StackElement* head)
{
	return head == NULL;
}

void freeStack(struct StackElement** head)
{
	while (!empty(*head))
	{
		pop(head);
	}
}