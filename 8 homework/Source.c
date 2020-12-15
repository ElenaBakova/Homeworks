#include "Dictionary.h"
#include <string.h>
#include <stdio.h>

int main(void)
{
	printf("Commands\n0: quit\n1: add value by key. If key already in the dictionary, value will be replaced\n");
	printf("2: get value by key\n3: check whether key is in the dictionary\n4: remove the key and its value\n");
	Dictionary* dictionary = createDictionary();
	while (true)
	{
		int code = 0;
		char value[1000] = "";
		char key[1000] = "";
		printf("Please enter command code ");
		scanf("%d", &code);
		switch (code)
		{
		case 0:
			freeDictionary(dictionary);
			dictionary = NULL;
			return 0;
		case 1:
			printf("Enter key ");
			scanf("%s", &key);
			printf("Enter value ");
			scanf("%s", &value);
			addRecord(dictionary, key, value);
			break;
		case 2:
			printf("Enter key ");
			scanf("%s", &key);
			char* string = findValueByKey(dictionary, key);
			if (string == NULL)
			{
				printf("Key not found\n");
				break;
			}
			printf("Value: %s\n", string);
			break;
		case 3:
			printf("Enter key ");
			scanf("%s", &key);
			if (isContained(dictionary, key))
			{
				printf("Key is in the dictionary\n");
			}
			else
			{
				printf("Key is not in the dictionary\n");
			}
			break;
		case 4:
			printf("Enter key ");
			scanf("%s", &key);
			removeRecord(dictionary, key);
		default:
			break;
		}
	}

	return 0;
}