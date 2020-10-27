#include "Stack/Stack.h"
#include "Stack/TestStack.h"
#include <stdio.h>
#include <math.h>

char* postfixToInfix(char string[])
{
	StackElement* head = NULL;
	char output[1000] = "";
	int index = 0;
	for (int i = 0; string[i] != '\0'; i++)
	{
		if (isdigit(string[i]))
		{
			output[index] = string[i];
		}
		else if()
	}
}

int main()
{
	printf("Please enter an expression\n");
	char string[1000] = "";
	gets(string);

	return 0;
}