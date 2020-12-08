#include "TestList.h"
#include "List.h"
#include <stdbool.h>
#include <locale.h>

bool testAddItem(void)
{
	List* list = makeList();
	for (int i = 9; i > 0; i -= 2)
	{
		addItem(list, i, i + 1);
	}
	bool result = true;
	for (int i = 1; i < 10; i += 2)
	{
		result &= getTheValue(list) == i && getLength(list) == i + 1;
		removeValue(list, i);
	}
	
	freeList(&list);
	return result;
}

bool testRemove(void)
{
	List* list = makeList();
	for (int i = 1; i < 10; i += 2)
	{
		addItem(list, i, i + 1);
	}

	bool result = true;
	for (int k = 1; k < 10; k += 2)
	{
		result &= !removeValue(list, k);
	}
	result &= isEmpty(list);
	freeList(&list);
	return result;
}

bool listTests()
{
	return testAddItem() && testRemove();
}