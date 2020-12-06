#include "Graph.h"
#include "List.h"
#include <stdio.h>
#include <stdlib.h>

typedef struct Graph
{
	List** list;
	int vertices;
} Graph;

Graph* makeGraph(const char* filename, int* k, int* states)
{
	FILE* input = fopen(filename, "r");
	if (input == NULL) {
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
		addItem(newGraph->list[first], second, length);
		addItem(newGraph->list[second], first, length);
	}
	fscanf(input, "%d", &(*k));
	for (int i = 0; i < (*k); i++)
	{
		fscanf(input, "%d", &states[i]);
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
//
//void deleteGraph(Graph** graph)
//{
//	for (int i = 0; i < (*graph)->vertices; i++)
//	{
//		free((*graph)->matrix[i]);
//	}
//	free((*graph)->matrix);
//	free(*graph);
//	*graph = NULL;
//}