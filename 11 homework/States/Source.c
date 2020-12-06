#include "Graph/Graph.h"
#include "Test.h"
#include <stdio.h>
#include <stdlib.h>

int main()
{
	if (!tests())
	{
		return 1;
	}
	int k = 0;
	int states[1000] = { 0 };
	Graph* graph = readGraph("input.txt", &k, states);
	int vertices = getVertices(graph);
	while (vertices > k)
	{

	}

	deleteGraph(&graph);
	return 0;
}