#include "List.h"
#include "TestList.h"
#include <stdio.h>

int main()
{
	/*if (!listTests())
	{
		printf("List tests failed");
		return 1;
	}
	printf("List tests succeed");

	int warriors, m;
	printf("Please enter number of warriors and m: ");
	scanf("%i %i", &warriors, &m);*/

	List* list = initListItem(0);
	for (int i = 1; i < 5; i++)
	{
		addItem(list, i);
	}
	removePosition(list, 3);

	freeList(&list);
	return 0;
}