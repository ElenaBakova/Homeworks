#include "Tests.h"
#include "Struct.h"
#include "Searching.h"
#include <stdio.h>
#include <stdbool.h>
#include <string.h>

void printRecords(const struct PhoneBook array[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%s -- %s\n", array[i].name, array[i].number);
	}
}

void saveDataToFile(const int size, const struct PhoneBook array[])
{
	FILE* phones = fopen("Phone_Book.txt", "w");
	if (phones == NULL)
	{
		printf("File not found!");
		return;
	}
	for (int i = 0; i < size; i++)
	{
		fprintf(phones, "%s %s\n", array[i].name, array[i].number);
	}
	fclose(phones);
}

bool readInitialDirectory(struct PhoneBook records[], int *countRecords)
{
	FILE* phones = fopen("Phone_Book.txt", "r");
	if (phones == NULL)
	{
		printf("File not found!");
		return 1;
	}
	while (!feof(phones))
	{
		fscanf(phones, "%s %s", &records[*countRecords].name, &records[*countRecords].number);
		(*countRecords)++;
	}
	fclose(phones);
	return 0;
}

int main()
{
	if (!tests())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");
	struct PhoneBook records[100];
	int countRecords = 0;
	if (readInitialDirectory(records, &countRecords))
	{
		return 0;
	}

	printf("What would you like to do?\n0 - exit\n1 - add record (name and phone)\n");
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
			printf("Enter name: ");
			char name[20];
			scanf("%s", &name);
			printf("%s\n", findNumber(name, countRecords, records));
			break;
		case 4:
			printf("Enter number: ");
			char number[12];
			scanf("%s", &number);
			printf("%s\n", findName(number, countRecords, records));
			break;
		case 5:
			saveDataToFile(countRecords, records);
			break;
		default: 
			printf("Incorrect data\n");
			break;
		}
	}

	return 0;
}