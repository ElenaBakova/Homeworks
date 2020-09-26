#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void bubbleSort(int array[], const int size, const int code)
{
	for (int i = 0; i < size; ++i)
	{
		for (int j = i; j > 0; --j)
		{
			if (array[j] < array[j - 1])
			{
				int t = array[j];
				array[j] = array[j - 1];
				array[j - 1] = t;
			}
		}
	}
	if (code == 1)
	{
		return;
	}
	printf("Result of bubble sort: ");
	for (int i = 0; i < size; ++i)
	{
		printf("%i ", array[i]);
	}
}

void countSort(const int massive[], const int max, const int min, const int massiveSize, const int code)
{
	int size = max + 1 + abs(min);
	int* array = calloc(size, sizeof(int));
	for (int i = 0; i < massiveSize; ++i)
	{
		array[massive[i] + abs(min)]++;
	}
	if (code == 1)
	{
		return;
	}
	printf("Result of counting sort: ");
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < array[i]; ++j)
		{
			printf("%i ", i - abs(min));
		}
	}
	printf("\n");

	free(array);
}

void comparison()
{
	int array[100000];
	int max = -51000;
	int min = 51000;
	for (int i = 0; i < 100000; ++i)
	{
		array[i] = rand() % 50000;
		max = (max < array[i] ? array[i] : max);
		min = (min > array[i] ? array[i] : min);
	}
	int countingTime = clock();
	countSort(array, max, min, 100000, 1);
	countingTime = clock() - countingTime;
	int bubbleTime = clock();
	bubbleSort(array, 100000, 1);
	bubbleTime = clock() - bubbleTime;
	
	printf("Array size: 100000\nTime:\n	Bubble sort: %f sec\n	Counting sort: %f sec\n\n", (double)bubbleTime / CLOCKS_PER_SEC, (double)countingTime / CLOCKS_PER_SEC);
}

int main()
{
	comparison();
	int massive[1000];
	int amount = 0;
	printf("Enter size of array: ");
	scanf("%i", &amount);
	int max = -10000;
	int min = 10000;
	for (int i = 0; i < amount; ++i)
	{
		scanf("%i", &massive[i]);
		max = (max < massive[i] ? massive[i] : max);
		min = (min > massive[i] ? massive[i] : min);
	}
	
	countSort(massive, max, min, amount, 0);
	bubbleSort(massive, amount, 0);

	return 0;
}