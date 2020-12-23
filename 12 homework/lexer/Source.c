#include "DFA.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <string.h>

const int statesNumber = 5;
const int symbolsNumber = 3;

bool tests(int** statesTable)
{
	bool result = true;
	result &= strcmp(DFA(statesTable, "//*a*//*b*///"), "/*a*//*b*/") == 0;
	result &= strcmp(DFA(statesTable, "//******/"), "/******/") == 0;
	result &= strcmp(DFA(statesTable, "/*////"), "") == 0;
	result &= strcmp(DFA(statesTable, "/*///*/"), "/*///*/") == 0;
	result &= strcmp(DFA(statesTable, "/////**"), "") == 0;
	result &= strcmp(DFA(statesTable, "/*/"), "") == 0;
	result &= strcmp(DFA(statesTable, "/**/"), "/**/") == 0;
	result &= strcmp(DFA(statesTable, "*//////*aba/caba/daba*bb*/"), "/*aba/caba/daba*bb*/") == 0;
	result &= strcmp(DFA(statesTable, "/*hsfgfjshgfjshfgs*/dbsghd/*jhdfgsjdgfsjfdhg*/"), "/*hsfgfjshgfjshfgs*//*jhdfgsjdgfsjfdhg*/") == 0;

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

	printf("Please enter string ");
	char string[1000] = "";
	gets_s(string, 1000);
	char* answer = DFA(statesTable, string);
	if (answer == NULL || strlen(answer) < 1)
	{
		printf("No comments found");
	}
	else
	{
		printf("Comments: %s", answer);
	}

	clearTable(statesTable);
	return 0;
}