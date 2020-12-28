#pragma once
#include <stdbool.h>

typedef struct PhoneBook {
	char name[20];
	char number[12];
}PhoneBook;

// Searching name by number: recieves number, size of the string and array of records. Returns found string
char* findName(const char number[], const int size, PhoneBook array[]);

// Searching number by name: recieves name, size of the string and array of records. Returns found string
char* findNumber(const char name[], const int size, PhoneBook array[]);

// Prints all records from the array
void printRecords(const PhoneBook array[], const int size);

// Saves all records to file
bool saveDataToFile(const int size, const PhoneBook array[], const char file[]);

// Reads initial directory from file
bool readInitialDirectory(PhoneBook records[], int* countRecords, const char file[]);