#include <stdio.h>
#include <math.h>

void sieve(int array[100000], int maximumn)
{
	for (int i = 2; i * i <= maximumn; ++i)
	{
		if (array[i] == 0)
		{
			for (int j = i * i; j <= maximumn; j += i)
			{
				array[j] = 1;
			}
		}
	}
}

int main()
{
	printf("%s\n", "Please, enter a number less than 100000");
	int n = 0;
	int prime[100000] = {0};
	prime[0] = 1;
	prime[1] = 1;
	scanf("%i", &n);
	sieve(prime, n);
	printf("%s %i:\n", "All prime numbers not greater than", n);
	for (int i = 2; i <= n; ++i)
	{
		if (prime[i] == 0)
		{
			printf("%i ", i);
		}
	}

	return 0;
}