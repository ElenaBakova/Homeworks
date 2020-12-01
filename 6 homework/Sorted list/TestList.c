#include "TestList.h"
#include "List.h"
#include <stdbool.h>
#include <locale.h>

bool testAddItem(void)
{
	List *list = makeList();
	addItem(list, 2);
	addItem(list, 4);
	addItem(list, 1);
	addItem(list, 0);
	addItem(list, 5);
	addItem(list, 3);

	int k = 0;
	int previous = -1;
	bool result = true;
	while (!isEmpty(list))
	{
		int current = getTheValue(list);
		result &= (current == k && current > previous);
		previous = current;
		removeValue(list, current);
		k++;
	}

	freeList(&list);
	return result;
}

bool testRemove(void)
{
	List* list = makeList();
	addItem(list, 1);
	addItem(list, 0);
	addItem(list, -1);
	addItem(list, 3);
	addItem(list, 2);
	addItem(list, 4);
	addItem(list, 65);
	addItem(list, -2);
	addItem(list, 70);

	bool result = true;
	for (int k = -1; k < 5; k++)
	{
		result &= !removeValue(list, k);
	}
	result &= !removeValue(list, 65);
	result &= !removeValue(list, 70);
	result &= !removeValue(list, -2);
	freeList(&list);
	return result;
}

bool listTests()
{
	return testAddItem() && testRemove();
}