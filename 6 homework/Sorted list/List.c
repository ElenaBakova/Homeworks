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

List* initListItem(int value)
{
	ListElement *listItem = malloc(sizeof(ListElement));
	if (listItem == NULL) {
		return NULL;
	}
	listItem->value = value;
	listItem->next = NULL;
	List* list = malloc(sizeof(List));
	if (list == NULL) {
		return NULL;
	}
	list->head = listItem;
	return list;
}

void addItem(List* list, const int value)
{
	if (list == NULL)
	{
		list = initListItem(value);
		return;
	}
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	ListElement* pointer = list->head;
	while (pointer->next != NULL && pointer->next->value < value)
	{
		pointer = pointer->next;
	}
	if (pointer == list->head && pointer->value > value)
	{
		newElement->next = list->head;
		list->head = newElement;
		return;
	}
	newElement->value = value;
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
	ListElement* oldElement = pointer;
	if (pointer->next != NULL) {
		pointer->next = pointer->next->next;
	}
	else {
		pointer = NULL;
	}
	free(oldElement);
	return false;
}

bool isEmpty(List* list)
{
	return list->head == NULL;
}

void freeList(List** list)
{
	while (!isEmpty(*list))
	{
		removeValue(*list, (*list)->head->value);
	}
	free((*list)->head);
	*list = NULL;
	free(list);
}

void printList(List *list)
{
	ListElement* pointer = list->head;
	if (pointer != NULL)
	{
		printf("List is empty\n");
		return;
	}
	while (!isEmpty(pointer != NULL))
	{
		printf("%i ", pointer->value);
		pointer = pointer->next;
	}
}
