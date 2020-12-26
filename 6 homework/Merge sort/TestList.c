#include "TestList.h"
#include "List.h"
#include <stdbool.h>
#include <locale.h>

bool listTests(void)
{
	List* list = makeList();
	char* number = "898";
	addItem(list, "1", number);
	addItem(list, "0", number);
	addItem(list, "-1", number);
	addItem(list, "3", number);
	addItem(list, "2", number);
	addItem(list, "4", number);
	addItem(list, "65", number);
	addItem(list, "-2", number);
	addItem(list, "70", number);

	bool result = true;
	int i = 0;
	result &= removeValue(list, "5");
	result &= !removeValue(list, "0");
	result &= !removeValue(list, "1");
	result &= !removeValue(list, "2");
	result &= !removeValue(list, "3");
	result &= !removeValue(list, "4");
	result &= !removeValue(list, "65");
	result &= !removeValue(list, "70");
	result &= !removeValue(list, "-1");
	result &= !removeValue(list, "-2");
	result &= isEmpty(list);

	freeList(&list);
	return result;
}