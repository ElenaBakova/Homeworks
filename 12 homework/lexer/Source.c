#include "DFA.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

const int statesNumber = 5;
const int symbolsNumber = 3;

/*bool tests()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return false;
	}
	FILE* answers = fopen("answer.txt", "r");
	if (answers == NULL)
	{
		fclose(test);
		return false;
	}
	bool result = true;
	while (!feof(test))
	{
		char string[1000] = "";
		int answer = 0;
		fgets(string, 1000, test);
		fscanf(answers, "%i", &answer);
		result &= isRealNumber(string) == answer;
	}

	fclose(test);
	fclose(answers);
	return result;
}*/

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

int main()
{
	/*if (!tests())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");

	printf("Please enter an expression: ");
	char string[10000] = "";
	gets_s(string, 10000);
	if (isRealNumber(string))
	{
		printf("It's a real number\n");
		return 0;
	}
	printf("It's not a real number\n");*/
	int **statesTable = readTable();
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
		printf("%s", answer);
	}

	for (int i = 0; i < statesNumber; i++)
	{
		free(statesTable[i]);
		statesTable[i] = NULL;
	}
	free(statesTable);
	statesTable = NULL;
	return 0;
}