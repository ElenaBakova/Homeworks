#include <stdio.h>
#include <stdlib.h>

int findMostCommon(const int array[], const int size)
{
	int min = INT_MAX;
	int max = INT_MIN;
	for (int i = 0; i < size; ++i)
	{
		min = array[i] < min ? array[i] : min;
		max = array[i] > max ? array[i] : max;
	}
	int* countArray = calloc(max - min + 1, sizeof(int));
	int mostCommon = 0;
	for (int i = 0; i < size; ++i)
	{
		countArray[array[i] - min]++;
		if (countArray[array[i] - min] > countArray[mostCommon - min])
		{
			mostCommon = array[i];
		}
	}
	return mostCommon;
}

int main()
{
	int size = 0;
	printf("Please enter array size and array ");
	scanf("%i", &size);
	int* array = malloc(size * sizeof(int));
	for (int i = 0; i < size; ++i)
	{
		scanf("%i", &array[i]);
	}
	printf("The most common element in the array: %i", findMostCommon(array, size));

	return 0;
}