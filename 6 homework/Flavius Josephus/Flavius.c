#include "List.h"
#include "TestList.h"
#include <stdio.h>

int main()
{
	//if (!listTests())
	//{
	//	printf("List tests failed");
	//	return 1;
	//}
	//printf("List tests succeed");

	int warriors, m;
	printf("Please enter number of warriors and m: ");
	scanf("%i %i", &warriors, &m);
	List* list = initListItem(1);
	for (int i = 2; i <= warriors; i++) {
		addItem(list, i);
	}
	int current = 1;
	List* currentList = list;
	while (!isEmpty(list))
	{
		if (current % m == 0) {
			removePosition(list, getThePosition(currentList));
			current = 0;
		}
		nextItem(currentList);
		current++;
	}
	printf("%i", getThePosition(currentList));

	freeList(&list);
	return 0;
}