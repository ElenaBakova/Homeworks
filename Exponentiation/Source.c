#include <stdio.h>
#include <math.h>

long long exponentiation(const long long base, const int power)
{
	long long answer = 1;
	for (int i = 0; i < power; ++i)
	{
		answer *= base;
	}
	return answer;
}

int testLinear(void)
{
	return (exponentiation(5, 0) == 1 && exponentiation(4, 4) == 256 && exponentiation(2, 40) == 1099511627776 && exponentiation(-13, 2) == 169 && exponentiation(-5, 3) == -125);
}

long long exponentiationLogn(const long long base, int power)
{
	if (power == 0)
	{
		return 1;
	}
	if (power % 2 == 0)
	{
		long long result = exponentiationLogn(base, power / 2);
		return result * result;
	}
	return exponentiationLogn(base, power - 1) * base;
}

int testLogarifmic(void)
{
	return (exponentiationLogn(33, 0) == 1 && exponentiationLogn(9, 9) == 387420489 && exponentiationLogn(-5, 10) == 9765625 && exponentiationLogn(-13, 5) == -371293 && exponentiationLogn(2, 32) == 4294967296);
}

int main()
{
	printf("%s\n", "Please, enter base and power -- a and b");
	long long base = 0;
	int power = 0;
	scanf("%lld %i", &base, &power);
	if (power < 0)
	{
		printf("Power should be positive");
		return 0;
	}
	if (base == 0 && power == 0)
	{
		printf("0 power 0 is undefined");
		return 0;
	}

	printf("Linear running time:\n");
	if (testLinear() == 0)
	{
		printf("  Tests failed\n");
	}
	else
	{
		printf("  Tests succeed\n  a power b = %lld\n", exponentiation(base, power));
	}

	printf("\nO(log b) running time:\n");
	if (testLogarifmic() == 0)
	{
		printf("  Tests failed\n");
		return 0;
	}
	else
	{
		printf("  Tests succeed\n  a power b = %lld\n", exponentiationLogn(base, power));
	}

	return 0;
}