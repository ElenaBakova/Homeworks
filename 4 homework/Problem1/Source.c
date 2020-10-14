#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <stdbool.h>

int decToBin(int array[], int number)
{
	int i = 0;
	while (number > 1)
	{
		array[i] = number & 1 ? 1 : 0;
		number >>= 1;
		i++;
	}
	array[i] = number;
	return ++i;
}

int binToDec(const int array[], const int size)
{
	int decimal = 0;
	int power = 1;
	for (int i = 0; i < size; i++)
	{
		decimal += array[i] * power;
		power <<= 1;
	}
	return decimal;
}


void twosComplement(int array[], int *size)
{
	for (int i = 0; i < *size; i++)
	{
		array[i] ^= 1;
	}
	int j = 0;
	array[0] += 1;
	while(j < *size)
	{
		int temp = array[j];
		array[j] %= 2;
		array[j + 1] += temp / 2;
		j++;
	}
	if (array[j] == 1)
	{
		(*size)++;
	}
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int n = 0;
	int k = 0;
	printf("¬ведите данные: ");
	scanf("%i %i", &n, &k);
	int binaryK[20] = { 0 };
	int binaryN[20] = { 0 };
	int nSize = decToBin(binaryN, abs(n));
	int kSize = decToBin(binaryK, abs(k));
	if (n < 0)
	{
		twosComplement(binaryN, &nSize);
	}
	if (k < 0)
	{
		twosComplement(binaryK, &kSize);
	}
	int resultArray[20] = { 0 };
	/* for (int i = 0; i < nSize; i++)
		printf("%i", binaryN[i]);
	printf("%i", binToDec(binaryN, nSize));*/

	return 0;
}