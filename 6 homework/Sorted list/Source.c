#include "List.h"
#include <stdio.h>

int main()
{
	List *list = initListItem(0);
	printList(list);
	printf("\n");
	addItem(list, 1);
	printList(list);
	printf("\n");
	addItem(list, 15);
	printList(list);
	printf("\n");
	addItem(list, 14);
	printList(list);
	printf("\n");
	addItem(list, 22);
	printList(list);
	printf("\n");
	addItem(list, -1);
	printList(list);
	printf("\n");
	freeList(&list);

	/*int code = 0;
	List *list = NULL;
	printf("Commands:\n0 - exit\n1 - add new value to the list\n2 - remove value from the list\n3 - print the list\n");
	while (true)
	{
		printf("Enter command code: ");
		scanf("%i", &code);
		int value = 0;
		switch (code)
		{
		case 0:
			freeList(&list);
			return 0;
		case 1: 
			printf("Please enter value ");
			scanf("%i", &value);
			if (list == NULL)
			{
				list = initListItem(value);
			}
			else
			{
				addItem(list, value);
			}
			break;
		case 2:
			printf("Please enter value ");
			scanf("%i", &value);
			if (removeValue(list, value))
			{
				printf("An error occured\n");
			}
			break;
		case 3:
			printList(list);
			printf("\n");
			break;
		default:
			break;
		}
	}

	freeList(&list);*/
	return 0;
}