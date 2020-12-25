#pragma once
#include <stdbool.h>

typedef struct Tree Tree;

typedef struct Tree* Dictionary;

// Creates new empty dictionary
Tree* createDictionary(void);

// Add new record to the dictionary
void add(Dictionary* dictionary, int key, char* value);

// Searches for key in the dictionary. Returns NULL if key wasn't found
char* findInDictionary(Dictionary dictionary, const int key);

// Returns 'true' if key is in dictionary
bool isContained(Dictionary dictionary, const int key);

// Deletes record by key
void deleteRecord(Dictionary dictionary, int key);