#include <stdio.h>
#include <math.h>

int division(int c, int d)
{
	int divisionAnswer = 0;
	c = abs(c);
	d = abs(d);
	while (c - d >= 0)
	{
		c -= d;
		divisionAnswer++;
	}
	return divisionAnswer;
}

int whatDigit(int n, int m)
{
	return (n * m > 0 ? 1 : -1);
}

int main()
{
	int a = 0;
	int b = 0;
	printf("%s\n", "Please, enter two integers");
	scanf("%i %i", &a, &b);
	if (b == 0)
	{
		printf("%s\n", "Wrong input data");
		return 0;
	}

	int answer = division(a, b);
	if (whatDigit(a, b) == -1)
	{
		answer = -answer;
	}
	if (answer * b > a)
	{
		answer += whatDigit(a, b);
	}
	printf("%i\n", answer);
	
	return 0;
}