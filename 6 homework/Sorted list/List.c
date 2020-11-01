#include "List.h"
#include <stdlib.h>
#include <stdbool.h>

ListElement* initListItem(int value)
{
	ListElement* listItem = malloc(sizeof(ListElement));
	if (listItem == NULL) {
		return NULL;
	}
	listItem->value = value;
	listItem->next = NULL;
	return listItem;
}

void addItem(ListElement** head, const int value)
{
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	ListElement* pointer = *head;
	while (pointer->next != NULL && pointer->next->value < value)
	{
		pointer = pointer->next;
	}
	if (pointer == *head)
	{
		newElement->value = value;
		newElement->next = *head;
		*head = newElement;
		return;
	}
	newElement->value = value;
	newElement->next = pointer->next;
	pointer->next = newElement;
	return;
}

bool pop(ListElement** head, const int value)
{
	if (*head == NULL)
	{
		return true;
	}
	ListElement* pointer = *head;
	while (pointer->value != value && pointer->next != NULL && pointer->next->value != value)
	{
		pointer = pointer->next;
	}
	if (pointer->value != value)
	{
		return true;
	}
	ListElement* oldElement = *head;
	if (pointer == *head)
	{
		*head = (*head)->next;
		return false;
	}
	oldElement = pointer;
	pointer->next = pointer->next->next;
	return false;
}

bool isEmpty(ListElement* head)
{
	return head == NULL;
}

void freeList(ListElement** head)
{
	while (!isEmpty(*head))
	{
		pop(head, (*head)->value);
	}
}

void printList(ListElement* head)
{
	while (head != NULL)
	{
		printf("%i ", head->value);
		head = head->next;
	}
}
