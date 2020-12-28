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

int getValue(Position position)
{
	return position->value;
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

void addItem(List* list, const char * value, const int frequency)
{
	if (list == NULL)
	{
		return;
	}
	ListElement* newElement = calloc(1, sizeof(ListElement));
	if (newElement == NULL)
	{
		return;
	}
	newElement->value = copy(value);
	newElement->frequency = frequency;
	if (list->head == NULL)
	{
		list->head = newElement;
		return;
	}
	newElement->next = list->head->next;
	list->head->next = newElement;
	return;
}

bool removeValue(List* list, char* value)
{
	if (isEmpty(list))
	{
		return true;
	}
	ListElement* pointer = list->head;
	if (strcmp(pointer->value, value) == 0)
	{
		list->head = list->head->next;
		free(pointer);
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
	if (pointer->next != NULL)
	{
		ListElement* oldElement = pointer->next;
		pointer->next = pointer->next->next;
		free(oldElement);
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