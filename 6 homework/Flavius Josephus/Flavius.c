#include "List.h"
#include "TestList.h"
#include <stdio.h>

//bool tests()
//{
//	return;
//}

int main()
{
	//if (!listTests())
	//{
	//	printf("List tests failed");
	//	return 1;
	//}
	//printf("List tests succeed");
	//if (!tests())
	//{
	//	printf("Tests failed");
	//	return 1;
	//}
	//printf("Tests succeed");

	int warriors, m;
	printf("Please enter number of warriors and m: ");
	scanf("%i %i", &warriors, &m);
	if (m < 1 || warriors < 1) {
		printf("Invalid input data");
		return 1;
	}
	List* list = initListItem(1);
	for (int i = 2; i <= warriors; i++) {
		addItem(list, i);
	}

	int count = 1;
	Position* current = getHead(list);
	while (!isEmpty(list))
	{
		if (count % m == 0) {
			removePosition(list, getThePosition(current));
			count = 0;
		}
		current = nextItem(current);
		count++;
	}
	printf("Last warrior position: %i", getThePosition(current));

	freeList(&list);
	free(current);
	return 0;
}