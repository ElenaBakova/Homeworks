#include "Tree.h"
#include <stdlib.h>
#include <stdbool.h>
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

Dictionary createDictionary(void)
{
	return calloc(1, sizeof(Tree));
}

Node* createNode(void)
{
	return calloc(1, sizeof(Node));
}

char* copy(char* string)
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
		return node;
	}
	if (node->key == root->key) 
	{
		free(root->value);
		root->value = copy(node->value);
		free(node->value);
		free(node);
		return root;
	}
	if (node->key > root->key)
	{
		if (root->right != NULL)
		{
			root->right = insertNode(root->right, node);
			return root;
		}
		root->right = node;
	}
	if (node->key < root->key)
	{
		if (root->left != NULL)
		{
			root->left = insertNode(root->left, node);
			return root;
		}
		root->left = node;
	}
	return root;
}

void addRecord(Dictionary* dictionary, int key, char* value)
{
	if (*dictionary == NULL) 
	{
		return;
	}
	Node* newNode = createNode();
	newNode->key = key;
	newNode->value = copy(value);
	(*dictionary)->root = insertNode((*dictionary)->root, newNode);
}

char* getValue(Node* root, const int key)
{
	if (root == NULL)
	{
		return NULL;
	}
	if (root->key == key)
	{
		return root->value;
	}
	if (key > root->key)
	{
		if (root->right != NULL)
		{
			return getValue(root->right, key);
		}
	}
	else if (key < root->key)
	{
		if (root->left != NULL)
		{
			return getValue(root->left, key);
		}
	}
	return NULL;
}

char* findInDictionary(Dictionary dictionary, const int key)
{
	return getValue(dictionary->root, key);
}

bool isContained(Dictionary dictionary, const int key)
{
	return getValue(dictionary->root, key) != NULL;
}

Node* findMinimum(Node* root)
{
	if (root->left == NULL)
	{
		return root;
	}
	return findMinimum(root->left);
}

Node* deleteNode(Node* root, int key)
{
	if (root == NULL)
	{
		return NULL;
	}
	if (root->key < key && root->right != NULL)
	{
		root->right = deleteNode(root->right, key);
	}
	else if (root->key > key && root->left != NULL)
	{
		root->left = deleteNode(root->left, key);
	}
	else if (root->key == key)
	{
		free(root->value);
		if (root->left != NULL && root->right != NULL)
		{
			Node* minimum = findMinimum(root->right);
			root->key = minimum->key;
			root->value = copy(minimum->value);
			root->right = deleteNode(root->right, root->key);
			return root;
		}
		Node* left = root->left;
		Node* right = root->right;
		free(root);
		if (left == NULL && right == NULL)
		{
			return NULL;
		}
		if (left != NULL && right == NULL)
		{
			return left;
		}
		if (left == NULL && right != NULL)
		{
			return right;
		}
	}
	return root;
}

void deleteRecord(Dictionary dictionary, int key)
{
	if (dictionary == NULL)
	{
		return;
	}
	dictionary->root = deleteNode(dictionary->root, key);
}

Node* freeRecords(Node* root)
{
	if (root == NULL)
	{
		return root;
	}
	root->left = freeRecords(root->left);
	root->right = freeRecords(root->right);
	free(root->value);
	free(root);
	root = NULL;
	return root;
}

void freeDictionary(Dictionary dictionary)
{
	if (dictionary == NULL)
	{
		return;
	}
	dictionary->root = freeRecords(dictionary->root);
	free(dictionary);
}