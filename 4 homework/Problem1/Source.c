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
		bool* binary = calloc(size, sizeof(bool));
		for (int j = 0; j < size; j++)
		{
			char symbol = "";
			fscanf(test, "%c", &symbol);
			binary[j] = symbol - '0';
		}
		int answer = 0;
		fscanf(test, "%i", &answer);
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
		bool* binary = calloc(size, sizeof(bool));
		for (int j = 0; j < size; j++)
		{
			char symbol = "";
			fscanf(test, "%c", &symbol);
			binary[j] = symbol - '0';
		}
		int decimal = 0;
		fscanf(test, "%i", &decimal);
		bool* answer = calloc(size, sizeof(bool));
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

bool testAddition()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return 0;
	}

	bool result = true;
	bool* binaryN = calloc(size, sizeof(bool));
	for (int j = 0; j < size; j++)
	{
		char symbol = "";
		fscanf(test, "%c", &symbol);
		binaryN[j] = symbol - '0';
	}
	int decimalN = 0;
	fscanf(test, "%i", &decimalN);
	char space = "";
	fscanf(test, "%c", &space);
	bool* binaryK = calloc(size, sizeof(bool));
	for (int j = 0; j < size; j++)
	{
		char symbol = "";
		fscanf(test, "%c", &symbol);
		binaryK[j] = symbol - '0';
	}
	int decimalK = 0;
	fscanf(test, "%i", &decimalK);
	bool* binSum = calloc(size, sizeof(bool));
	binSum = addition(binaryK, binaryN);
	free(binaryN);
	free(binaryK);
	bool* decSum = calloc(size, sizeof(bool));
	decToBin(decSum, decimalK + decimalN);
	result &= compare(decSum, binSum);

	free(binSum);
	free(decSum);
	fclose(test);
	return result;
}

bool tests()
{
	return testBinToDec() && testDecToBin() && testAddition();
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
	int n = 0;
	int k = 0;
	printf("Введите два числа: ");
	scanf("%i %i", &n, &k);
	bool *binaryK = calloc(size, sizeof(bool));
	bool *binaryN = calloc(size, sizeof(bool));
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