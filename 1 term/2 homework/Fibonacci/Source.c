#include <stdio.h>
#include <math.h>
#include <stdbool.h>

long long fibonacciIterative(long long fibonacciNumber)
{
	if (fibonacciNumber < 0)
	{
		return -1;
	}
	if (fibonacciNumber == 0)
	{
		return 0;
	}
	if (fibonacciNumber < 3)
	{
		return 1;
	}
	long long first = 1;
	long long second = 1;
	long long answer = 0;
	for (int i = 0; i < fibonacciNumber - 2; ++i)
	{
		answer = first + second;
		first = second;
		second = answer;
	}
	return answer;
}

int testIterative(void)
{
	return (fibonacciIterative(0) == 0 && fibonacciIterative(42) == 267914296 && fibonacciIterative(23) == 28657 && fibonacciIterative(-33) == -1);
}

long long fibonacciRecursive(long long fibonacciNumber)
{
	if (fibonacciNumber < 0)
	{
		return -1;
	}
	if (fibonacciNumber == 0)
	{
		return 0;
	}
	if (fibonacciNumber < 3)
	{
		return 1;
	}
	return fibonacciRecursive(fibonacciNumber - 1) + fibonacciRecursive(fibonacciNumber - 2);
}

int testRecursive(void)
{
	return (fibonacciRecursive(0) == 0 && fibonacciRecursive(12) == 144 && fibonacciRecursive(34) == 5702887 && fibonacciRecursive(-11) == -1);
}

int main()
{
	printf("Please, enter the number from 0 to 46\n");
	long long number = 0;
	scanf("%lld", &number);
	printf("Iterative: ");
	if (testIterative() == 0)
	{
		printf("Tests failed\n");
	}
	else
	{
		printf("Tests succeed\n");
		printf("Answer: %lld\n", fibonacciIterative(number));
	}
	printf("Recursive: ");
	if (testRecursive() == 0)
	{
		printf("Tests failed\n");
	}
	else
	{
		printf("Tests succeed\n");
		printf("Answer: %lld\n", fibonacciRecursive(number));
	}

	return 0;
}