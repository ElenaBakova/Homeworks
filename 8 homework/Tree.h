#pragma once

typedef struct Node Node;

// Return height of the tree
int getHeight(Node* node);

// Insert new node to the tree
Node* addNode(Node* root, char* key, char* value);

// Returns value that is belongs to the key or NULL if key wasn't found
char* findValueByNode(Node* root, const char* key);