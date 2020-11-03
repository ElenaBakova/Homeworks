#include "List.h"
#include <stdlib.h>
#include <stdbool.h>

typedef struct ListElement {
	int position;
	struct ListElement* next;
} ListElement;

typedef struct List {
	ListElement* head;
	ListElement* tail;
} List;

int getThePosition(List *list)
{
	return list->head->position;
}

void nextItem(List* list)
{
	list->head = list->head->next;
}

bool isEmpty(List* list)
{
	return list->tail == list->head;
}

List* initListItem(int position)
{
	ListElement *listItem = malloc(sizeof(ListElement));
	if (listItem == NULL) {
		return NULL;
	}
	listItem->position = position;
	listItem->next = listItem;
	List* list = malloc(sizeof(List));
	if (list == NULL) {
		return NULL;
	}
	list->head = listItem;
	list->tail = listItem;
	return list;
}

void addItem(List* list, const int position)
{
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	newElement->position = position;
	newElement->next = list->head;
	list->tail->next = newElement;
	list->tail = newElement;
	return;
}

bool removePosition(List* list, const int position)
{
	if (isEmpty(list))
	{
		return true;
	}
	ListElement* pointer = list->head;
	if (pointer->position == position)
	{
		list->head = list->head->next;
		list->tail->next = list->head;
		return false;
	}
	while (pointer->next != list->head && pointer->next->position != position)
	{
		pointer = pointer->next;
	}
	if (pointer->next == list->head && pointer->position != position)
	{
		return true;
	}
	ListElement* oldElement = pointer;
	pointer->next = pointer->next->next;
	return false;
}

void freeList(List** list)
{
	while (!isEmpty(*list))
	{
		removePosition(*list, (*list)->head->position);
	}
	*list = NULL;
	free(*list);
}
