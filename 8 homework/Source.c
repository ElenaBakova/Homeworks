#include "Dictionary.h"
#include <string.h>
#include <stdio.h>

int main(void)
{
	Dictionary* dictionary = createDictionary();
	addRecord(dictionary, "aba", "caba");
	addRecord(dictionary, "b", "nba");
	addRecord(dictionary, "c", "dda");
	addRecord(dictionary, "aba", "vaba");
	addRecord(dictionary, "d", "sss");
	removeRecord(dictionary, "aba");
	removeRecord(dictionary, "c");

	freeDictionary(dictionary);
	return 0;
}