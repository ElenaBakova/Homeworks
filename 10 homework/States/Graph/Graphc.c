#include "Graph.h"
#include "List.h"
#include <stdio.h>
#include <stdlib.h>

typedef struct Graph
{
	List** list;
	int vertices;
} Graph;

int getVertices(Graph *graph)
{
	return graph->vertices;
}

bool isUsed(Graph* graph, int index)
{
	return isEmpty(graph->list[index]);
}

int getValue(Graph* graph, int i)
{
	if (graph == NULL || i > graph->vertices || isEmpty(graph->list[i]))
	{
		return INT_MAX;
	}
	return getTheValue(graph->list[i]);
}

int getTheLength(Graph* graph, int i)
{
	if (graph == NULL || i > graph->vertices || isEmpty(graph->list[i]))
	{
		return -INT_MAX;
	}
	return getLength(graph->list[i]);
}

void deleteEdge(Graph* graph, int index, int value)
{
	removeValue(graph->list[index], value);
	removeValue(graph->list[value], index);
}

void mergeNodes(Graph* graph, int destination, int source)
{
	if (graph == NULL)
	{
		return;
	}
	mergeLists(graph->list[destination], graph->list[source], destination, source);
}

Graph* readGraph(const char* filename, int* k, int* states)
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
	newGraph->list = malloc(nodes * sizeof(List*));
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
	fscanf(input, "%d", &(*k));
	for (int i = 0; i < (*k); i++)
	{
		int temp = 0;
		fscanf(input, "%d", &temp);
		states[i] = temp - 1;
	}
	fclose(input);
	return newGraph;
}

//void printGraph(const Graph* graph)
//{
//	const int size = graph->vertices;
//	for (int i = 0; i < size; i++)
//	{
//		for (int j = 0; j < size; j++)
//		{
//			/*if (graph->matrix[i][j] == 1) {
//				printf("%i -- %i\n", i, j);
//			}*/
//			printf("%i ", graph->matrix[i][j]);
//		}
//		printf("\n");
//	}
//}

void deleteGraph(Graph** graph)
{
	for (int i = 0; i < (*graph)->vertices; i++)
	{
		freeList(&(*graph)->list[i]);
	}
	free((*graph)->list);
	free(*graph);
	*graph = NULL;
}