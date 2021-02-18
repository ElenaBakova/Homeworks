#include "List.h"
#include "MergeSort.h"
#include <stdlib.h>
#include <string.h>

typedef enum SortingCode {
	byName, 
	byNumber
} SortingCode;

void moveItems(List* source, List* destination,  int length)
{
	for (int i = 0; i < length; i++)
	{
		addItem(destination, getName(getFirst(source)), getNumber(getFirst(source)));
		removeValue(source, getName(getFirst(source)));
	}
}

int getCompareResult(Position first, Position second, SortingCode code)
{
	if (code == byName)
	{
		return strcmp(getName(first), getName(second));
	}
	return strcmp(getNumber(first), getNumber(second));
}

List* mergeLists(List* leftList, List* rightList, SortingCode code)
{
	List* newList = makeList();
	Position left = getFirst(leftList);
	Position right = getFirst(rightList);
	while (!isEnd(left) && !isEnd(right))
	{
		const int compareResult = getCompareResult(left, right, code);
		if (compareResult >= 0)
		{
			right = nextItem(right);
			moveItems(rightList, newList, 1);
		}
		if (compareResult <= 0)
		{
			left = nextItem(left);
			moveItems(leftList, newList, 1);
		}
	}
	moveItems(leftList, newList, getListSize(leftList));
	moveItems(rightList, newList, getListSize(rightList));
	freeList(&leftList);
	freeList(&rightList);
	return newList;
}

List* sorting(List* list, SortingCode code)
{
	int size = getListSize(list);
	if (size <= 1)
	{
		return list;
	}
	List* leftList = makeList();
	moveItems(list, leftList, size / 2);
	List* rightList = makeList();
	moveItems(list, rightList, size - size / 2);
	freeList(&list);

	leftList = sorting(leftList, code);
	rightList = sorting(rightList, code);
	return mergeLists(leftList, rightList, code);
}