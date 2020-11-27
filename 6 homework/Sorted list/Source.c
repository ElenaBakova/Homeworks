#include "List.h"
#include "TestList.h"
#include <stdio.h>

bool commandProcessing(const int code, List **list)
{
	int value = 0;
	switch (code)
	{
	case 0:
		freeList(list);
		return true;
	case 1:
		printf("Please enter value ");
		scanf("%i", &value);
		if (*list == NULL)
		{
			*list = makeList();
		}
		else
		{
			addItem(*list, value);
		}
		break;
	case 2:
		printf("Please enter value ");
		scanf("%i", &value);
		if (removeValue(*list, value))
		{
			printf("An error occured\n");
		}
		break;
	case 3:
		printList(*list);
		printf("\n");
		break;
	default:
		break;
	}
	return false;
}

int main()
{
	if (!listTests())
	{
		printf("List tests failed");
		return 1;
	}
	printf("List tests succeed\n");
	
	printf("Commands:\n0 - exit\n1 - add new value to the list\n2 - remove value from the list\n3 - print the list\n");
	List* list = NULL;
	while (true)
	{
		int code = 0;
		printf("Enter command code: ");
		scanf("%i", &code);
		if (commandProcessing(code, &list)) {
			return 0;
		}
	}

	return 0;
}