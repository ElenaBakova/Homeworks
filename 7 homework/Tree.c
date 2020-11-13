#include "Tree.h"
#include <stdlib.h>
#include <string.h>

typedef struct Node {
	int key;
	char string[50];
	struct Node* left;
	struct Node* right;
} Node;

char* getS(Node* root)
{
	return root->string;
}

void initNode(Node **root, const int key, const char string[])
{
	Node* newNode = calloc(1, sizeof(Node));
	if (newNode == NULL) {
		return;
	}
	newNode->key = key;
	strcpy(newNode->string, string);
	(*root) = newNode;
	free(newNode);
}

Node* add(Node* root, const int key, const char string[])
{
	if (root == NULL) 
	{
		initNode(&root, key, string);
		return root;
	}
	if (key == root->key) {
		strcpy(root->string, string);
		return root;
	}
	Node* newNode = NULL;
	initNode(&newNode, key, string);
	if (key > root->key)
	{
		if (root->right != NULL) {
			return add(root, key, string);
		}
		root->right = newNode;
	}
	if (key < root->key)
	{
		if (root->left != NULL) {
			return add(root, key, string);
		}
		root->left = newNode;
	}
	return root;
}