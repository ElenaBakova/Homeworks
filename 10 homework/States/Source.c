#include "Graph/Graph.h"
#include "Graph/TestList.h"
#include <stdio.h>
#include <stdlib.h>

bool isState(const int states[], const int index, const int k)
{
	for (int i = 0; i < k; i++)
	{
		if (states[i] == index)
		{
			return true;
		}
	}
	return false;
}

void printAnswer(Graph* graph, int states[], int k)
{
	for (int i = 0; i < k; i++)
	{
		printf("State: %i\nCities: ", states[i] + 1);
		int current = getValue(graph, states[i]);
		int currentLength = getTheLength(graph, states[i]);
		while (currentLength != -INT_MAX)
		{
			if (currentLength == INT_MAX)
			{
				printf("%i ", current + 1);
			}
			deleteEdge(graph, states[i], current);
			current = getValue(graph, states[i]);
			currentLength = getTheLength(graph, states[i]);
		}
		printf("\n");
	}
}

Graph* makeCountries(char* filename, int *k, int states[])
{
	Graph* graph = readGraph(filename, k, states);
	if ((*k) == 0)
	{
		return graph;
	}
	int vertices = getVertices(graph);
	int index = 0;
	int currentState = states[index];
	while (vertices > (*k))
	{
		int minIndex = getValue(graph, currentState);
		while (isState(states, minIndex, (*k)) || isUsed(graph, minIndex))
		{
			deleteEdge(graph, currentState, minIndex);
			minIndex = getValue(graph, currentState);
		}
		if (minIndex != INT_MAX)
		{
			mergeNodes(graph, currentState, minIndex);
			vertices--;
		}
		index = (index + 1) % (*k);
		currentState = states[index];
	}
	return graph;
}

bool test()
{
	FILE* answers = fopen("answerTest.txt", "r");
	if (answers == NULL)
	{
		return false;
	}
	int k = 0;
	int states[1000] = { 0 };
	Graph* graph = makeCountries("test.txt", &k, states);
	bool result = true;
	for (int i = 0; i < k; i++)
	{
		int current = getValue(graph, states[i]);
		int currentLength = getTheLength(graph, states[i]);
		int answer = 0;
		while (currentLength != -INT_MAX)
		{
			if (currentLength == INT_MAX)
			{
				fscanf(answers, "%i", &answer);
				result &= (answer == current + 1);
			}
			deleteEdge(graph, states[i], current);
			current = getValue(graph, states[i]);
			currentLength = getTheLength(graph, states[i]);
		}
	}
	fclose(answers);
	deleteGraph(&graph);
	return result;
}

int main()
{
	if (!listTests())
	{
		printf("List tests failed");
		return 1;
	}
	printf("List tests succeed\n");
	if (!test())
	{
		printf("Tests failed");
		return 1;
	}
	printf("Tests succeed\n");

	int k = 0;
	int states[1000] = { 0 };
	Graph* graph = makeCountries("input.txt", &k, states);
	printAnswer(graph, states, k);

	deleteGraph(&graph);
	return 0;
}