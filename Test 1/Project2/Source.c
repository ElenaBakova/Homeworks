#include <stdio.h>
#include <stdlib.h>

int main() 
{
	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		printf("File not found");
		return 0;
	}
	FILE* output = fopen("output.txt", "w");
	if (output == NULL)
	{
		return 0;
	}
	
	int countSymbol[256] = { 0 };
	while (!feof(input))
	{
		int symbolCode = getc(input);
		if (symbolCode >= 0)
		{
			countSymbol[symbolCode]++;
		}
	}
	int count = 0;
	for (int i = 0; i < 256; i++)
	{
		if (countSymbol[i] > 1)
		{
			count++;
			fprintf(output, "'%c' meets %i times\n", i, countSymbol[i]);
		}
		else if (countSymbol[i] == 1)
		{
			count++;
			fprintf(output, "'%c' meets 1 time\n", i);
		}
	}
	if (count == 0)
	{
		fprintf(output, "File is empty");
	}
	
	fclose(input);
	fclose(output);
	return 0;
}
