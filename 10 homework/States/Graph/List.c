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
		return INT_MAX;
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

List* makeList(void)
{
	List* list = calloc(1, sizeof(List));
	return list;
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
	newElement->value = value;
	newElement->length = length;
	if (list->head == NULL)
	{
		newElement->next = NULL;
	}
	else
	{
		newElement->next = list->head;
	}
	list->head = newElement;
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