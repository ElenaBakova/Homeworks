#include "Graph/TestList.h"
#include "Test.h"
#include <stdio.h>

bool tests()
{
	if (!listTests())
	{
		printf("List tests failed");
		return false;
	}
	printf("List tests succeed\n");

	return true;
}