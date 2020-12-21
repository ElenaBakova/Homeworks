#include "List.h"
#include <stdlib.h>
#include <stdbool.h>

typedef struct ListElement {
	int value;
	int length;
	struct ListElement* next;
} ListElement;

typedef struct List {
	ListElement* head;
} List;

Position getFirst(List* list)
{
	if (list == NULL)
	{
		return NULL;
	}
	return list->head;
}

Position nextItem(Position position)
{
	return position->next;
}

bool isEnd(Position position)
{
	return position == NULL;
}

int getValue(Position position)
{
	return position->value;
}

bool isEmpty(List* list)
{
	return (list == NULL || list->head == NULL);
}

int getTheValue(List *list)
{
	if (isEmpty(list))
	{
		return -1;
	}
	return list->head->value;
}

int getLength(List* list)
{
	if (isEmpty(list))
	{
		return -INT_MAX;
	}
	return list->head->length;
}

void nextItem(List* list)
{
	if (!isEmpty(list))
	{
		list->head = list->head->next;
	}
}

int findValue(List* list, int value)
{
	if (isEmpty(list))
	{
		return -INT_MAX;
	}
	ListElement* current = list->head;
	while (current != NULL && current->value != value)
	{
		current = current->next;
	}
	if (current != NULL && current->value == value)
	{
		return current->length;
	}
	return -INT_MAX;
}

void mergeLists(List* destination, List* source, int destinationIndex, int sourceIndex)
{
	removeValue(destination, sourceIndex);
	addItem(destination, sourceIndex, INT_MAX);
	removeValue(source, destinationIndex);
	ListElement* current = source->head;
	while (!isEmpty(source))
	{
		int destinationLength = findValue(destination, current->value);
		if (destinationLength == -INT_MAX)
		{
			addItem(destination, current->value, current->length);
		}
		else if (destinationLength > current->length && destinationLength != INT_MAX)
		{
			removeValue(destination, current->value);
			addItem(destination, current->value, current->length);
		}
		removeValue(source, current->value);
		current = source->head;
	}
}

List* makeList(void)
{
	return calloc(1, sizeof(List));
}

void addItem(List* list, const int value, const int length)
{
	if (list == NULL)
	{
		list = makeList();
	}
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	if (list->head == NULL)
	{
		newElement->value = value;
		newElement->length = length;
		newElement->next = NULL;
		list->head = newElement;
		return;
	}
	ListElement* pointer = list->head;
	while (pointer->next != NULL && pointer->next->length < length)
	{
		pointer = pointer->next;
	}
	newElement->value = value;
	newElement->length = length;
	if (pointer == list->head && pointer->length > length)
	{
		newElement->next = list->head;
		list->head = newElement;
		return;
	}
	newElement->next = pointer->next;
	pointer->next = newElement;
}

bool removeValue(List* list, const int value)
{
	if (list->head == NULL)
	{
		return true;
	}
	ListElement* pointer = list->head;
	if (pointer->value == value)
	{
		list->head = list->head->next;
		free(pointer);
		return false;
	}
	while (pointer->next != NULL && pointer->next->value != value)
	{
		pointer = pointer->next;
	}
	if (pointer->next == NULL && pointer->value != value)
	{
		return true;
	}
	if (pointer->next != NULL) {
		ListElement* oldElement = pointer->next;
		pointer->next = pointer->next->next;
		free(oldElement);
	}
	else {
		pointer = NULL;
	}
	return false;
}

void freeList(List** list)
{
	while (!isEmpty(*list))
	{
		removeValue(*list, (*list)->head->value);
	}
	free(*list);
	*list = NULL;
}