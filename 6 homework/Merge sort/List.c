#include "List.h"
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

typedef struct ListElement {
	char name[100];
	char number[100];
	struct ListElement* next;
} ListElement;

typedef struct List {
	ListElement* head;
} List;

void nextItem(List* list)
{
	list->head = list->head->next;
}

List* initListItem(Pair pair)
{
	ListElement *listItem = malloc(sizeof(ListElement));
	if (listItem == NULL) {
		return NULL;
	}
	strcpy(listItem->name, pair.name);
	strcpy(listItem->number, pair.number);
	listItem->next = NULL;
	List* list = malloc(sizeof(List));
	if (list == NULL) {
		return NULL;
	}
	list->head = listItem;
	return list;
}

void addItem(List** list, Pair pair)
{
	if (*list == NULL) {
		*list = initListItem(pair);
		return;
	}
	ListElement* newElement = malloc(sizeof(ListElement));
	if (newElement == NULL) {
		return;
	}
	strcpy(newElement->name, pair.name);
	strcpy(newElement->number, pair.number);
	newElement->next = (*list)->head->next;
	(*list)->head->next = newElement;
	return;
}

bool removeItem(List* list)
{
	if (isEmpty(list)) {
		return true;
	}
	list->head = list->head->next;
	return false;
}

bool isEmpty(List* list)
{
	return list->head == NULL;
}

void freeList(List** list)
{
	while (!removeItem(*list)) {
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
		printf("%s -- %s", listCopy.head->name, listCopy.head->number);
		listCopy.head = listCopy.head->next;
	}
}
