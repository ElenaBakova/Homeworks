#include "StructStack.h"
#include "Stack.h"
#include <stdbool.h>
#include <stdlib.h>

bool testPushPop()
{
	struct StackElement* head = NULL;
	head = push(head, 45);
	head = push(head, 46);
	head = push(head, 47);
	bool result = (head != NULL);
	int k = 47;
	while (!empty(head))
	{
		result &= (pop(&head) == k);
		k--;
	}
	freeStack(&head);
	return result;
}

bool StackTests()
{
	return testPushPop();
}