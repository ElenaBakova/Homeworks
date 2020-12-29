#include "TestStack.h"
#include "Stack.h"
#include <stdbool.h>
#include <stdlib.h>

bool testPushPop()
{
	StackElement* head = NULL;
	head = push(head, 45);
	head = push(head, 46);
	head = push(head, 47);
	bool result = (head != NULL);
	int k = 47;
	while (!isEmpty(head))
	{
		result &= (pop(&head) == k);
		k--;
	}
	freeStack(&head);
	return result;
}

bool testTop()
{
	StackElement* head = NULL;
	if (head = NULL)
	{
		return 0;
	}
	head = push(head, 45);
	head = push(head, 46);
	return top(head) == 46;
}

bool stackTests()
{
	return testPushPop() && testTop();
}