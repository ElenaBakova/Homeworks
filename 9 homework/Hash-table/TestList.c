#include "TestList.h"
#include "List.h"
#include <stdbool.h>

bool listTests()
{
	List* list = makeList();
	addItem(list, "4");
	addItem(list, "4");
	addItem(list, "4");
	addItem(list, "10");
	addItem(list, "3");
	addItem(list, "1");
	addItem(list, "13");
	bool result = !removeValue(list, "4");
	result &= !removeValue(list, "1");
	result &= !removeValue(list, "13");
	result &= !removeValue(list, "10");
	result &= !removeValue(list, "3");

	freeList(&list);
	return result;
}