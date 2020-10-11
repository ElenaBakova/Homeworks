#include "Sort.h"
#include <stdio.h>
#include <stdlib.h>

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