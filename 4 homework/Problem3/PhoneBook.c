#include "PhoneBook.h"
#include <stdbool.h>
#include <stdlib.h>
#include <stdio.h>

char* findNumber(const char name[], const int size, struct PhoneBook array[])
{
	for (int i = 0; i < size; i++)
	{
		if (strcmp(name, array[i].name) == 0)
		{
			return array[i].number;
		}
	}
	return "Not found";
}

char* findName(const char number[], const int size, struct PhoneBook array[])
{
	for (int i = 0; i < size; i++)
	{
		if (strcmp(number, array[i].number) == 0)
		{
			return array[i].name;
		}
	}
	return "Not found";
}

void printRecords(const struct PhoneBook array[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%s -- %s\n", array[i].name, array[i].number);
	}
}

void saveDataToFile(const int size, const struct PhoneBook array[], const char file[])
{
	FILE* phones = fopen(file, "w");
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

bool readInitialDirectory(struct PhoneBook records[], int* countRecords, const char file[])
{
	FILE* phones = fopen(file, "r");
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