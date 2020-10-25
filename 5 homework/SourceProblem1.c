#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdlib.h>
#include <stdio.h>

void getValues(int* a, int* b, StackElement** head)
{
	if (isEmpty(*head))
	{
		printf("Invalid expression");
		exit(0);
	}
	*a = pop(head);
	if (isEmpty(*head))
	{
		printf("Invalid expression");
		exit(0);
	}
	*b = pop(head);
}

int getTheAnswer(char string[])
{
	StackElement* head = NULL;
	for (int i = 0; string[i] != '\0'; i++)
	{
		int a = 0;
		int b = 0;
		switch (string[i])
		{
		case ' ':
			break;
		case '+':
			getValues(&a, &b, &head);
			head = push(head, b + a);
			break;
		case '-':
			getValues(&a, &b, &head);
			head = push(head, b - a);
			break;
		case '*':
			getValues(&a, &b, &head);
			head = push(head, b * a);
			break;
		case '/':
			getValues(&a, &b, &head);
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
	int result = pop(&head);
	if (!isEmpty(head))
	{
		freeStack(&head);
		printf("Invalid expression");
		exit(0);
	}
	return result;
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
		result &= (answer == getTheAnswer(string));
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
	printf("The result: %i\n", getTheAnswer(string));

	return 0;
}