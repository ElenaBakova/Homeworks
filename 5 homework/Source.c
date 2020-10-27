#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

bool isOperator(char operator)
{
	return operator == '*' || operator == '-' || operator == '/' || operator == '+';
}

char* postfixToInfix(char string[])
{
	StackElement* head = NULL;
	char output[1000] = "";
	int index = 0;
	for (int i = 0; string[i] != '\0' && string[i] != '\n'; i++)
	{
		if (isdigit(string[i]))
		{
			output[index++] = string[i];
			output[index++] = ' ';
		}
		else if (string[i] == '(')
		{
			head = push(head, '(');
		}
		else if (string[i] == '*' || string[i] == '/')
		{
			while (head != NULL && (top(head) == '*' || top(head) == '/'))
			{
				output[index++] = pop(&head);
				output[index++] = ' ';
			}
			head = push(head, string[i]);
		}
		else if (string[i] == '+' || string[i] == '-')
		{
			while (head != NULL && isOperator(top(head)))
			{
				output[index++] = pop(&head);
				output[index++] = ' ';
			}
			head = push(head, string[i]);
		}
		else if (string[i] == ')')
		{
			while (top(head) != '(')
			{
				if (head == NULL)
				{
					freeStack(&head);
					strcpy(output, "Invalid expression");
					return output;
				}
				output[index++] = pop(&head);
				output[index++] = ' ';
			}
			pop(&head);
		}
		else if (string[i] != ' ')
		{
			freeStack(&head);
			strcpy(output, "Invalid expression");
			return output;
		}
	}
	while (head != NULL)
	{
		char token = pop(&head);
		if (token == '(')
		{
			freeStack(&head);
			strcpy(output, "Invalid expression");
			return output;
		}
		output[index++] = token;
		output[index++] = ' ';
	}
	return output;
}

bool test()
{
	FILE* test = fopen("Test.txt", "r");
	if (test == NULL)
	{
		return false;
	}
	int result = true;
	while (!feof(test))
	{
		char string[1000] = "";
		fgets(string, 1000, test);
		char answer[1000] = "";
		fgets(answer, 1000, test);
		char* output = postfixToInfix(string);
		printf("%s\n", output);
	}
	fclose(test);
	return result;
}

int main()
{
	if (!stackTests())
	{
		printf("Stack tests failed");
		return 1;
	}
	printf("Stack tests succeed\n");
	if (!test())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");

	printf("Please enter an expression\n");
	char string[1000] = "";
	gets(string);
	char *output = postfixToInfix(string);
	printf("%s", output);

	return 0;
}