#include "List.h"
#include <stdlib.h>
#include <stdbool.h>

typedef struct ListElement {
	int value;
	struct ListElement* next;
} ListElement;

typedef struct List {
	ListElement* head;
} List;

int getTheValue(List *list)
{
	return list->head->value;
}

void nextItem(List* list)
{
	list->head = list->head->next;
}

List* makeList(void)
{
	List* list = calloc(1, sizeof(List));
	return list;
}

void addItem(List* list, const int value)
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
		newElement->next = NULL;
		list->head = newElement;
		return;
	}
	ListElement* pointer = list->head;
	while (pointer->next != NULL && pointer->next->value < value)
	{
		pointer = pointer->next;
	}
	newElement->value = value;
	if (pointer == list->head && pointer->value > value)
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

bool isEmpty(List* list)
{
	return (list == NULL || list->head == NULL);
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

void printList(List *list)
{
	ListElement* pointer = list->head;
	if (pointer == NULL)
	{
		printf("List is empty\n");
		return;
	}
	while (pointer != NULL)
	{
		printf("%i ", pointer->value);
		pointer = pointer->next;
	}
}
