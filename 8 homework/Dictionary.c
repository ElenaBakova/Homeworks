#include "Dictionary.h"
#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include <stdlib.h>

typedef struct Node {
	char* key;
	char* value;
	int height;
	struct Node* left;
	struct Node* right;
} Node;

typedef struct Dictionary {
	Node* root;
} Dictionary;

Dictionary* createDictionary(void)
{
	return calloc(1, sizeof(Dictionary));
}

int getHeight(Node* node)
{
	if (node == NULL) {
		return 0;
	}
	return node->height;
}

int getBalanceFactor(Node* node)
{
	if (node == NULL || node->right == NULL && node->left == NULL)
	{
		return 0;
	}
	if (node->right == NULL && node->left != NULL)
	{
		return -node->left->height;
	}
	if (node->right != NULL && node->left == NULL)
	{
		return node->right->height;
	}
	return node->right->height - node->left->height;
}

void recountHeight(Node* node)
{
	if (node == NULL)
	{
		return;
	}
	if (node->right == NULL && node->left == NULL)
	{
		node->height = 0;
	}
	else if (node->right == NULL && node->left != NULL)
	{
		node->height = node->left->height + 1;
	}
	else if (node->right != NULL && node->left == NULL)
	{
		node->height = node->right->height + 1;
	}
	else
	{
		int maxSonHeight = (node->right->height > node->left->height ? node->right->height : node->left->height);
		node->height = maxSonHeight + 1;
	}
}

Node* rotateRight(Node* node)
{
	if (node == NULL || node->right == NULL && node->left == NULL)
	{
		return NULL;
	}
	Node* newNode = node->left;
	node->left = newNode->right;
	newNode->right = node;
	recountHeight(node);
	recountHeight(newNode);
	return newNode;
}

Node* rotateLeft(Node* node)
{
	if (node == NULL || node->right == NULL && node->left == NULL)
	{
		return NULL;
	}
	Node* newNode = node->right;
	node->right = newNode->left;
	newNode->left = node;
	recountHeight(node);
	recountHeight(newNode);
	return newNode;
}

Node* balanceTree(Node* node)
{
	recountHeight(node);
	if (getBalanceFactor(node) == 2)
	{
		if (getBalanceFactor(node->right) < 0) 
		{
			node->right = rotateRight(node->right);
		}
		return rotateLeft(node);
	}
	else if (getBalanceFactor(node) == -2)
	{
		if (getBalanceFactor(node->left) > 0) 
		{
			node->left = rotateLeft(node->left);
		}
		return rotateRight(node);
	}
	return node;
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

Node* addValue(Node* root, char* key, char* value)
{
	if (root == NULL) {
		root = calloc(1, sizeof(Node));
		root->value = assign(value);
		root->key = assign(key);
		return balanceTree(root);
	}
	if (root->key == NULL)
	{
		root->value = assign(value);
		root->key = assign(key);
		return root;
	}
	int cmpRes = strcmp(root->key, key);
	if (cmpRes == 0) {
		root->value = assign(value);
	}
	else if (cmpRes > 0) {
		root->left = addValue(root->left, key, value);
	}
	else {
		root->right = addValue(root->right, key, value);
	}
	return balanceTree(root);
}

void addRecord(Dictionary* dictionary, char* key, char* value)
{
	if (dictionary == NULL)
	{
		dictionary = createDictionary();
	}
	dictionary->root = addValue(dictionary->root, key, value);
}

Node* findNode(Node* root, const char* key)
{
	if (root == NULL) {
		return NULL;
	}
	int cmpRes = strcmp(root->key, key);
	if (cmpRes == 0) {
		return root;
	}
	else if (cmpRes > 0) {
		return findNode(root->left, key);
	}
	else {
		return findNode(root->right, key);
	}
	return NULL;
}

bool isContained(Dictionary* dictionary, const char* key)
{
	return findNode(dictionary->root, key) == NULL ? false : true;
}

char* findValueByKey(Dictionary* dictionary, const char* key)
{
	Node* node = findNode(dictionary->root, key);
	if (node == NULL) {
		return NULL;
	}
	return node->value;
}

Node* findMinimum(Node* node)
{
	if (node == NULL)
	{
		return NULL;
	}
	return node->left == NULL ? node : findMinimum(node->left);
}

Node* removeMinimum(Node* node)
{
	if (node == NULL)
	{
		return NULL;
	}
	if (node->left == NULL)
	{
		return node->right;
	}
	node->left = removeMinimum(node->left);
	return balanceTree(node);
}

Node* deleteRecord(Node* root, const char* key)
{
	if (root == NULL)
	{
		return NULL;
	}
	int cmpRes = strcmp(root->key, key);
	if (cmpRes == 1)
	{
		root->left = deleteRecord(root->left, key);
	}
	else if (cmpRes == -1)
	{
		root->right = deleteRecord(root->right, key);
	}
	else
	{
		Node* left = root->left;
		Node* right = root->right;
		free(root);
		if (right == NULL)
		{
			return left;
		}
		Node* minimum = findMinimum(right);
		minimum->right = removeMinimum(right);
		minimum->left = left;
		return balanceTree(minimum);
	}
	return balanceTree(root);
}

void removeRecord(Dictionary* dictionary, const char* key)
{ 
	if (dictionary == NULL)
	{
		return;
	}
	dictionary->root = deleteRecord(dictionary->root, key);
}

void freeRecord(Node* root)
{
	free(root->key);
	free(root->value);
	free(root);
	root = NULL;
}

void freeNode(Node* root)
{
	if (root == NULL)
	{
		return;
	}
	if (root->left == NULL && root->right == NULL)
	{
		freeRecord(root);
		return;
	}
	freeNode(root->left);
	freeNode(root->right);
	freeRecord(root);
}

void freeDictionary(Dictionary* dictionary)
{
	freeNode(dictionary->root);
	free(dictionary);
	dictionary = NULL;
}