#include "Graph/Graph.h"
#include "Test.h"
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
		while (current != INT_MAX)
		{
			printf("%i ", current + 1);
			deleteEdge(graph, states[i], current);
			current = getValue(graph, states[i]);
		}
		printf("\n");
	}
}

Graph* makeCountries(int *k, int states[])
{
	Graph* graph = readGraph("input.txt", k, states);
	int vertices = getVertices(graph);
	int index = 0;
	int currentState = states[index];
	while (vertices > (*k))
	{
		int minIndex = getValue(graph, currentState);
		while (isState(states, minIndex, (*k)))
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

int main()
{
	if (!tests())
	{
		return 1;
	}
	int k = 0;
	int states[1000] = { 0 };
	Graph* graph = makeCountries(&k, states);
	printAnswer(graph, states, k);

	deleteGraph(&graph);
	return 0;
}