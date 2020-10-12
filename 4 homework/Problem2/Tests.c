#include "Tests.h"
#include "Sort.h"
#include <stdbool.h>

int findMostCommon(const int array[], const int size);

bool testSingle(void)
{
	int array[1] = { 52342 };
	return findMostCommon(array, 1) == 52342;
}

bool testDifferent(void)
{
	const int size = 10;
	int array[10] = { 15, 40, 15, 15, 10, 4, 15, 3, 3, 3 };
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == 15;
}

bool testEvenQuantity(void)
{
	const int size = 8;
	int array[8] = { 8, 6, 9, 7, 5, 10, 4, 11 };
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == 4;
}

bool testEven(void)
{
	const int size = 5;
	int array[5] = { -72, -72, -72, -72, -72 };
	quickSort(array, 0, size - 1);
	return findMostCommon(array, size) == -72;
}

bool tests(void)
{
	return testSingle() && testDifferent() && testEvenQuantity() && testEven();
}