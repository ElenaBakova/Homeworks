#include <stdio.h>
#include <stdbool.h>

void addRecord()
{

}

void printRecords()
{

}

void findNumber()
{

}

void findName()
{

}

void saveDataToFile()
{

}

struct {
	int phone;
}phoneBook;

int main()
{
	FILE* phoneBook = fopen("Phone_Book.txt", "r");
	if (phoneBook == NULL)
	{
		printf("File not found!");
		return -1;
	}
	printf("Hi, what would you like to do?\n0 - exit\n1 - add record (name and phone)\n");
	printf("2 - print all rocords\n3 - find number by name\n4 - find name by number\n5 - save actual data to the file\n");
	while (true)
	{
		printf("Please enter code\n");
		int code = 0;
		scanf("%i", &code);
		switch (code)
		{
		case 0:
			return 0;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		default: 
			return 0;
		}

	}

	fclose(phoneBook);
	return 0;
}