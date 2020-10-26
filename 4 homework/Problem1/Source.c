#include "Test.h"
#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <stdbool.h>
#include <stdlib.h>

extern const int size;

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
	bool* result = malloc(size * sizeof(bool));
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
	if (!tests())
	{
		printf("����� �� ��������\n");
		return 0;
	}
	printf("����� �������� �������\n");
	int n = 0;
	int k = 0;
	printf("������� ��� �����: ");
	scanf("%i %i", &n, &k);
	bool *binaryK = calloc(size, sizeof(bool));
	bool *binaryN = calloc(size, sizeof(bool));
	decToBin(binaryN, n);
	decToBin(binaryK, k);
	printf("%i � �������������� ����: ", n);
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", binaryN[i]);
	}
	printf("\n%i � �������������� ����: ", k);
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", binaryK[i]);
	}
	bool* additionResult = addition(binaryN, binaryK);
	printf("\n��������� ��������: ");
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", additionResult[i]);
	}
	printf("\n����� � ���������� ����: %i", binToDec(additionResult));

	free(additionResult);
	free(binaryK);
	free(binaryN);
	return 0;
}