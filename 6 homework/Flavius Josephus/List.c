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

ListElement* getHead(List* list)
{
	return list->head;
}

int getThePosition(ListElement *list)
{
	return list->position;
}

ListElement* nextItem(ListElement* list)
{
	return list->next;
}

bool isEmpty(List* list)
{
	return list->tail == NULL && list->head == NULL;
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
	if (newElement == NULL) {
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
	if (isEmpty(list)) {
		return false;
	}
	if (list->head == list->tail)
	{
		list->head = NULL;
		list->tail = NULL;
		return true;
	}
	ListElement* pointer = list->head;
	if (pointer->position == position)
	{
		list->head = list->head->next;
		pointer->next = NULL;
		list->tail->next = list->head;
		return true;
	}
	while (pointer->next != list->head && pointer->next->position != position)
	{
		pointer = pointer->next;
	}
	if (pointer->next == list->head && pointer->position != position)
	{
		return false;
	}
	if (pointer->next->next == list->head)
	{
		list->tail = pointer;
	}
	pointer->next = pointer->next->next;
	return true;
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
