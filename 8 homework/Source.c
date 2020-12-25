#include "Dictionary.h"
#include <string.h>
#include <stdio.h>

bool test()
{
	Dictionary* dictionary = createDictionary();
	char* value = "abacabadaba";
	addRecord(dictionary, "8", value);
	addRecord(dictionary, "4", value);
	addRecord(dictionary, "10", value);
	addRecord(dictionary, "3", value);
	addRecord(dictionary, "1", value);
	addRecord(dictionary, "13", value);
	bool result = true;
	result &= isContained(dictionary, "8") && isContained(dictionary, "4") && isContained(dictionary, "10") && isContained(dictionary, "13");
	result &= strcmp(findValueByKey(dictionary, "10"), value) == 0 && strcmp(findValueByKey(dictionary, "4"), value) == 0;
	addRecord(dictionary, "13", "abc");
	result &= strcmp(findValueByKey(dictionary, "13"), "abc") == 0;
	removeRecord(dictionary, "13");
	removeRecord(dictionary, "8");
	removeRecord(dictionary, "1");
	removeRecord(dictionary, "4");
	removeRecord(dictionary, "5");
	result &= !isContained(dictionary, "8") && !isContained(dictionary, "4") && isContained(dictionary, "10") && !isContained(dictionary, "13");
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
	printf("Tests succeed\n");


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