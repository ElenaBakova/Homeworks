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

int check(const int array[], const int size)
{
	for (int i = 1; i < size; i++)
	{
		if (array[i - 1] > array[i])
		{
			return 0;
		}
	}
	return 1;
}

void makeArray(int array[], const int size, const int code)
{
	for (int i = 0; i < size; i++)
	{
		if (code == 0)
		{
			array[i] = rand() % 1000;
		}
		else if (code == 1)
		{
			array[i] = i;
		}
		else
		{
			array[i] = 1453;
		}
	}
}

int testSingle()
{
	int array[1] = { 5671 };
	quickSort(array, 0, 0);
	return array[0] == 5671;
}

int testInsertion()
{
	const int size = 7;
	int* array = malloc(size * sizeof(int));
	makeArray(array, size, 0);
	quickSort(array, 0, size - 1);
	return check(array, size);
}

int testSorted()
{
	const int size = 20;
	int* array = malloc(size * sizeof(int));
	makeArray(array, size, 1);
	quickSort(array, 0, size - 1);
	return check(array, size);
}

int testEven()
{
	const int size = 20;
	int* array = malloc(size * sizeof(int));
	makeArray(array, size, 2);
	quickSort(array, 0, size - 1);
	return check(array, size);
}

int testArray()
{
	const int size = 125;
	int* array = malloc(size * sizeof(int));
	makeArray(array, size, 0);
	quickSort(array, 0, size - 1);
	return check(array, size);
}

int tests()
{
	return testSingle() == 1 && testInsertion() == 1 && testSorted() == 1 && testEven() == 1 && testArray() == 1;
}

int main()
{
	srand(time(NULL));
	if (tests() == 0)
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
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