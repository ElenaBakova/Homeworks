#include "Dictionary.h"
#include <string.h>
#include <stdio.h>

int main(void)
{
	Dictionary* dictionary = initDictionary();
	dictionary = addValue(dictionary, "aba", "caba");
	dictionary = addValue(dictionary, "b", "nba");
	dictionary = addValue(dictionary, "c", "dda");
	dictionary = addValue(dictionary, "aba", "vaba");
	dictionary = deleteRecord(dictionary, "aba");

	return 0;
}