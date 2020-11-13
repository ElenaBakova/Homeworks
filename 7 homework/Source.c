#include "Tree.h"
#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>

int main()
{
	printf("This is dictionary: key - integer, value - string\n");
	printf("Commands:\n0 - quit\n1 - add value by key. If key already exists, its value will be replaced\n");
	printf("2 - get value by key\n3 - check whether key is in dictionary\n4 - delete key and its value from dictionary\n");
	
	while (true)
	{
		Node* root = NULL;
		int code = 0;
		int key = 0;
		char* string;
		printf("Please enter command code: ");
		scanf("%i", &code);
		switch (code)
		{
		case 0:
			printf("Bye");
			free(root);
			return 0;
		case 1:
			printf("Enter key and value: ");
			scanf("%i %s", &key, &string);
			add(root, key, string);
		case 2:
			printf("Enter key: ");
			scanf("%i", &key);
			//printf("String: %s\n", getValue(root, key));
		case 3:
			printf("Enter key: ");
			scanf("%i", &key);
			//printf("%i%s", key, findKey(root, key) ? "is in the dictionary\n" : "nothing found\n");
		case 4:
			printf("Enter key: ");
			scanf("%i", &key);
			//deleteNode(root, key);
		default:
			break;
		}
	}

	return 0;
}