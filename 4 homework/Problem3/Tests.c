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

bool testReadDirectory(struct PhoneBook records[])
{
	int countRecords = 0;
	if (readInitialDirectory(records, &countRecords, "TestPhoneBook.txt") || countRecords != 2)
	{
		return 0;
	}
	bool result = true;
	result &= (strcmp(records[0].name, "abac") == 0 && strcmp(records[0].number, "1234") == 0);
	result &= (strcmp(records[1].name, "abacaba") == 0 && strcmp(records[1].number, "1263") == 0);
	return result;
}

bool tests(void)
{
	struct PhoneBook records[5] = {0};
	records[0].name = "abac";
	records[0].number = "1234";
	return testSearch() && testSaveData(records) && testReadDirectory(records);
}