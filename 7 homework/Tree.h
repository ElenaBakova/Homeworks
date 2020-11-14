#pragma once

typedef struct Node Node;

char* getS(Node* root);

// Add new node to the tree
Node* add(Node* root, const int key, const char* string);

// Returns empty string if key wasn't found
char* getValue(Node* root, const int key);