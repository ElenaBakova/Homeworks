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
	int listLength;
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
	return position->value;
}

int getFrequency(Position position)
{
	return position->frequency;
}

bool isEmpty(List* list)
{
	return (list == NULL || list->head == NULL);
}

int getListLength(List* list)
{
	return isEmpty(list) ? 0 : list->listLength;
}

List* makeList(void)
{
	return calloc(1, sizeof(List));
}

Position findPosition(List* list, char* value)
{
	Position pointer = getFirst(list);
	while (!isEnd(pointer) && strcmp(pointer->value, value) != 0)
	{
		pointer = nextItem(pointer);
	}
	return pointer;
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

bool addItem(List* list, char * value)
{
	if (list == NULL)
	{
		return false;
	}
	Position position = findPosition(list, value);
	if (position != NULL)
	{
		position->frequency++;
		return false;
	}
	list->listLength++;
	ListElement* newElement = calloc(1, sizeof(ListElement));
	if (newElement == NULL)
	{
		return false;
	}
	newElement->value = copy(value);
	newElement->frequency = 1;
	if (list->head == NULL)
	{
		list->head = newElement;
		return true;
	}
	newElement->next = list->head->next;
	list->head->next = newElement;
	return true;
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
		free(pointer->value);
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
		free(oldElement->value);
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