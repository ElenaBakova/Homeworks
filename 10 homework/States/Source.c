#include "Graph/Graph.h"
#include "Test.h"
#include <stdio.h>
#include <stdlib.h>

void makeCountries()
{
	int k = 0;
	int states[1000] = { 0 };
	Graph* graph = readGraph("input.txt", &k, states);
	int vertices = getVertices(graph);
	int currentState = 0;
	while (vertices > k)
	{
		
	}

	deleteGraph(&graph);
}

int main()
{
	if (!tests())
	{
		return 1;
	}
	
	return 0;
}