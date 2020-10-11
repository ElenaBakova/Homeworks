#include <stdio.h>
#include <stdbool.h>

int main()
{
	printf("Hi, what would you like to do?\n0 - exit\n1 - add record (name and phone)\n");
	printf("2 - print all rocords\n3 - find number by name\n4 - find name by number\n5 - save actual data to the file\n");
	while (true)
	{
		printf("Please enter code\n");
		int code = 0;
		scanf("%i", &code);
		if (code == 0)
		{
			printf("Bye");
			return 0;
		}
		if (code == 1)
		{

		}
		else if (code == 2)
		{

		}
		else if (code == 3)
		{

		}
		else if (code == 4)
		{

		}
		else if (code == 5)
		{

		}
	}

	return 0;
}