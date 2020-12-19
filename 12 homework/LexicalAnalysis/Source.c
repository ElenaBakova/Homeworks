#include "FSM.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

bool tests()
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
}

int main()
{
	if (!tests())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");

	printf("Please enter an expression: ");
	char string[10000] = "";
	gets_s(string, 10000);
	bool result = isRealNumber(string);
	if (result)
	{
		printf("It's a real number\n");
		return 0;
	}
	printf("It's not a real number\n");

	return 0;
}