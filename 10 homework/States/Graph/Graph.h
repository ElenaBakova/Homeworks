#pragma once
#include <stdbool.h>

typedef struct Graph Graph;

// Returns head value of i-th list
int getValue(Graph* graph, int i);

// Returns head length of i-th list
int getTheLength(Graph* graph, int i);

// Returns 'true' if vertex is taken
bool isUsed(Graph* graph, int index);

// Returns graph vertices
int getVertices(Graph* graph);

// Reads graph and states from file
Graph* readGraph(const char* filename, int* k, int* states);

//void printGraph(const Graph* graph);

void mergeNodes(Graph* graph, int destination, int source);

// deletes edge between index and value 
void deleteEdge(Graph* graph, int index, int value);

// Deletes graph
void deleteGraph(Graph** graph);