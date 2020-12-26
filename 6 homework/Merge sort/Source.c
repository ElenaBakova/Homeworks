#include "List.h"
#include "TestList.h"
#include <stdio.h>

void sortByName(List* left, List* right)
{
	List* leftList = makeList();
	Position pointer = getFirst(left);
}

int main()
{
	if (!listTests())
	{
		printf("List tests failed");
		return 1;
	}
	printf("List tests succeed\n");

	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		return 1;
	}
	char* name = "";
	char* number = "";
	List* list = makeList();
	while (!feof(input))
	{
		fscanf(input, "%s", name);
		fscanf(input, "%s", number);
		addItem(list, name, number);
	}
	fclose(input);

	printf("Would you like to sort by name (1) or by number (2)?\n");
	int code = 0;
	scanf("%i", &code);

	return 0;
}