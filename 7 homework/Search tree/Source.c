#include "Tree.h"
#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

int main()
{
	printf("This is dictionary: key - integer, value - string\n");
	printf("Commands:\n0 - quit\n1 - add value by key. If key already exists, its value will be replaced\n");
	printf("2 - get value by key\n3 - check whether key is in dictionary\n4 - delete key and its value from dictionary\n");
	
	Tree* root = createTree();
	int key = 0;
	char string[1000];
	while (true)
	{
		int code = 0;
		printf("Please enter command code: ");
		scanf("%i", &code);
		switch (code)
		{
		case 0:
			printf("Bye");
			free(root);
			return 0;
		case 1:
			printf("Enter key: ");
			scanf("%i", &key);
			printf("Enter value: ");
			gets_s(string, 1000);
			gets_s(string, 1000);
			add(&root, key, string);
			break;
		//case 2:
		//	printf("Enter key: ");
		//	scanf("%i", &key);
		//	printf("String: %s\n", getValue(root, key));
		//	break;
		//case 3:
		//	printf("Enter key: ");
		//	scanf("%i", &key);
		//	//printf("%i%s", key, findKey(root, key) ? "is in the dictionary\n" : "nothing found\n");
		//	break;
		//case 4:
		//	printf("Enter key: ");
		//	scanf("%i", &key);
		//	//deleteNode(root, key);
		//	break;
		default:
			break;
		}
	}

	return 0;
}