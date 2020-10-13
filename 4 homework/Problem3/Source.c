#include <stdio.h>
#include <stdbool.h>

struct phoneBook{
	char name[20];
	char number[11];
};

void printRecords(const struct phoneBook array[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%s -- %s\n", array[i].name, array[i].number);
	}
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


int main()
{
	FILE* phones = fopen("Phone_Book.txt", "r");
	if (phones == NULL)
	{
		printf("File not found!");
		return -1;
	}
	printf("Hi, what would you like to do?\n0 - exit\n1 - add record (name and phone)\n");
	printf("2 - print all rocords\n3 - find number by name\n4 - find name by number\n5 - save actual data to the file\n");
	struct phoneBook records[100];
	int countRecords = 0;
	while (true)
	{
		printf("Please enter code\n");
		int code = 0;
		scanf("%i", &code);
		switch (code)
		{
		case 1:
			if (countRecords >= 100)
			{
				printf("Can't add more than 100 records\n");
				continue;
			}
			printf("Please enter name no greater than 20 symbols and phone number - 11 digits, without spaces: ");
			scanf("%s %s", &records[countRecords].name, &records[countRecords].number);
			countRecords++;
			break;
		case 2:
			printRecords(records, countRecords);
			break;
		case 3:
		case 4:
		case 5:
		default: 
			return 0;
		}

	}

	fclose(phones);
	return 0;
}