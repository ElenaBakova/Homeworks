#include "Graph.h"
#include "List.h"
#include <stdio.h>
#include <stdlib.h>

typedef struct Graph
{
	int vertices;
	List** list;
} Graph;

int getVertices(Graph *graph)
{
	return graph->vertices;
}

bool isVertexEmpty(Graph* graph, int index)
{
	if (graph == NULL || index > graph->vertices)
	{
		return true;
	}
	return isEmpty(graph->list[index]);
}

List* getVertex(Graph* graph, int index)
{
	if (graph == NULL || index > graph->vertices)
	{
		return NULL;
	}
	return graph->list[index];
}

int getTheValue(Graph* graph, int i)
{
	if (graph == NULL || i > graph->vertices || isEmpty(graph->list[i]))
	{
		return INT_MAX;
	}
	return getValue(getFirst(graph->list[i]));
}

int getTheLength(Graph* graph, int i)
{
	if (graph == NULL || i > graph->vertices || isEmpty(graph->list[i]))
	{
		return -INT_MAX;
	}
	return getLength(getFirst(graph->list[i]));
}

void deleteEdge(Graph* graph, int source, int destination)
{
	if (source)
	removeValue(graph->list[source], destination);
	removeValue(graph->list[destination], source);
}

Graph* readGraph(const char* filename, int* countStates, int* states)
{
	FILE* input = fopen(filename, "r");
	if (input == NULL) 
	{
		return NULL;
	}
	Graph* newGraph = calloc(1, sizeof(Graph));
	if (newGraph == NULL)
	{
		fclose(input);
		return NULL;
	}
	int nodes = 0;
	int edges = 0;
	fscanf(input, "%d %d", &nodes, &edges);
	newGraph->list = calloc(nodes, sizeof(List*));
	newGraph->vertices = nodes;
	for (int i = 0; i < nodes; i++)
	{
		newGraph->list[i] = makeList();
	}
	for (int i = 0; i < edges; i++)
	{
		int first = 0; 
		int second = 0;
		int length = 0;
		fscanf(input, "%d %d %d", &first, &second, &length);
		first--;
		second--;
		addItem(newGraph->list[first], second, length);
		addItem(newGraph->list[second], first, length);
	}
	fscanf(input, "%d", countStates);
	for (int i = 0; i < (*countStates); i++)
	{
		int temp = 0;
		fscanf(input, "%d", &temp);
		states[i] = temp - 1;
	}
	fclose(input);
	return newGraph;
}

void deleteGraph(Graph** graph)
{
	for (int i = 0; i < (*graph)->vertices; i++)
	{
		freeList(&((*graph)->list[i]));
	}
	free((*graph)->list);
	free(*graph);
	*graph = NULL;
}