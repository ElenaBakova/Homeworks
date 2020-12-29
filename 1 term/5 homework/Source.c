#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

bool isMatchingBracket(char closing, char opening)
{
	return closing == ')' && opening != '(' || closing == ']' && opening != '[' || closing == '}' && opening != '{';
}

bool checkBracketsBalance(char string[])
{
	StackElement* head = NULL;
	for (int i = 0; string[i] != '\0'; i++)
	{
		if (string[i] == '(' || string[i] == '{' || string[i] == '[')
		{
			head = push(head, string[i]);
			continue;
		}
		if ((string[i] == ')' || string[i] == '}' || string[i] == ']') && (head == NULL))
		{
			return false;
		}
		char brace = pop(&head);
		if (isMatchingBracket(string[i], brace))
		{
			freeStack(&head);
			return false;
		}
	}
	if (head == NULL)
	{
		return true;
	}
	freeStack(&head);
	return false;
}

bool test()
{
	return !checkBracketsBalance("()(") && !checkBracketsBalance("}}") && checkBracketsBalance("[]([[]]){}{{}}") && checkBracketsBalance("[[{({})}]]");
}

int main()
{
	if (!stackTests())
	{
		printf("Stack tests failed\n");
		return 0;
	}
	printf("Stack tests succeed\n");
	if (!test())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	printf("Please enter string\n");
	const int size = 500;
	char string[500] = "\0";
	gets_s(string, size);
	if (!checkBracketsBalance(string))
	{
		printf("Brackets are not balanced");
		return 0;
	}
	printf("Brackets are balanced");

	return 0;
}