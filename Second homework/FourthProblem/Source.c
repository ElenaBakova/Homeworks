#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stddef.h>
#include <conio.h>

void printArray(const int array[], const size_t SIZE)
{
	for (int i = 0; i < SIZE; ++i)
	{
		printf("%i ", array[i]);
	}
	printf("\n");
}

void makeArray(int array[], const size_t SIZE)
{
	for (int i = 0; i < SIZE; ++i)
	{
		array[i] = rand() % 1000;
	}
}

void rearranging(int array[], const size_t SIZE)
{
	int left = 0; 
	int right = SIZE - 1;
	int prop = array[0];
	while (left < right)
	{
		while (array[left] < prop && left < right)
		{
			left++;
		}
		while (array[right] >= prop && left < right)
		{
			right--;
		}
		const int temp = array[left];
		array[left] = array[right];
		array[right] = temp;
	}
}

int check(const int array[], const size_t SIZE, const int prop)
{
	int i = 0;
	while (array[i] < prop && i < SIZE)
	{
		i++;
	}
	while (array[i] >= prop && i < SIZE)
	{
		i++;
	}
	return i == SIZE;
}

int testFirst()
{
	const size_t SIZE = 7;
	int array[7] = { -1, 5, 9, -2, -1, -1, -1 };
	int prop = array[0];
	rearranging(array, SIZE);
	return check(array, SIZE, prop);
}

int testSecond()
{
	const size_t SIZE = 11;
	int array[11] = {3, 9, 10, 11, 8, 7, 2, 1, 2, 1, 2};
	int prop = array[0];
	rearranging(array, SIZE);
	return check(array, SIZE, prop);
}

int tests()
{
	return testFirst() && testSecond();
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
	const size_t SIZE = 10;
	int array[10];

	makeArray(array, SIZE);
	printf("Initial array: ");
	printArray(array, SIZE);

	rearranging(array, SIZE);
	printf("Rearranged array: ");
	printArray(array, SIZE);

	return 0;
}