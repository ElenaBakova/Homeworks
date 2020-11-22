//#include "Hash-table/Hash-Table.h"
#include <stdio.h>

int main()
{
	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		printf("Can't open file\n");
		return 1;
	}
	while (!feof(input))
	{
		char word[500] = "";
		fscanf(input, "%s", &word);
		printf("%s\n", word);
	}
	fclose(input);

	return 0;
}