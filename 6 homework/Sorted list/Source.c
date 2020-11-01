#include "List.h"
#include <stdio.h>

int main()
{
	int code = 0;
	ListElement* head = NULL;
	printf("Commands:\n0 - exit\n1 - add new value to the list\n2 - remove value from the list\n3 - print the list\n");
	while (true)
	{
		printf("Enter command code: ");
		scanf("%i", &code);
		int value = 0;
		switch (code)
		{
		case 0:
			freeList(&head);
			return 0;
		case 1: 
			printf("Please enter value ");
			scanf("%i", &value);
			if (head == NULL)
			{
				head = initListItem(value);
			}
			else
			{
				addItem(&head, value);
			}
			break;
		case 2:
			printf("Please enter value ");
			scanf("%i", &value);
			if (pop(&head, value))
			{
				printf("An error occured\n");
			}
			break;
		case 3:
			printList(head);
			printf("\n");
			break;
		default:
			break;
		}
	}

	return 0;
}