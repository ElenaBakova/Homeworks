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

List* makeList()
{
	return calloc(1, sizeof(List));
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
}

bool removePosition(List* list, const int position)
{
	if (isEmpty(list)) 
	{
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
		list->tail->next = list->head;
		free(pointer);
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
	ListElement* oldElement = pointer->next;
	pointer->next = pointer->next->next;
	free(oldElement);
	return true;
}

void freeList(List** list)
{
	while (!isEmpty(*list))
	{
		removePosition(*list, (*list)->head->position);
	}
	free(*list);
	*list = NULL;
}
