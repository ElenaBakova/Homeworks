#include "Tree.h"
#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>

bool test()
{
	Dictionary dictionary = createDictionary();
	char* string = "abacabadaba";
	addRecord(&dictionary, 8, string);
	addRecord(&dictionary, 4, string);
	addRecord(&dictionary, 10, string);
	addRecord(&dictionary, 3, string);
	addRecord(&dictionary, 1, string);
	addRecord(&dictionary, 13, string);
	bool result = true;
	result &= isContained(dictionary, 8) && isContained(dictionary, 4) && isContained(dictionary, 10) && isContained(dictionary, 13);
	result &= strcmp(findInDictionary(dictionary, 10), string) == 0 && strcmp(findInDictionary(dictionary, 4), string) == 0;
	addRecord(&dictionary, 13, "abc");
	result &= strcmp(findInDictionary(dictionary, 13), "abc") == 0;
	deleteRecord(dictionary, 8);
	deleteRecord(dictionary, 13);
	deleteRecord(dictionary, 1);
	deleteRecord(dictionary, 4);
	deleteRecord(dictionary, 5);
	result &= !isContained(dictionary, 8) && !isContained(dictionary, 4) && isContained(dictionary, 10) && !isContained(dictionary, 13);
	freeDictionary(dictionary);
	return result;
}

int main()
{
	if (!test())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed");

	printf("This is dictionary: key - integer, value - string\n");
	printf("Commands:\n0 - quit\n1 - add value by key. If key already exists, its value will be replaced\n");
	printf("2 - get value by key\n3 - check whether key is in dictionary\n4 - delete key and its value from dictionary\n");
	
	Dictionary dictionary = createDictionary();
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
			freeDictionary(dictionary);
			printf("Bye");
			return 0;
		case 1:
			printf("Enter key: ");
			scanf("%i", &key);
			printf("Enter value: ");
			gets_s(string, 1000);
			gets_s(string, 1000);
			addRecord(&dictionary, key, string);
			break;
		case 2:
			printf("Enter key: ");
			scanf("%i", &key);
			char* foundString = findInDictionary(dictionary, key);
			if (foundString == NULL)
			{
				printf("Nothing was found\n");
				break;
			}
			printf("Value: %s\n", foundString);
			break;
		case 3:
			printf("Enter key: ");
			scanf("%i", &key);
			printf("%i %s", key, isContained(dictionary, key) ? "is in the dictionary\n" : "not found\n");
			break;
		case 4:
			printf("Enter key: ");
			scanf("%i", &key);
			deleteRecord(dictionary, key);
			break;
		default:
			break;
		}
	}

	return 0;
}