#include "DFA.h"
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
#include <stdio.h>

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