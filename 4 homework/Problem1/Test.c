#include "Test.h"
#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>

const int size = sizeof(int) * 8;

void decToBin(bool array[], int number);

int binToDec(const bool array[]);

bool* addition(const bool first[], const bool second[]);

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
			char symbol = "0";
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