#include <stdio.h>

int main()
{
	FILE* input = fopen("input.txt", "r");
	if (input == NULL)
	{
		return 1;
	}
	FILE* graph = fopen("graph.dot", "w");
	if (input == NULL)
	{
		fclose(graph);
		return 1;
	}
	fprintf(graph, "digraph G {\n");
	int verteces = 0;
	fscanf(input, "%i", &verteces);
	for (int i = 0; i < verteces; i++)
	{
		for (int j = 0; j < verteces; j++)
		{
			int weight = 0;
			fscanf(input, "%i", &weight);
			if (weight != 0)
			{
				fprintf(graph, "%i -> %i [label = \"%i\"];", i, j, weight);
				if (j != verteces - 1 || i != verteces - 1)
				{
					fprintf(graph, "\n");
				}
			}
		}
	}
	fprintf(graph, "}");

	fclose(input);
	fclose(graph);
	return 0;
}