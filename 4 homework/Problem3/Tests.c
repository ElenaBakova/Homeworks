#include "Tests.h"
#include "PhoneBook.h"
#include <stdbool.h>
#include <string.h>
#include <stdio.h>

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
	bool testResult = strcmp(findNumber("a", size, array), "1") == 0 && strcmp(findName("1", size, array), "a") == 0;
	testResult *= strcmp(findNumber("aaaa", size, array), "1111") == 0;
	testResult *= strcmp(findName("11", size, array), "aa") == 0 && strcmp(findName("111", size, array), "aaa") == 0;
	testResult *= strcmp(findName("11111", size, array), "aaaaa") == 0;
	return testResult;
}

bool testPush(void)
{
	FILE* phones = fopen("TestPhoneBook.txt", "r");
	if (phones == NULL)
	{
		return 0;
	}
	struct PhoneBook array[5] = { "", "" };
	const int size = 5;
	char name[6] = "W";
	char number[6] = "1263";
	bool pushResult = 1;
	for (int i = 0; i < size; i++)
	{
		fscanf(phones, "%s %s", &array[i].name, &array[i].number);
		pushResult &= (strcmp(array[i].name, name) == 0 && strcmp(array[i].number, number) == 0);
	}
	fclose(phones);
	return pushResult;
}

bool testSaveData(void)
{
	FILE* phones = fopen("TestPhoneBook.txt", "w");
	if (phones == NULL)
	{
		return 0;
	}
	int testCount = 5;
	char testName[2] = "W";
	char testNumber[5] = "1263";
	for (int i = 0; i < testCount; i++)
	{
		fprintf(phones, "%s %s\n", testName, testNumber);
	}
	fclose(phones);
	phones = fopen("TestPhoneBook.txt", "r");
	if (phones == NULL)
	{
		return 0;
	}
	char name[2] = "";
	char number[5] = "";
	bool testResult = true;
	int i = 0;
	while(!feof(phones))
	{
		fscanf(phones, "%s %s", &name, &number);
		testResult &= strcmp(name, testName) == 0 && strcmp(number, testNumber) == 0;
		i++;
	}
	fclose(phones);
	return testResult && (i == testCount + 1);
}

bool testReadDirectory()
{
	FILE* phones = fopen("TestPhoneBook.txt", "r");
	if (phones == NULL)
	{
		return 0;
	}
	struct PhoneBook records[5];
	int countRecords = 0;
	while (!feof(phones))
	{
		fscanf(phones, "%s %s", &records[countRecords].name, &records[countRecords].number);
		countRecords++;
	}
	fclose(phones);
	char name[2] = "W";
	char number[5] = "1263";
	bool result = true;
	for (int i = 0; i < countRecords - 1; i++)
	{
		result &= (strcmp(records[i].name, name) == 0 && strcmp(records[i].number, number) == 0);
	}
	return result;
}

bool tests(void)
{
	return testPush() && testSearch() && testSaveData() && testReadDirectory();
}