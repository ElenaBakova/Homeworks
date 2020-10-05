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

bool checkElement(const int array[], const int size, const int number)
{
	int left = 0;
	int right = size - 1;
	while (left + 1 < right)
	{
		const int mid = (left + right) / 2;
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

bool testSingle()
{
	int array[1] = { 1343 };
	return checkElement(array, 1, 1343) == 1 && checkElement(array, 1, 12432) == 0 && checkElement(array, 1, -19) == 0;
}

bool testDifferent()
{
	const int size = 5;
	int array[5] = { 1534, 140 , -390, 30, 343 };
	quickSort(array, 0, size - 1);
	return checkElement(array, size, -390) == 1 && checkElement(array, size, 390) == 0 && checkElement(array, size, 1534) == 1 && checkElement(array, size, -24743) == 0;
}

bool testNegative()
{
	const int size = 8;
	int array[8] = { -5, -1244, -1, -15, -3932, -5628, -12, -12 };
	quickSort(array, 0, size - 1);
	return checkElement(array, size, -12) == 1 && checkElement(array, size, 15) == 0 && checkElement(array, size, -1244) == 1 && checkElement(array, size, -24743) == 0 && checkElement(array, size, -3932) == 1;
}

bool testEven()
{
	const int size = 5;
	int array[5] = { 14, 14, 14, 14, 14 };
	quickSort(array, 0, size - 1);
	return checkElement(array, size, -231) == 0 && checkElement(array, size, 14) == 1 && checkElement(array, size, -5315) == 0;
}

bool tests()
{
	return testSingle() == 1 && testDifferent() == 1 && testNegative() == 1 && testEven() == 1;
}

int main()
{
	srand(time(NULL));
	if (!tests())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	printf("Please enter n and k: ");
	int n = 0;
	int k = 0;
	scanf("%i %i", &n, &k);
	if (n < 0 || k < 0)
	{
		printf("Incorrect input data");
		return 0;
	}
	int* array = malloc(n * sizeof(int));
	makeArray(array, n);
	printArray(array, n);
	quickSort(array, 0, n - 1);
	for (int i = 0; i < k; ++i)
	{
		const int number = rand() % 1000;
		printf("%i ", number);
		printf(checkElement(array, n, number) == 1 ? "is in array\n" : "is not in array\n");
	}

	free(array);
	return 0;
}