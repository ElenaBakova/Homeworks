int findMostCommon(const int array[], const int size)
{
	int mostCommon = 0;
	int maxQuantity = 0;
	int i = 0;
	while (i < size)
	{
		int countLength = 1;
		while (array[i] == array[i + 1] && i + 1 < size)
		{
			countLength++;
			i++;
		}
		if (maxQuantity < countLength)
		{
			maxQuantity = countLength;
			mostCommon = array[i];
		}
		i++;
	}

	return mostCommon;
}