#include <stdio.h>
#include <string.h>

int main()
{
	char string[100000];
	printf("%s\n", "Input string of brackets");
	scanf("%s", &string);
	int opened = 0;
	for (int i = 0; i < strlen(string); ++i)
	{
		if (string[i] == '(')
		{
			opened++;
		}
		else if (opened == 0)
		{
			printf("%s", "Not balanced");
			return 0;
		}
		else
		{
			opened--;
		}
	}
	if (opened == 0)
	{
		printf("%s", "Balanced");
	}
	else
	{
		printf("%s", "Not balanced");
	}

	return 0;
}