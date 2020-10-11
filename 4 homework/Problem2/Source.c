#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include "Sort.h"
#include "Tests.h"

void swap(int* a, int* b)
{
	const int temp = *a;
	*a = *b;
	*b = temp;
}

int findMostCommon(const int array[], const int size)
{
	int mostCommon = 0;
	int maxQuantity = 0;
	int i = 0;
	while (i < size)
	{
		int countLength = 1;
		while (array[i] == array[i + 1] && i + 1 < size)
		{
			countLength++;
			i++;
		}
		if (maxQuantity < countLength)
		{
			maxQuantity = countLength;
			mostCommon = array[i];
		}
		i++;
	}

	return mostCommon;
}

int main()
{
	if (!tests())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");

	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		printf("File not found!");
		return -1;
	}
	FILE* output = fopen("output.txt", "w");
	if (output == NULL)
	{
		return -1;
	}

	int size = 0;
	fscanf(input, "%i", &size);

	int* array = malloc(size * sizeof(int));
	for (int i = 0; i < size; ++i)
	{
		fscanf(input, "%i", &array[i]);
	}
	fclose(input);

	quickSort(array, 0, size - 1);
	fprintf(output, "The most common element in the array: %i\n", findMostCommon(array, size));

	fclose(output);
	free(array);
	return 0;
}