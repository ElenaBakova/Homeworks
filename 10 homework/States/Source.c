#include "Graph/Graph.h"
#include "Graph/List.h"
#include "Graph/TestList.h"
#include <stdio.h>
#include <stdlib.h>

bool isState(const int states[], const int index, const int countStates)
{
	for (int i = 0; i < countStates; i++)
	{
		if (states[i] == index)
		{
			return true;
		}
	}
	return false;
}

void mergeLists(List* destination, List* source, int destinationIndex, int sourceIndex)
{
	removeValue(destination, sourceIndex);
	addItem(destination, sourceIndex, INT_MAX);
	removeValue(source, destinationIndex);
	Position current = getFirst(source);
	while (!isEmpty(source))
	{
		int value = getValue(current);
		int length = getLength(current);
		int destinationLength = findValue(destination, value);
		if (destinationLength == -INT_MAX)
		{
			addItem(destination, value, length);
		}
		else if (destinationLength > length && destinationLength != INT_MAX)
		{
			removeValue(destination, value);
			addItem(destination, value, length);
		}
		removeValue(source, value);
		current = getFirst(source);
	}
}

void mergeNodes(Graph* graph, int destination, int source)
{
	if (graph == NULL)
	{
		return;
	}
	mergeLists(getVertex(graph, destination), getVertex(graph, source), destination, source);
}

void printAnswer(Graph* graph, int states[], int countStates)
{
	for (int i = 0; i < countStates; i++)
	{
		printf("State: %i\nCities: ", states[i] + 1);
		int current = getTheValue(graph, states[i]);
		int currentLength = getTheLength(graph, states[i]);
		while (currentLength != -INT_MAX)
		{
			if (currentLength == INT_MAX)
			{
				printf("%i ", current + 1);
			}
			deleteEdge(graph, states[i], current);
			current = getTheValue(graph, states[i]);
			currentLength = getTheLength(graph, states[i]);
		}
		printf("\n");
	}
}

Graph* makeCountries(char* filename, int *countStates, int states[])
{
	Graph* graph = readGraph(filename, countStates, states);
	if ((*countStates) == 0)
	{
		return graph;
	}
	int vertices = getVerticesCount(graph);
	int index = 0;
	int currentState = states[index];
	while (vertices > (*countStates))
	{
		int minIndex = getTheValue(graph, currentState);
		while (minIndex != INT_MAX && (isState(states, minIndex, (*countStates)) || isVertexIsolated(graph, minIndex)))
		{
			deleteEdge(graph, currentState, minIndex);
			minIndex = getTheValue(graph, currentState);
		}
		if (minIndex != INT_MAX)
		{
			mergeNodes(graph, currentState, minIndex);
			vertices--;
		}
		index = (index + 1) % (*countStates);
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
	int countStates = 0;
	int states[1000] = { 0 };
	Graph* graph = makeCountries("test.txt", &countStates, states);
	bool result = true;
	for (int i = 0; i < countStates; i++)
	{
		int current = getTheValue(graph, states[i]);
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
			current = getTheValue(graph, states[i]);
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