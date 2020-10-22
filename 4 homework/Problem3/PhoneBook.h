#pragma once
#include <stdbool.h>

struct PhoneBook {
	char name[20];
	char number[12];
};

// Searching name by number: recieves number, size of the string and array of records. Returns found string
char* findName(const char number[], const int size, struct PhoneBook array[]);

// Searching number by name: recieves name, size of the string and array of records. Returns found string
char* findNumber(const char name[], const int size, struct PhoneBook array[]);

// Prints all records from the array
void printRecords(const struct PhoneBook array[], const int size);

// Saves all records to file
void saveDataToFile(const int size, const struct PhoneBook array[]);

// Reads initial directory from file
bool readInitialDirectory(struct PhoneBook records[], int* countRecords);