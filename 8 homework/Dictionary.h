#pragma once

typedef struct Dictionary Dictionary;

// Create new empty dictionary
Dictionary* initDictionary();

// Recieve key and value. Add them to the dictionary. Can't change key or value after that
Dictionary* addValue(Dictionary* root, char* key, char* value);

// Returns value that's belongs to the key or NULL if key wasn't found
char* findValueByKey(Dictionary* root, const char* key);

// Delete record by key
Dictionary* deleteRecord(Dictionary* root, const char* key);