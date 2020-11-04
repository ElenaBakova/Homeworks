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
	printf("List tests succeed");*/

	FILE* input = fopen("input.txt", "r");
	if (input == NULL) {
		printf("Can't open file");
		return 1;
	}

	List* list = NULL;
	Pair record = { "", "" };
	while (!feof(input))
	{
		fscanf(input, "%s %s", &record.name, &record.number);
		addItem(&list, record);
	}
	fclose(input);

	freeList(&list);
	return 0;
}