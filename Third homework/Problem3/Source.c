#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

void swap(int* a, int* b)
{
	const int temp = *a;
	*a = *b;
	*b = temp;
}

void quickSort(int array[], const int left, const int right)
{
	if (right - left + 1 < 3)
	{
		if (array[left] > array[right])
		{
			swap(&array[left], &array[right]);
		}
		return;
	}
	const int mid = (left + right) / 2;
	const int pivot = array[mid];
	int i = left;
	int j = right;
	while (i <= j)
	{
		while (array[i] < pivot && i <= right)
		{
			i++;
		}
		while (array[j] > pivot && j >= left)
		{
			j--;
		}
		if (i <= j)
		{
			swap(&array[i], &array[j]);
			i++;
			j--;
		}
	}
	if (j > left)
	{
		quickSort(array, left, j);
	}
	if (i < right)
	{
		quickSort(array, i, right);
	}
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

bool testSingle()
{
	int array[1] = { 1957 };
	return findMostCommon(array, 1) == 1957;
}

bool testDifferent()
{
	const int size = 10;
	int array[10] = { 1, 4, 5, 4, 5, 4, 4, -4, 5,  4};
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == 4;
}

bool testEvenQuantity()
{
	const int size = 8;
	int array[8] = { 3, 5, 2, 1, 7, 4, 8, 6};
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size);
}

bool testEven()
{
	const int size = 5;
	int array[5] = { -18, -18, -18, -18, -18};
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size);
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
	int size = 0;
	printf("Please enter array size and array ");
	scanf("%i", &size);
	int* array = malloc(size * sizeof(int));
	for (int i = 0; i < size; ++i)
	{
		scanf("%i", &array[i]);
	}
	quickSort(array, 0, size - 1);
	printf("The most common element in the array: %i", findMostCommon(array, size));

	free(array);
	return 0;
}