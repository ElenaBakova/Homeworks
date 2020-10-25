#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdlib.h>
#include <stdio.h>

bool getValues(int* a, int* b, StackElement** head)
{
	if (isEmpty(*head))
	{
		return 1;
	}
	*a = pop(head);
	if (isEmpty(*head))
	{
		return 1;
	}
	*b = pop(head);
	return 0;
}

bool getTheAnswer(char string[], int *result)
{
	StackElement* head = NULL;
	for (int i = 0; string[i] != '\0'; i++)
	{
		int a = 0;
		int b = 0;
		if ((string[i] == '+' || string[i] == '*' || string[i] == '/' || string[i] == '-') && getValues(&a, &b, &head))
		{
			return 1;
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
			head = push(head, string[i] - '0');
			if (head->value < 0)
			{
				pop(&head);
			}
			break;
		}
	}
	*result = pop(&head);
	if (!isEmpty(head))
	{
		freeStack(&head);
		return 1;
	}
	return 0;
}

bool test()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return 0;
	}
	int result = 1;
	while (!feof(test))
	{
		char string[100] = "\0";
		fgets(string, 100, test);
		int answer = 0;
		char space = '\0';
		fscanf(test, "%i%c", &answer, &space);
		int value = 0;
		if (getTheAnswer(string, &value))
		{
			return 0;
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
		return 0;
	}
	printf("Stack tests succeed\n");
	if (!test())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	printf("Please enter an expression:");
	char string[1000] = "\0";
	gets(string);
	int answer = 0;
	if (getTheAnswer(string, &answer))
	{
		printf("Invalid expression");
		return 0;
	}
	printf("The result: %i\n", answer);

	return 0;
}