#pragma once

typedef struct Graph Graph;

int getVertices(Graph* graph);

Graph* readGraph(const char* filename, int* k, int* states);

//void printGraph(const Graph* graph);

void deleteGraph(Graph** graph);