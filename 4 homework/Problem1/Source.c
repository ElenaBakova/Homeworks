#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <stdbool.h>

const int size = sizeof(int) * 8;

void decToBin(bool array[], int number)
{
	for (int i = 0; i < size; ++i)
	{
		array[i] = number & 1;
		number >>= 1;
	}
}

int binToDec(const bool array[])
{
	int decimal = 0;
	int power = 1;
	for (int i = 0; i < size; i++)
	{
		decimal |= array[i] * power;
		power <<= 1;
	}
	return decimal;
}

bool* addition(const bool first[], const bool second[])
{
	bool* result = malloc(size);
	bool carry = false;
	for (int i = 0; i < size; i++)
	{
		result[i] = first[i] ^ second[i] ^ carry;
		carry = (first[i] && second[i]) || (first[i] && carry) || (second[i] && carry);
	}
	return result;
}

int main()
{
	setlocale(LC_ALL, "Rus");
	int n = 0;
	int k = 0;
	printf("Введите два числа: ");
	scanf("%i %i", &n, &k);
	bool *binaryK = calloc(size);
	bool *binaryN = calloc(size);
	decToBin(binaryN, n);
	decToBin(binaryK, k);
	printf("%i в дополнительном коде: ", n);
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", binaryN[i]);
	}
	printf("\n%i в дополнительном коде: ", k);
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", binaryK[i]);
	}
	bool* additionResult = addition(binaryN, binaryK);
	printf("\nРезультат сложения: ");
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", additionResult[i]);
	}
	printf("\nСумма в десятичном виде: %i", binToDec(additionResult));

	free(additionResult);
	free(binaryK);
	free(binaryN);
	return 0;
}