#include <stdio.h>
#include <stdlib.h>

void swap(int* a, int* b)
{
	int temp = *a;
	*a = *b;
	*b = temp;
}

void insertionSort(int array[], const int left, const int right)
{
	for (int i = left + 1; i <= right; i++)
	{
		int j = i - 1;
		while (j >= 0 && array[j] > array[j + 1])
		{
			swap(&array[j], &array[j + 1]);
			j--;
		}
	}
}

void quickSort(int array[], const int left, const int right)
{
	if (right - left + 1 < 10)
	{
		insertionSort(array, left, right);
		return;
	}
	const int mid = (left + right) / 2;
	const int prop = array[mid];
	int i = left;
	int j = right;
	while (i <= j)
	{
		while (array[i] < prop)
		{
			i++;
		}
		while (array[j] > prop)
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

int main()
{
	printf("Please, enter array size and array ");
	int size = 0;
	scanf("%i", &size);
	int* array = malloc(size * sizeof(int));
	for (int i = 0; i < size; i++)
	{
		scanf("%i", &array[i]);
	}
	quickSort(array, 0, size - 1);
	printf("Sorted array: ");
	for (int i = 0; i < size; ++i)
	{
		printf("%i ", array[i]);
	}

	return 0;
}