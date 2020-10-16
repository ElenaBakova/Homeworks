#include "Tests.h"
#include <stdbool.h>
#include <string.h>
#include <stdio.h>

struct PhoneBook {
	char name[20];
	char number[12];
};

char* findName(const char number[], const int size, struct PhoneBook array[]);
char* findNumber(const char name[], const int size, struct PhoneBook array[]);

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
	struct PhoneBook array[5] = { "", "" };
	const int size = 5;
	char name[6] = "a";
	char number[6] = "1";
	strcpy(array[0].name, name);
	strcpy(array[0].number, number);
	bool pushResult = 0;
	for (int i = 1; i < size; i++)
	{
		pushResult += strcmp(array[i - 1].name, name) != 0 || strcmp(array[i - 1].number, number) != 0;
		strcat(name, "a");
		strcat(number, "1");
		strcpy(array[i].name, name);
		strcpy(array[i].number, number);
	}
	return pushResult;
}

bool testFile(void)
{
	FILE* phones = fopen("TestPhoneBook.txt", "w");
	if (phones == NULL)
	{
		return 1;
	}
	char testName[2] = "W";
	char testNumber[5] = "1263";
	for (int i = 0; i < 5; i++)
	{
		fprintf(phones, "%s %s\n", testName, testNumber);
	}
	fclose(phones);
	phones = fopen("TestPhoneBook.txt", "r");
	if (phones == NULL)
	{
		return 1;
	}
	char name[2] = "";
	char number[5] = "";
	bool testResult = 0;
	for (int i = 0; i < 5; i++)
	{
		fscanf(phones, "%s %s", &name, &number);
		testResult += strcmp(name, testName) != 0 || strcmp(number, testNumber) != 0;
	}
	fclose(phones);
	return testResult;
}

bool tests(void)
{
	return !testPush() && testSearch() && !testFile();
}