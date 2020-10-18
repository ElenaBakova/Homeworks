#pragma once

struct PhoneBook {
	char name[20];
	char number[12];
};

// Searching name by number: recieves number, size of the string and array of records. Returns found string
char* findName(const char number[], const int size, struct PhoneBook array[]);

// Searching number by name: recieves name, size of the string and array of records. Returns found string
char* findNumber(const char name[], const int size, struct PhoneBook array[]);