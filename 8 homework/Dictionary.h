#pragma once
#include <stdbool.h>

typedef struct Dictionary Dictionary;

// Create new empty dictionary
Dictionary* createDictionary(void);

// Recieve key and value. Add them to the dictionary. Can't change key or value after that
void addRecord(Dictionary* dictionary, char* key, char* value);

// Returns value that belongs to the key or NULL if key wasn't found
char* findValueByKey(Dictionary* dictionary, const char* key);

// Returns 'true' id key is in dictionary, otherwise 'false'
bool isContained(Dictionary* dictionary, const char* key);

// Delete record by key
void removeRecord(Dictionary* dictionary, const char* key);

// Removes whole dictionary 
void freeDictionary(Dictionary* dictionary);