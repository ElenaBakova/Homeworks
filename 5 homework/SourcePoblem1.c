#include "StructStack.h"
#include "Stack.h"
#include "TestStack.h"
#include <stdlib.h>
#include <stdio.h>

int main()
{
	if (!tests())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	StackElement* head = NULL;
	char string[1000] = "";
	gets(string);
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
	printf("%i", pop(&head));

	return 0;
}