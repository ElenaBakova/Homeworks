#include <stdio.h>

int main()
{
	int sumCount[30] = {0};
	for (int i = 0; i < 1000; ++i)
	{
		int sumI = i % 10 + (i % 100) / 10 + i / 100;
		sumCount[sumI]++;
	}
	int answer = 0;
	for (int i = 0; i < 28; ++i)
	{
		answer += sumCount[i] * sumCount[i];
	}
	printf("%s%i", "Total number of lucky tickets:", answer);

	return 0;
}