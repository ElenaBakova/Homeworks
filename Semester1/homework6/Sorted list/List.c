#include "List.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

typedef struct ListElement {
	int value;
	struct ListElement* next;
} ListElement;

typedef struct List {
	int listSize;
	ListElement* head;
	ListElement* tail;
} List;

int getListSize(List* list)
{
	return (list == NULL ? 0 : list->listSize);
}

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

<<<<<<< HEAD:6 homework/Merge sort/List.c
char* getName(Position position)
=======
int getValue(Position position)
>>>>>>> master:1 term/6 homework/Sorted list/List.c
{
	return position->value;
}

char* getNumber(Position position)
{
	return position->number;
}

bool isEmpty(List* list)
{
	return (list == NULL || list->head == NULL);
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
		return;
	}
	list->listSize++;
	ListElement* newElement = calloc(1, sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	newElement->value = value;
	if (list->head == NULL)
	{
		newElement->next = NULL;
		list->head = newElement;
		list->tail = newElement;
		return;
	}
<<<<<<< HEAD:6 homework/Merge sort/List.c
	list->tail->next = newElement;
	list->tail = newElement;
=======
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
	newElement->next = pointer->next;
	pointer->next = newElement;
>>>>>>> master:1 term/6 homework/Sorted list/List.c
}

bool removeValue(List* list, const int value)
{
	if (isEmpty(list))
	{
		return true;
	}
	ListElement* pointer = list->head;
	if (pointer->value == value)
	{
		if (list->head == list->tail)
		{
			list->tail = NULL;
		}
		list->head = list->head->next;
		free(pointer);
		list->listSize--;
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
	if (pointer->next != NULL)
	{
		ListElement* oldElement = pointer->next;
		pointer->next = pointer->next->next;
<<<<<<< HEAD:6 homework/Merge sort/List.c
		if (pointer->next == NULL)
		{
			list->tail = pointer;
		}
		free(oldElement->name);
		free(oldElement->number);
=======
>>>>>>> master:1 term/6 homework/Sorted list/List.c
		free(oldElement);
	}
	list->listSize--;
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

void printList(List *list)
{
	if (isEmpty(list))
	{
		printf("List is empty\n");
		return;
	}
	ListElement* pointer = list->head;
	while (pointer != NULL)
	{
<<<<<<< HEAD:6 homework/Merge sort/List.c
		printf("%s - %s\n", pointer->name, pointer->number);
=======
		printf("%i ", pointer->value);
>>>>>>> master:1 term/6 homework/Sorted list/List.c
		pointer = pointer->next;
	}
}
