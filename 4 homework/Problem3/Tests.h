#pragma once
#include <stdbool.h>

// Function tests searching name and number
bool testSearch(void);

// Tests pushing new record
bool testPush(void);

// Tests saving data to file
bool testFile(void);

// Returns 'true' if all tests succeed
bool tests(void);