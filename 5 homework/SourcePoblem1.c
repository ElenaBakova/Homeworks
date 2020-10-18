#include "StructStack.h"
#include "Stack.h"
#include "TestStack.h"
#include <stdlib.h>
#include <stdio.h>

int getTheAnswer(char string[])
{
	StackElement* head = NULL;
	for (int i = 0; string[i]; i++)
	{
		int a = 0;
		int b = 0;
		switch (string[i])
		{
		case ' ':
			break;
		case '+':
			a = pop(&head);
			b = pop(&head);
			head = push(head, b + a);
			break;
		case '-':
			a = pop(&head);
			b = pop(&head);
			head = push(head, b - a);
			break;
		case '*':
			a = pop(&head);
			b = pop(&head);
			head = push(head, b * a);
			break;
		case '/':
			a = pop(&head);
			b = pop(&head);
			head = push(head, b / a);
			break;
		default:
			head = push(head, string[i] - '0');
			if (head->value < 0)
				pop(&head);
			break;
		}
	}
	return pop(&head);
}

bool test()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return 0;
	}
	int result = 1;
	for (int i = 0; i < 3; i++)
	{
		char string[20] = "";
		fgets(string, 20, test);
		int answer = 0;
		char space = "";
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
	char string[1000] = "";
	gets(string);
	printf("The result: %i\n", getTheAnswer(string));

	return 0;
}