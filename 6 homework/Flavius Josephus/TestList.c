#include "TestList.h"
#include "List.h"
#include <stdbool.h>
#include <stdlib.h>
#include <locale.h>

bool testAddItem(void)
{
	List *list = initListItem();
	const int count = 5;
	for (int i = 0; i < count; i++)
	{
		addItem(list, i);
	}
	Position *current = getHead(list);
	bool result = true;
	for (int k = 0; k < count; k++)
	{
		result &= (getThePosition(current) == k);
		current = nextItem(current);
	}
	freeList(&list);
	free(current);
	return result;
}

bool testRemove(void)
{
	List* list = initListItem();
	for (int i = 0; i < 10; i++)
	{
		addItem(list, i);
	}

	bool result = removePosition(list, 9);
	for (int k = 0; k < 9; k++)
	{
		result &= removePosition(list, k);
	}
	freeList(&list);
	return result;
}

bool listTests()
{
	return testAddItem() && testRemove();
}