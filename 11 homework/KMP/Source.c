#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>

int* prefixFunction(const char* string)
{
	int size = strlen(string);
	int* prefix = calloc(size, sizeof(int));
	if (prefix == NULL)
	{
		return NULL;
	}

	for (int i = 1; i < size; i++)
	{
		int temp = prefix[i - 1];
		while (temp > 0 && string[i] != string[temp])
		{
			temp = prefix[temp - 1];
		}
		if (string[i] == string[temp])
		{
			temp++;
		}
		prefix[i] = temp;
	}

	return prefix;
}

int findNeedle(char* haystack, char* needle)
{
	char* string = malloc(sizeof(char) * (strlen(haystack) + strlen(needle) + 2));
	if (string == NULL)
	{
		return -1;
	}
	strcpy(string, needle);
	strcat(string, "#");
	strcat(string, haystack);
	int* prefix = prefixFunction(string);
	int stringSize = strlen(string);
	int haystackSize = strlen(haystack);
	int needleSize = strlen(needle);
	for (int i = 0; i < stringSize; i++)
	{
		if (prefix[i] == needleSize)
		{
			free(prefix);
			free(string);
			return i - 2 * needleSize + 1;
		}
	}
	free(prefix);
	free(string);
	return -1;
}

bool test()
{
	return findNeedle("aba caba daba", "aba caba") == 1 && findNeedle("abcabdaaabcbcbabacde", "aba") == 15 && findNeedle("bcbcbcb", "qwerty") < 0;
}

int main()
{
	if (!test())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");
	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		return 1;
	}
	char haystack[1000] = "";
	fgets(haystack, 1000, input);
	fclose(input);
	printf("Please enter string: ");
	char needle[1000] = "";
	gets_s(needle, 1000);
	int position = findNeedle(haystack, needle);
	if (position < 0)
	{
		printf("Position not found");
		return 0;
	}
	printf("Position: %i", position);

	return 0;
}