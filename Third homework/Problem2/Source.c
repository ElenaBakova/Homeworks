#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void swap(int* a, int* b)
{
	int temp = *a;
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

void makeArray(int array[], const int size)
{
	for (int i = 0; i < size; ++i)
	{
		array[i] = rand() % 1000;
	}
}

void printArray(const int array[], const int size)
{
	printf("Generated array: ");
	for (int i = 0; i < size; ++i)
	{
		printf("%i ", array[i]);
	}
	printf("\n");
}

int check(const int array[], const int size, const int number)
{
	int left = 0;
	int right = size - 1;
	while (left + 1 < right)
	{
		int mid = (left + right) / 2;
		if (number == array[mid])
		{
			return 1;
		}
		if (number < array[mid])
		{
			right = mid;
		}
		else
		{
			left = mid;
		}
	}
	return (array[left] == number || array[right] == number);
}

int main()
{
	srand(time(NULL));
	printf("Please enter n and k: ");
	int n = 0;
	int k = 0;
	scanf("%i %i", &n, &k);
	int* array = malloc(n * sizeof(int));
	makeArray(array, n);
	printArray(array, n);
	quickSort(array, 0, n - 1);
	printArray(array, n);
	for (int i = 0; i < k; ++i)
	{
		const int number = array[i];
		printf("%i ", number);
		printf(check(array, n, number) == 1 ? "is in array\n" : "is not in array\n");
	}

	return 0;
}