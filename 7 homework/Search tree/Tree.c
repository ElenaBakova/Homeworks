#include "Tree.h"
#include <stdlib.h>
#include <string.h>

typedef struct Node {
	int key;
	char* value;
	struct Node* left;
	struct Node* right;
} Node;

typedef struct Tree {
	struct Node* root;
} Tree;

Tree* createTree(void)
{
	return calloc(1, sizeof(Tree));
}

Node* createNode(void)
{
	return calloc(1, sizeof(Node));
}

char* assign(char* string)
{
	char* newString = malloc(strlen(string) + 1);
	if (newString == NULL)
	{
		return NULL;
	}
	strcpy(newString, string);
	return newString;
}

Node* insertNode(Node* root, Node* node)
{
	if (root == NULL)
	{
		root = node;
		return root;
	}
	if (node->key == root->key) {
		free(root->value);
		root->value = assign(node->value);
		return root;
	}
	if (node->key > root->key)
	{
		if (root->right != NULL) {
			root->right = insertNode(root->right, node);
			return root;
		}
		root->right = node;
	}
	if (node->key < root->key)
	{
		if (root->left != NULL) {
			root->left = insertNode(root->left, node);
			return root;
		}
		root->left = node;
	}
	return root;
}

void add(Tree** tree, int key, char* value)
{
	if (*tree == NULL) 
	{
		return;
	}
	Node* newNode = createNode();
	newNode->key = key;
	newNode->value = assign(value);
	(*tree)->root = insertNode((*tree)->root, newNode);
}

//char* getValue(Node* root, const int key)
//{
//	if (root == NULL) {
//		return "Nothing was found\n";
//	}
//	if (root->key == key) {
//		return root->string;
//	}
//	if (key > root->key)
//	{
//		if (root->right != NULL)
//		{
//			return getValue(root->right, key);
//		}
//		return "Nothing was found\n";
//	}
//	if (key < root->key)
//	{
//		if (root->left != NULL)
//		{
//			return getValue(root->left, key);
//		}
//		return "Nothing was found\n";
//	}
//	return "Nothing was found\n";
//}