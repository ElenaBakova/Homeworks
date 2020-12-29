#include "List.h"
#include "TestList.h"
#include "MergeSort.h"
#include <stdio.h>
#include <string.h>

char* getCurrent(Position position, int code)
{
	return code == 0 ? getName(position) : getNumber(position);
}

bool checkList(List* list, int code)
{
	Position position = getFirst(list);
	char* previous = getCurrent(position, code);
	position = nextItem(position);
	bool result = true;
	while (!isEnd(position))
	{
		char* current = getCurrent(position, code);
		result &= strcmp(previous, current) <= 0;
		position = nextItem(position);
	}
	return result;
}

bool tests()
{
	FILE* input = fopen("test.txt", "r");
	if (input == NULL)
	{
		return 1;
	}
	List* list = makeList();
	while (!feof(input))
	{
		char name[1000] = "";
		char number[1000] = "";
		fscanf(input, "%s%s", name, number);
		addItem(list, name, number);
	}
	fclose(input);
	list = sorting(list, 0);
	bool result = checkList(list, 0);
	list = sorting(list, 1);
	result &= checkList(list, 1);
	freeList(&list);
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

	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		return 1;
	}
	List* list = makeList();
	while (!feof(input))
	{
		char name[1000] = "";
		char number[1000] = "";
		fscanf(input, "%s%s", name, number);
		addItem(list, name, number);
	}
	fclose(input);

	printf("Would you like to sort by name (0) or by number (1)?\n");
	int code = 0;
	scanf("%i", &code);
	list = sorting(list, code);
	printList(list);

	freeList(&list);
	return 0;
}