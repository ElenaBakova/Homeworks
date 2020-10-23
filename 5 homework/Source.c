#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

bool getTheAnswer(char string[])
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
			return 0;
		}
		char brace = pop(&head);
		if (string[i] == ')' && brace != '(' || string[i] == ']' && brace != '[' || string[i] == '}' && brace != '{')
		{
			return 0;
		}
	}
	return head == NULL;
}

bool test()
{
	return !getTheAnswer("()(") && !getTheAnswer("}}") && getTheAnswer("[]([[]]){}{{}}") && getTheAnswer("[[{({})}]]");
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
	if (!getTheAnswer(string))
	{
		printf("Braces are not balanced");
		return 0;
	}
	printf("Braces are balanced");

	return 0;
}