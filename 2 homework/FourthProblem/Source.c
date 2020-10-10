#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <stddef.h>
#include <conio.h>

void printArray(const int array[], const size_t size)
{
	for (int i = 0; i < size; ++i)
	{
		printf("%i ", array[i]);
	}
	printf("\n");
}

void makeArray(int array[], const size_t size, const int temp)
{
	for (int i = 0; i < size; ++i)
	{
		array[i] = temp == 0 ? rand() % 1000 : temp;
	}
}

void rearranging(int array[], const size_t size)
{
	int left = 0; 
	int right = size - 1;
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

int check(const int array[], const size_t size, const int prop)
{
	int i = 0;
	while (array[i] < prop && i < size)
	{
		i++;
	}
	while (array[i] >= prop && i < size)
	{
		i++;
	}
	return i == size;
}

int testFirst()
{
	const size_t size = 7;
	int array[7] = { -1, 5, 9, -2, -1, -1, -1 };
	int prop = array[0];
	rearranging(array, size);
	return check(array, size, prop);
}

int testSecond()
{
	const size_t size = 11;
	int array[11] = {3, 9, 10, 11, 8, 7, 2, 1, 2, 1, 2};
	int prop = array[0];
	rearranging(array, size);
	return check(array, size, prop);
}

int testSingle()
{
	int array[1] = {271818};
	rearranging(array, 1);
	return array[0] == 271818;
}

int testEven()
{
	const size_t size = 14;
	int array[14];
	makeArray(array, size, rand() % 100 + 1000);
	int prop = array[0];
	rearranging(array, size);
	return check(array, size, prop);
}

int tests()
{
	return testFirst() && testSecond() && testSingle() && testEven();
}

int main()
{
	srand(time(NULL));
	testEven();
	if (tests() == 0)
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	const size_t size = 10;
	int array[10];

	makeArray(array, size, 0);
	printf("Initial array: ");
	printArray(array, size);

	rearranging(array, size);
	printf("Rearranged array: ");
	printArray(array, size);

	return 0;
}