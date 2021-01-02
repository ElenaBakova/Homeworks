#pragma once
#include <stdbool.h>

typedef struct Tree Tree;

// Creates new empty tree
Tree* makeTree(void);

// Builds tree by string
void buildTree(Tree* tree, char* string);

// Returns result of expression
int getExpressionResult(Tree* tree);

// Deletes whole tree
void freeTree(Tree* tree);