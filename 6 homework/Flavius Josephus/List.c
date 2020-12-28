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

int getPosition(Position position)
{
	return position->position;
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
	if (isEmpty(list))
	{
		list->head = newElement;
		list->head->next = newElement;
		list->tail = list->head;
		return;
	}
	list->tail->next = newElement;
	list->tail = newElement;
	list->tail->next = list->head;
}

bool removePosition(List* list, const int position)
{
	if (isEmpty(list)) 
	{
		return false;
	}
	if (list->head == list->tail)
	{
		free(list->head);
		list->head = NULL;
		list->tail = NULL;
		return true;
	}
	ListElement* pointer = list->head;
	if (pointer->position == position)
	{
		list->tail->next = list->head->next;
		list->head = list->head->next;
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
	ListElement* tail = list->tail;
	if (pointer->next->next == list->head)
	{
		free(tail);
		list->tail = pointer;
		list->tail->next = list->head;
		return true;
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
