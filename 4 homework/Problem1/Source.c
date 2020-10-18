#include <stdio.h>
#include <locale.h>
#include <math.h>
#include <stdbool.h>

const int size = sizeof(int) * 8;

void decToBin(bool array[], long long number)
{
	for (int i = 0; i < size; ++i)
	{
		array[i] = number & 1;
		number >>= 1;
	}
}

long long binToDec(const bool array[])
{
	long long decimal = 0;
	long long power = 1;
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

bool testBinToDec()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return 0;
	}
	bool result = true;
	for (int i = 0; i < 2; i++)
	{
		bool* binary = calloc(size);
		for (int j = 0; j < size; j++)
		{
			char symbol = "";
			fscanf(test, "%c", &symbol);
			binary[j] = symbol - '0';
		}
		long long answer = 0;
		fscanf(test, "%li", &answer);
		result &= (binToDec(binary) == answer);
		free(binary);
		char space = "";
		fscanf(test, "%c", &space);
	}
	fclose(test);
	return result;
}

bool compare(const bool first[], const bool second[])
{
	bool result = 1;
	for (int i = 0; i < size; i++)
	{
		result &= (first[i] == second[i]);
	}
	return result;
}

bool testDecToBin()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return 0;
	}
	bool result = true;
	for (int i = 0; i < 2; i++)
	{
		bool* binary = calloc(size);
		for (int j = 0; j < size; j++)
		{
			char symbol = "";
			fscanf(test, "%c", &symbol);
			binary[j] = symbol - '0';
		}
		long long decimal = 0;
		fscanf(test, "%ld", &decimal);
		bool* answer = calloc(size);
		decToBin(answer, decimal);
		result &= compare(answer, binary);
		free(binary);
		free(answer);
		char space = "";
		fscanf(test, "%c", &space);
	}
	fclose(test);
	return result;
}

bool tests()
{
	return testBinToDec() && testDecToBin();
}

int main()
{
	setlocale(LC_ALL, "Rus");
	if (!tests())
	{
		printf("Тесты не пройдены\n");
		return 0;
	}
	printf("Тесты пройдены успешно\n");
	long long n = 0;
	long long k = 0;
	printf("Введите два числа: ");
	scanf("%li %ld", &n, &k);
	bool *binaryK = calloc(size);
	bool *binaryN = calloc(size);
	decToBin(binaryN, n);
	decToBin(binaryK, k);
	printf("%ld в дополнительном коде: ", n);
	for (int i = size - 1; i >= 0; i--)
	{
		printf("%i", binaryN[i]);
	}
	printf("\n%ld в дополнительном коде: ", k);
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
	printf("\nСумма в десятичном виде: %ld", binToDec(additionResult));

	free(additionResult);
	free(binaryK);
	free(binaryN);
	return 0;
}