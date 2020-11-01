#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>

bool getValues(int* a, int* b, StackElement** head)
{
	if (isEmpty(*head))
	{
		return true;
	}
	*a = pop(head);
	if (isEmpty(*head))
	{
		return true;
	}
	*b = pop(head);
	return false;
}

bool isOperator(char symbol)
{
	return symbol == '+' || symbol == '*' || symbol == '/' || symbol == '-';
}

bool getAnExpressionValue(char string[], int *result)
{
	StackElement* head = NULL;
	for (int i = 0; string[i] != '\0'; i++)
	{
		int a = 0;
		int b = 0;
		if (isdigit(string[i]))
		{
			head = push(head, string[i] - '0');
			continue;
		}
		if (isOperator(string[i]) && getValues(&a, &b, &head))
		{
			freeStack(&head);
			return true;
		}
		switch (string[i])
		{
		case '+':
			head = push(head, b + a);
			break;
		case '-':
			head = push(head, b - a);
			break;
		case '*':
			head = push(head, b * a);
			break;
		case '/':
			head = push(head, b / a);
			break;
		default:
			break;
		}
	}
	*result = pop(&head);
	if (!isEmpty(head))
	{
		freeStack(&head);
		return true;
	}
	return false;
}

bool test()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return false;
	}
	bool result = true;
	while (!feof(test))
	{
		char string[100] = "";
		fgets(string, 100, test);
		int answer = 0;
		fscanf(test, "%i%*c", &answer);
		int value = 0;
		if (getAnExpressionValue(string, &value))
		{
			return false;
		}
		result &= (answer == value);
	}
	fclose(test);
	return result;
}

int main()
{
	if (!stackTests())
	{
		printf("Stack tests failed\n");
		return 1;
	}
	printf("Stack tests succeed\n");
	if (!test())
	{
		printf("Tests failed\n");
		return 1;
	}
	printf("Tests succeed\n");
	printf("Please enter an expression: ");
	char string[1000] = "";
	gets(string);
	int answer = 0;
	if (getAnExpressionValue(string, &answer))
	{
		printf("Invalid expression");
		return 0;
	}
	printf("The result: %i\n", answer);

	return 0;
}