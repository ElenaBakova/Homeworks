#include "DFA.h"
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>

const int statesNumber = 5;
const int symbolsNumber = 3;

int getIndex(char token)
{
	if (token == '*')
	{
		return 0;
	}
	else if (token == '/')
	{
		return 1;
	}
	return 2;
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

char* DFA(int** statesTable, char* string)
{
	char* answer = calloc(strlen(string) + 2, sizeof(char));
	if (answer == NULL)
	{
		return NULL;
	}
	int state = 0;
	int current = 0;
	while (true)
	{
		char token = string[current];
		if (state == 1 && token == '*')
		{
			strcat(answer, "/*");
		}
		else if (state == 3 && token == '/')
		{
			strcat(answer, "/");
		}
		else if (state > 1 && state < 4)
		{
			answer[strlen(answer)] = token;
			answer[strlen(answer) + 1] = '\0';
		}
		if (token == '\0' || token == '\n')
		{
			return answer;
		}
		state = statesTable[state][getIndex(token)];
		current++;
	}
}