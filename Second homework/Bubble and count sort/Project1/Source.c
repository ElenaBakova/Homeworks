#include <stdio.h>
#include <stdlib.h>

void bubbleSort(int a[], int p, int n)
{
	
}

void countSort(int massive[], const int max, const int min, const int massiveSize)
{
	int size = max + 1 + abs(min);
	int* array = calloc(size, sizeof(int));
	for (int i = 0; i < massiveSize; ++i)
	{
		array[massive[i] + abs(min)]++;
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

int main()
{
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
	countSort(massive, max, min, amount);

	return 0;
}