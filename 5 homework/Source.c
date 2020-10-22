#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>

bool getTheAnswer()
{
	const int size = 500;
	char string[500] = "0";
	StackElement* head = NULL;
	gets_s(string, size);
	for (int i = 0; string[i] != '\0'; i++)
	{
		if (string[i] == '(' || string[i] == '{' || string[i] == '[')
		{
			head = push(head, string[i]);
		}
		if ((string[i] == ')' || string[i] == '}' || string[i] == ']') && (head == NULL))
		{
			return 1;
		}
		char brace = pop(&head);
		if (string[i] == ')' && brace != '(' || string[i] == ']' && brace != '[' || string[i] == '}' && brace != '{')
		{
			return 1;
		}
	}
	return head == NULL;
}

int main()
{
	if (!stackTests())
	{
		printf("Stack tests failed\n");
		return 0;
	}
	printf("Stack tests succeed\n");
	if (getTheAnswer())
	{
		printf("Not ok");
		return 0;
	}
	printf("Ok");
	//char string[500] = "0";
	//gets_s(string, 10);
	//StackElement* head = NULL;
	//head = push(head, string[0]);
	//printf("%c", pop(&head));

	return 0;
}