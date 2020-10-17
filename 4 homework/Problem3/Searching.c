#include "Struct.h"

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