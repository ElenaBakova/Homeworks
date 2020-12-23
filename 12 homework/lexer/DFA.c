#include "DFA.h"
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>

char* substr(char* string, int start, int finish)
{
	char* substring = calloc(finish - start + 2, sizeof(char));
	if (substring == NULL)
	{
		return NULL;
	}
	for (int i = start; i <= finish; i++)
	{
		substring[i - start] = string[i];
		substring[i - start + 1] = '\0';
	}
	return substring;
}

char* DFA(int** statesTable, char* string)
{
	char* answer = calloc(strlen(string), sizeof(char));
	if (answer == NULL)
	{
		return NULL;
	}
	int state = 0;
	int current = 0;
	int start = -1;
	while (true)
	{
		if (state == 1)
		{
			start = current - 1;
		}
		if (state == 4 && start != -1)
		{
			char* substring = substr(string, start, current - 1);
			strcat(answer, substring);
			free(substring);
			substring = NULL;
			start = -1;
		}
		char token = string[current];
		if (token == '*')
		{
			state = statesTable[state][0];
		}
		else if (token == '/')
		{
			state = statesTable[state][1];
		}
		else if (token == '\0' || token == '\n')
		{
			return answer;
		}
		else
		{
			state = statesTable[state][2];
		}
		current++;
	}
}