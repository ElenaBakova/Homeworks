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
	//dictionary = deleteRecord(dictionary, "aba");

	return 0;
}