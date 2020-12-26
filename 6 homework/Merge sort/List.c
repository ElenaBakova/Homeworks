#include "List.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <string.h>

typedef struct ListElement {
	char* name;
	char* number;
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

char* getValue(Position position)
{
	return position->name;
}

bool isEmpty(List* list)
{
	return (list == NULL || list->head == NULL);
}


List* makeList(void)
{
	return calloc(1, sizeof(List));
}

char* copy(char* string)
{
	char* newString = malloc(strlen(string) + 1);
	if (newString == NULL)
	{
		return NULL;
	}
	strcpy(newString, string);
	return newString;
}

void addItem(List* list, char* name, char* number)
{
	if (list == NULL)
	{
		return;
	}
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	newElement->name = copy(name);
	newElement->number = copy(number);
	if (list->head == NULL)
	{
		newElement->next = NULL;
		list->head = newElement;
		return;
	}
	newElement->next = list->head;
	list->head = newElement;
}

bool removeValue(List* list, const char* name)
{
	if (isEmpty(list))
	{
		return true;
	}
	ListElement* pointer = list->head;
	if (strcmp(pointer->name, name) == 0)
	{
		list->head = list->head->next;
		free(pointer->name);
		free(pointer->number);
		free(pointer);
		return false;
	}
	while (pointer->next != NULL && strcmp(pointer->next->name, name) != 0)
	{
		pointer = pointer->next;
	}
	if (pointer->next == NULL && strcmp(pointer->name, name) != 0)
	{
		return true;
	}
	if (pointer->next != NULL)
	{
		ListElement* oldElement = pointer->next;
		pointer->next = pointer->next->next;
		free(oldElement->name);
		free(oldElement->number);
		free(oldElement);
	}
	return false;
}

void freeList(List** list)
{
	while (!isEmpty(*list))
	{
		removeValue(*list, (*list)->head->name);
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
		printf("%s - %s", pointer->name, pointer->number);
		pointer = pointer->next;
	}
}
