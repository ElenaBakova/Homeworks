#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include "Header.h"

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

bool testSingle()
{
	int array[1] = { 52342 };
	return findMostCommon(array, 1) == 52342;
}

bool testDifferent()
{
	const int size = 10;
	int array[10] = { 15, 40, 15, 15, 10, 4, 15, 3, 3, 3 };
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == 15;
}

bool testEvenQuantity()
{
	const int size = 8;
	int array[8] = { 8, 6, 9, 7, 5, 10, 4, 11 };
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == 4;
}

bool testEven()
{
	const int size = 5;
	int array[5] = { -72, -72, -72, -72, -72 };
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == -72;
}

bool tests()
{
	return testSingle() && testDifferent() && testEvenQuantity() && testEven();
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
	fprintf(output, "Please enter array size and array \n");
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