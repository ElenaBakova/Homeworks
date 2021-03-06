#pragma once
#include "List.h"
#include <stdbool.h>

typedef struct Graph Graph;

// Returns head value of i-th list
int getTheValue(Graph* graph, int i);

// Returns vertex list by index
List* getVertex(Graph* graph, int index);

// Returns head length of i-th list
int getTheLength(Graph* graph, int i);

// Returns 'true' if vertex has no neighbours
bool isVertexIsolated(Graph* graph, int index);

// Returns number of graph vertices
int getVerticesCount(Graph* graph);

// Reads graph and states from file
Graph* readGraph(const char* filename, int* k, int* states);

// Deletes edge between index and value 
void deleteEdge(Graph* graph, int source, int destination);

// Deletes graph
void deleteGraph(Graph** graph);