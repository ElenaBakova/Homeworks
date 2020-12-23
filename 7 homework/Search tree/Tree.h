#pragma once

typedef struct Tree Tree;

// Add new node to the tree
void add(Tree** tree, int key, char* value);

// Creates new empty dictionary
Tree* createTree(void);

// Returns empty string if key wasn't found
//char* getValue(Node* root, const int key);