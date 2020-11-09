#include "List.h"
#include "TestList.h"
#include <stdio.h>

int findLastWarrior(int warriors, int m)
{
	if (warriors < 1 || m < 1) {
		return -1;
	}
	List* list = initListItem(1);
	for (int i = 2; i <= warriors; i++) {
		addItem(list, i);
	}

	int count = 1;
	Position* current = getHead(list);
	while (warriors > 1)
	{
		if (count % m == 0) {
			removePosition(list, getThePosition(current));
			count = 0;
			warriors--;
		}
		current = nextItem(current);
		count++;
	}
	int answer = getThePosition(current);
	freeList(&list);
	free(current);
	return answer;
}

bool tests()
{
	bool result = true;
	result &= findLastWarrior(15, 2) == 15 && findLastWarrior(15, 15) == 4 && findLastWarrior(15, 0) == -1;
	result &= findLastWarrior(5, 9) == 2 && findLastWarrior(1, 11) == 1 && findLastWarrior(14, 3) == 2;
	return result;
}

int main()
{
	if (!listTests())
	{
		printf("List tests failed");
		return 1;
	}
	printf("List tests succeed\n");
	if (!tests())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");

	int warriors, m;
	printf("Please enter number of warriors and m: ");
	scanf("%i %i", &warriors, &m);
	if (m < 1 || warriors < 1) {
		printf("Invalid input data");
		return 1;
	}
	printf("Last warrior position: %i", findLastWarrior(warriors, m));

	return 0;
}