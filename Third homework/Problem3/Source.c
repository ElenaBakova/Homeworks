#include <stdio.h>
#include <stdlib.h>

void swap(int* a, int* b)
{
	const int temp = *a;
	*a = *b;
	*b = temp;
}


int findMostCommon(const int array[], const int size)
{
	int mostCommon = 0;
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
	quickSort(array, 0, size - 1);
	printf("The most common element in the array: %i", findMostCommon(array, size));

	free(array);
	return 0;
}