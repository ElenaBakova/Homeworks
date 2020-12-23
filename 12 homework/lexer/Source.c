#include "DFA.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <string.h>

const int statesNumber = 5;
const int symbolsNumber = 3;

bool check(char* string, char* answer, int** statesTable)
{
	char* resultString = DFA(statesTable, string);
	bool result = strcmp(resultString, answer) == 0;
	free(resultString);
	resultString = NULL;
	return result;
}

bool tests(int** statesTable)
{
	bool result = true;
	result &= check("//*a*//*b*///", "/*a*//*b*/", statesTable);
	result &= check("//******/", "/******/", statesTable);
	result &= check("/*////", "/*////", statesTable);
	result &= check("/*///*/", "/*///*/", statesTable);
	result &= check("/////**", "/**", statesTable);
	result &= check("/*/", "/*/", statesTable);
	result &= check("/**/", "/**/", statesTable);
	result &= check("*//////*aba/caba/daba*bb*/", "/*aba/caba/daba*bb*/", statesTable);
	result &= check("/*gfjshgfjshfgs*/dbd/*dgfsjfdhg*/", "/*gfjshgfjshfgs*//*dgfsjfdhg*/", statesTable);
	return result;
}

int** readTable()
{
	FILE* table = fopen("StatesTable.txt", "r");
	if (table == NULL)
	{
		return NULL;
	}
	int** statesTable = calloc(statesNumber, sizeof(int*));
	for (int i = 0; i < statesNumber; i++)
	{
		statesTable[i] = calloc(symbolsNumber, sizeof(int));
	}
	for (int i = 0; i < statesNumber; i++)
	{
		for (int j = 0; j < symbolsNumber; j++)
		{
			fscanf(table, "%i", &statesTable[i][j]);
		}
	}
	fclose(table);
	return statesTable;
}

void clearTable(int** statesTable)
{
	for (int i = 0; i < statesNumber; i++)
	{
		free(statesTable[i]);
		statesTable[i] = NULL;
	}
	free(statesTable);
	statesTable = NULL;
}

int main()
{
	int** statesTable = readTable();
	if (!tests(statesTable))
	{
		clearTable(statesTable);
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");

	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		return 1;
	}
	while (!feof(input))
	{
		char string[1000] = "";
		fgets(string, 1000, input);
		char* answer = DFA(statesTable, string);
		printf("%s\n", answer);
		free(answer);
	}

	fclose(input);
	clearTable(statesTable);
	return 0;
}