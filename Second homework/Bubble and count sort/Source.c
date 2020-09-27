#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stddef.h>

void bubbleSort(int array[], const int size)
{
	for (int i = 0; i < size - 1; ++i)
	{
		for (int j = 0; j < size - i - 1; ++j)
		{
			if (array[j] > array[j + 1])
			{
				const int temp = array[j];
				array[j] = array[j + 1];
				array[j + 1] = temp;
			}
		}
	}
}

void countSort(int massive[], const int massiveSize)
{
	int max = INT_MIN;
	int min = INT_MAX;
	for (int i = 0; i < massiveSize; ++i)
	{
		max = (massive[i] > max ? massive[i] : max);
		min = (massive[i] < min ? massive[i] : min);
	}
	const size_t SIZE = max - min + 1;
	int* array = calloc(SIZE, sizeof(int));
	for (int i = 0; i < massiveSize; ++i)
	{
		array[massive[i] - min]++;
	}
	int k = 0;
	for (int i = 0; i < SIZE; ++i)
	{
		for (int j = 0; j < array[i]; ++j)
		{
			massive[k] = i + min;
			k++;
		}
	}

	free(array);
}

void comparison(void)
{
	const size_t SIZE = 100000;
	int* arrayFirst = malloc(SIZE * sizeof(int));
	int* arraySecond = malloc(SIZE * sizeof(int));
	for (int i = 0; i < SIZE; ++i)
	{
		arrayFirst[i] = rand() % 10;
		arraySecond[i] = arrayFirst[i];
	}
	int countingTime = clock();
	countSort(arrayFirst, SIZE);
	countingTime = clock() - countingTime;
	int bubbleTime = clock();
	bubbleSort(arraySecond, SIZE);
	bubbleTime = clock() - bubbleTime;
	
	printf("Array size: 100000\nTime:\n	Bubble sort: %f sec\n	Counting sort: %f sec\n\n", (double)bubbleTime / CLOCKS_PER_SEC, (double)countingTime / CLOCKS_PER_SEC);

	free(arrayFirst);
	free(arraySecond);
}

void makeArray(int array[], const int SIZE)
{
	for (int i = 0; i < SIZE; ++i)
	{
		array[i] = rand();
	}
}

int testResult(const int array[], const int SIZE)
{
	for (int i = 0; i < SIZE - 1; ++i)
	{
		if (array[i] > array[i + 1])
		{
			return 0;
		}
	}
	return 1;
}

int testCountingSort()
{
	const int SIZE = 1000;
	int array[1000];
	makeArray(array, SIZE);
	countSort(array, SIZE);
	return testResult(array, SIZE);
}

int testBubbleSort()
{
	const int SIZE = 1000;
	int array[1000];
	makeArray(array, SIZE);
	bubbleSort(array, SIZE);
	return testResult(array, SIZE);
}

int testSingleElement()
{
	int array[1];
	int k = rand();
	array[0] = k;
	bubbleSort(array, 1);
	return array[0] == k;
}

int testBig()
{
	const int SIZE = 1000;
	int array[1000];
	for (int i = 0; i < SIZE; ++i)
	{
		array[i] = rand() % 10 + 100000;
	}
	countSort(array, SIZE);
	return testResult(array, SIZE);
}

int testNegative()
{
	const int SIZE = 1000;
	int array[1000];
	for (int i = 0; i < SIZE; ++i)
	{
		array[i] = -abs(rand());
	}
	countSort(array, SIZE);
	return testResult(array, SIZE);
}

int tests()
{
	return testCountingSort() == 1 && testBubbleSort() == 1 && testSingleElement() == 1 && testBig() == 1 && testNegative() == 1;
}

void arrayPrint(const int array[], const int arraySize)
{
	printf("Sorting result:");
	for (int i = 0; i < arraySize; ++i)
	{
		printf(" %i", array[i]);
	}
	printf("\n");
}

int main()
{
	comparison();
	if (tests() == 0)
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	int amount = 0;
	printf("Enter size of array: ");
	scanf("%i", &amount);
	if (amount < 0)
	{
		printf("Array size should be positive\n");
		return 0;
	}
	int* massiveFirst = malloc(amount * sizeof(int));
	int* massiveSecond = malloc(amount * sizeof(int));
	for (int i = 0; i < amount; ++i)
	{
		scanf("%i", &massiveFirst[i]);
		massiveSecond[i] = massiveFirst[i];
	}
	
	countSort(massiveFirst,amount);
	arrayPrint(massiveFirst, amount);
	bubbleSort(massiveSecond, amount);
	arrayPrint(massiveSecond, amount);
	
	free(massiveFirst);
	free(massiveSecond);
	return 0;
}