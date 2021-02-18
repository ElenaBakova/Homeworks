#include <stdio.h>

void flip(int array[], int left, int right)
{
	for (int i = left; i < right - i + left; ++i)
	{
		array[i] += array[right - i + left];
		array[right - i + left] = array[i] - array[right - i + left];
		array[i] -= array[right - i + left];
	}
}

int main()
{
	int arrayX[10000];
	printf("%s\n", "Input two integers - endpoints");
	int m = 0;
	int n = 0;
	scanf("%i %i", &m, &n);
	if (n + m >= 10000)
	{
		printf("Numbers are too big");
		return 0;
	}
	printf("%s\n", "Input an array");
	for (int i = 1; i <= n + m; ++i)
	{
		scanf("%i", &arrayX[i]);
	}
	flip(arrayX, 1, m);
	flip(arrayX, m + 1, n + m);
	flip(arrayX, 1, n + m);
	printf("%s\n", "Changed array:");
	for (int i = 1; i <= n + m; ++i)
	{
		printf("%i ", arrayX[i]);
	}

	return 0;
}