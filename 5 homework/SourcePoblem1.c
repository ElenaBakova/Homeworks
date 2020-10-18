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
		case' ':
			break;
		case '+':
			a = pop(&head);
			b = pop(&head);
			head = push(head, a + b);
			break;
		case '-':
			a = pop(&head);
			b = pop(&head);
			head = push(head, b - a);
			break;
		case '*':
			a = pop(&head);
			b = pop(&head);
			head = push(head, a * b);
			break;
		case '/':
			a = pop(&head);
			b = pop(&head);
			head = push(head, a / b);
			break;
		default:
			head = push(head, string[i] - '0');
			break;
		}
	}
	return pop(&head);
}

int main()
{
	if (!StackTests())
	{
		printf("Stack tests failed\n");
		return 0;
	}
	printf("Stack tests succeed\n");
	char string[1000] = "";
	gets(string);
	printf("%i", getTheAnswer(string));

	return 0;
}