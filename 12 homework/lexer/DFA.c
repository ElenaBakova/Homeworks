#include "DFA.h"
#include <stdbool.h>
#include <stdio.h>

void DFA(void)
{
	FILE* table = fopen("StatesTable.txt", "r");
	if (table == NULL)
	{
		return;
	}
	int statesTable[5][3] = { 0 };
	for (int i = 0; i < 5; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			fscanf(table, "%i", &statesTable[i][j]);
		}
	}
	fclose(table);

}