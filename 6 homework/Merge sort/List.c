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
		printf("%s -- %s\n", listCopy.head->name, listCopy.head->number);
		listCopy.head = listCopy.head->next;
	}
}

int getLength(List *list)
{
	int size = 0;
	ListElement* current = list->head;
	while (current != NULL)
	{
		size++;
		current = current->next;
	}
	return size;
}

ListElement* getRight(ListElement* head, const int length)
{
	ListElement* current = head;
	for (int i = 0; i < length; i++)
	{
		current = current->next;
	}
	return current;
}

// First string > second string -> true || fs <= ss -> false
bool compare(ListElement* first, ListElement* second, const bool code)
{
	if (code) {
		return strcmp(first->name, second->name) > 0 ? true : false;
	}
	return strcmp(first->number, second->number) > 0 ? true : false;
}

ListElement* merge(ListElement *a, ListElement *b, const bool code)
{
	ListElement* left = a;
	ListElement* right = b;
	if (left == NULL) {
		return right;
	}
	if (right == NULL) {
		return left;
	}
	left->next = NULL;
	right->next = NULL;
	ListElement* mergedLeftRight = NULL;
	if (compare(left, right, code))
	{
		mergedLeftRight = right;
		mergedLeftRight->next = merge(left, b->next, code);
	}
	else {
		mergedLeftRight = left;
		mergedLeftRight->next = merge(a->next, right, code);
	}
	return mergedLeftRight;
}

void sort(ListElement* head, const int size, const bool code)
{
	if (size < 2){
		return;
	}
	ListElement* left = head;
	ListElement* right = getRight(head, size / 2);
	sort(left, size / 2, code);
	sort(right, size - size / 2, code);
	head = merge(left, right, code);
}

void sortList(List* list, const bool code)
{
	sort(list->head, getLength(list), code);
}
