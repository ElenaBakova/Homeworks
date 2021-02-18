#include "Hash-table/Hash-Table.h"
#include "Hash-table/TestList.h"
#include <stdio.h>
#include <stdbool.h>

int main()
{
	if (!listTests())
	{
		printf("List tests failed");
		return 1;
	}
	printf("List tests succeed\n");

	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		printf("Can't open file\n");
		return 1;
	}
	HashTable* hashTable = makeHashTable();
	while (!feof(input))
	{
		char word[1000] = "";
		fscanf(input, "%s", &word);
		addToTheTable(hashTable, word);
	}
	fclose(input);

	printHashTable(hashTable);
	printf("\nLoad factor: %.5f\n", getLoadFactor(hashTable));
	printf("Maximum list length: %i\n", getMaxListLength(hashTable));
	printf("Average list length: %i\n", getAverageListLength(hashTable));

	deleteHashTable(&hashTable);
	return 0;
}