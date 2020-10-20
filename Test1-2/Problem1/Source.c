#include <stdio.h>
#include <stdlib.h>

typedef struct Array {
	int element;
	int sum;
}Array;

int getMaxSum(Array array[], const int size)
{
	int maxSum = INT_MIN;
	for (int i = 0; i < size; i++)
	{
		int temp = abs(array[i].element);
		array[i].sum = 0;
		while (temp > 0)
		{
			array[i].sum += temp % 10;
			temp /= 10;
		}
		maxSum = maxSum < array[i].sum ? array[i].sum : maxSum;
	}
	return maxSum;
}

int main()
{
	Array array[150] = { 0 };
	int size = 0;
	printf("Please enter size of array and array:");
	scanf("%i", &size);
	for (int i = 0; i < size; i++)
	{
		scanf("%i", &array[i].element);
	}
	int maxSum = getMaxSum(array, size);
	printf("Maximun sum of: %i\n", maxSum);
	printf("Elements that have the same sum of numbers:\n");
	for (int i = 0; i < size; i++)
	{
		if (array[i].sum == maxSum)
		{
			printf("%i\n", array[i].element);
		}
	}

	return 0;
}