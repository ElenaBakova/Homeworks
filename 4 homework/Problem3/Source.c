#include <stdio.h>
#include <stdbool.h>
#include <string.h>

const int nameSize = 20;
const int numberSize = 12;

struct PhoneBook {
	char name[20];
	char number[12];
};

void printRecords(const struct PhoneBook array[], const int size)
{
	for (int i = 0; i < size; i++)
	{
		printf("%s -- %s\n", array[i].name, array[i].number);
	}
}

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

bool testSearch(void)
{
	struct PhoneBook array[5] = { "", "" };
	const int size = 5;
	char name[6] = "";
	char number[6] = "";
	for (int i = 0; i < size; i++)
	{
		strcat(name, "a");
		strcat(number, "1");
		strcpy(array[i].name, name);
		strcpy(array[i].number, number);
	}
	//makeArray(array, size);
	return strcmp(findNumber("a", size, array), "1") == 0 && strcmp(findNumber("aaaa", size, array), "1111") == 0 && strcmp(findName("11", size, array), "aa") == 0 && strcmp(findName("111", size, array), "aaa") == 0 && strcmp(findName("11111", size, array), "aaaaa") == 0;
}

int main()
{
	if (!testSearch())
	{
		printf("Tests failed\n");
		return 0;
	}
	printf("Tests succeed\n");

	FILE* phones = fopen("Phone_Book.txt", "r");
	if (phones == NULL)
	{
		printf("File not found!");
		return -1;
	}
	struct PhoneBook records[100];
	int countRecords = 0;
	while (!feof(phones))
	{
		fscanf(phones, "%s %s", &records[countRecords].name, &records[countRecords].number);
		countRecords++;
	}
	fclose(phones);

	printf("What would you like to do?\n0 - exit\n1 - add record (name and phone)\n");
	printf("2 - print all rocords\n3 - find number by name\n4 - find name by number\n5 - save actual data to the file\n");
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
			saveDataToFile(countRecords, records);
			return 0;
		}
	}

	return 0;
}