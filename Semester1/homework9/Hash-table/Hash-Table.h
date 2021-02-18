#pragma once

typedef struct HashTable HashTable;

// Returns load factor of the hash table
double getLoadFactor(HashTable* table);

// Returns maximum list length;
int getMaxListLength(HashTable* table);

// Returns average list length 
int getAverageListLength(HashTable* table);

// Creates new empty hash table
HashTable* makeHashTable();

// Adds string to the hash table or increases frequency
void addToTheTable(HashTable* table, char* string);

// Prints words and frequency
void printHashTable(HashTable* table);

// Deletes whole hash table
void deleteHashTable(HashTable** table);