#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

bool isOperator(char operator)
{
	return operator == '*' || operator == '-' || operator == '/' || operator == '+';
}

char* infixToPostfix(char string[])
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
	freeStack(&head);
	return output;
}

bool checkEquality(char string1[], char string2[])
{
	size_t length1 = strlen(string1);
	size_t length2 = strlen(string2);
	if (string1[length1 - 1] == '\n')
	{
		length1--;
	}
	if (string2[length2 - 1] == '\n')
	{
		length2--;
	}
	if (length1 != length2)
	{
		return false;
	}
	for (int i = 0; string2[i] != '\n' && string2[i] != '\0'; i++)
	{
		if (string1[i] != string2[i])
		{
			return false;
		}
	}
	return true;
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
		char string[1000] = "";
		fgets(string, 1000, test);
		char answer[1000] = "";
		fgets(answer, 1000, test);
		char output[1000] = "";
		strcpy(output, infixToPostfix(string));
		result &= checkEquality(output, answer);
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

	printf("Please enter an expression in infix notation\n");
	char string[1000] = "";
	gets(string);
	char *output = infixToPostfix(string);
	if (strcmp(output, "Invalid expression") == 0)
	{
		printf("%s", output);
		return 1;
	}
	printf("Postfix notation: %s", output);

	return 0;
}