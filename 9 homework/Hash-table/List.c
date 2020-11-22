#include "List.h"
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

typedef struct ListElement {
	char* value;
	int frequency;
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

List* initListItem(char* value)
{
	ListElement *listItem = malloc(sizeof(ListElement));
	if (listItem == NULL)
	{
		return NULL;
	}
	listItem->value = value;
	listItem->frequency = 1;
	listItem->next = NULL;
	List* list = malloc(sizeof(List));
	if (list == NULL)
	{
		return NULL;
	}
	list->head = listItem;
	return list;
}

void addItem(List* list, const char * value, const int frequency)
{
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	newElement->value = value;
	newElement->frequency = frequency;
	newElement->next = list->head->next;
	list->head->next = newElement;
	return;
}

bool removeValue(List* list, const char* value)
{
	if (list->head == NULL)
	{
		return true;
	}
	ListElement* pointer = list->head;
	if (pointer->value == value)
	{
		list->head = list->head->next;
		return false;
	}
	while (pointer->next != NULL && strcmp(pointer->next->value, value) != 0)
	{
		pointer = pointer->next;
	}
	if (pointer->next == NULL && strcmp(pointer->value, value) != 0)
	{
		return true;
	}
	ListElement* oldElement = pointer;
	if (pointer->next != NULL)
	{
		pointer->next = pointer->next->next;
	}
	else
	{
		pointer = NULL;
	}
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
	*list = NULL;
	free(*list);
}

void printList(List *list)
{
	List listCopy = *list;
	if (isEmpty(&listCopy))
	{
		printf("List is empty\n");
		return;
	}
	while (!isEmpty(&listCopy))
	{
		printf("%i ", listCopy.head->value);
		listCopy.head = listCopy.head->next;
	}
}
