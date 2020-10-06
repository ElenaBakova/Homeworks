#include <stdio.h>
#include <stdlib.h>
#include <time.h>
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

void flipArray(int array[], const int size)
{
	int left = 0;
	int right = size - 1;
	while (left < right)
	{
		swap(&array[left], &array[right]);
		left++;
		right--;
	}
}

double countAverage(const int array[], const int size)
{
	double arraySum = 0;
	for (int i = 0; i < size; i++)
	{
		arraySum += (double)array[i];
	}
	return arraySum / (double)size;
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
	for (int i = 0; i < size; ++i)
	{
		printf("%i ", array[i]);
	}
	printf("\n");
}

int main()
{
	srand(time(NULL));
	int array[1000] = { 0 };
	while (true)
	{
		printf("Please enter code: ");
		const int code = 0;
		const int size = 1000;
		scanf("%i", &code);
		if (code == 0)
		{
			return 0;
		}
		if (code == 1)
		{
			makeArray(array, size);
			printf("Generated array: ");
			printArray(array, size);
		}
		else if (code == 2)
		{
			quickSort(array, 0, size - 1);
			printf("Sorted array: ");
			printArray(array, size);
		}
		else if (code == 3)
		{
			flipArray(array, size);
			printf("Flipped array: ");
			printArray(array, size);
		}
		else if (code == 4)
		{
			double average = countAverage(array, size);
			printf("Array average: %f\n", average);
		}
	}
	
	return 0;
}
