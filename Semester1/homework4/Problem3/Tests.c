#include "Tests.h"
#include "PhoneBook.h"
#include <stdbool.h>
#include <string.h>
#include <stdio.h>

bool testSearch(void)
{
	PhoneBook array[5] = { "", "" };
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

bool testSaveData(const PhoneBook records[])
{
	if (saveDataToFile(2, records, "EmptyBook.txt"))
	{
		return 0;
	}
	bool result = true;
	FILE* test = fopen("EmptyBook.txt", "r");
	if (test == NULL)
	{
		return 0;
	}
	char name[10] = "";
	char number[10] = "";
	fscanf(test, "%s %s", &name, &number);
	result &= (strcmp(name, "abac") == 0 && strcmp(number, "1234") == 0);
	fscanf(test, "%s %s", &name, &number);
	result &= (strcmp(name, "abacaba") == 0 && strcmp(number, "1263") == 0);
	fclose(test);
	return result;
}

bool testReadDirectory(PhoneBook records[])
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
	PhoneBook records[5] = { "", "" };
	strcpy(records[0].name, "abac");
	strcpy(records[0].number, "1234");
	strcpy(records[1].name, "abacaba");
	strcpy(records[1].number, "1263");
	return testSearch() && testSaveData(records) && testReadDirectory(records);
}