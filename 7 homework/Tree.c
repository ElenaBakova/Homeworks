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

Node* initNode(const int key, const char string[])
{
	Node* newNode = calloc(1, sizeof(Node));
	if (newNode == NULL) {
		return NULL;
	}
	newNode->key = key;
	strcpy(newNode->string, string);
	return newNode;
}

Node* add(Node* root, const int key, const char string[])
{
	if (root == NULL) 
	{
		return initNode(key, string);
	}
	if (key == root->key) {
		strcpy(root->string, string);
		return root;
	}
	Node* newNode = initNode(key, string);
	if (key > root->key)
	{
		if (root->right != NULL) {
			root->right = add(root->right, key, string);
			return root;
		}
		root->right = newNode;
	}
	if (key < root->key)
	{
		if (root->left != NULL) {
			root->left = add(root->left, key, string);
			return root;
		}
		root->left = newNode;
	}
	return root;
}

char* getValue(Node* root, const int key)
{
	if (root == NULL) {
		return "Nothing was found\n";
	}
	if (root->key == key) {
		return root->string;
	}
	if (key > root->key)
	{
		if (root->right != NULL)
		{
			return getValue(root->right, key);
		}
		return "Nothing was found\n";
	}
	if (key < root->key)
	{
		if (root->left != NULL)
		{
			return getValue(root->left, key);
		}
		return "Nothing was found\n";
	}
	return "Nothing was found\n";
}