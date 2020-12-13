#include "Dictionary.h"
#include <stdio.h>
#include <string.h>
#include <stdbool.h>
#include <stdlib.h>

typedef struct Dictionary {
	char* key;
	char* value;
	int height;
	struct Dictionary* left;
	struct Dictionary* right;
} Dictionary;

int getHeight(Dictionary* node)
{
	if (node == NULL) {
		return 0;
	}
	return node->height;
}

int getBalanceFactor(Dictionary* node)
{
	if (node == NULL || node->right == NULL || node->left == NULL)
	{
		return 0;
	}
	return node->right->height - node->left->height;
}

void recountHeight(Dictionary* node)
{
	if (node == NULL || node->right == NULL || node->left == NULL)
	{
		return;
	}
	int maxSonHeight = (node->right->height > node->left->height ? node->right->height : node->left->height);
	node->height = maxSonHeight + 1;
}

Dictionary* rotateRight(Dictionary* node)
{
	if (node == NULL || node->right == NULL || node->left == NULL)
	{
		return NULL;
	}
	Dictionary* newNode = node->left;
	node->left = newNode->right;
	newNode->right = node;
	recountHeight(node);
	recountHeight(newNode);
	return newNode;
}

Dictionary* rotateLeft(Dictionary* node)
{
	if (node == NULL || node->right == NULL || node->left == NULL)
	{
		return NULL;
	}
	Dictionary* newNode = node->right;
	node->right = newNode->left;
	newNode->left = node;
	recountHeight(node);
	recountHeight(newNode);
	return newNode;
}

Dictionary* balanceTree(Dictionary* node)
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

Dictionary* initDictionary()
{
	Dictionary* newNode = calloc(1, sizeof(Dictionary));
	if (newNode == NULL)
	{
		return NULL;
	}
	return newNode;
}

Dictionary* addValue(Dictionary* root, char* key, char* value)
{
	if (root == NULL) {
		root = initDictionary();
		root->value = value;
		root->key = key;
		return balanceTree(root);
	}
	if (root->key == NULL)
	{
		root->value = value;
		root->key = key;
		return root;
	}
	int cmpRes = strcmp(root->key, key);
	if (cmpRes == 0) {
		root->value = value;
	}
	else if (cmpRes > 0) {
		root->left = addValue(root->left, key, value);
	}
	else {
		root->right = addValue(root->right, key, value);
	}
	return balanceTree(root);
}

Dictionary* findNode(Dictionary* root, const char* key)
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

char* findValueByKey(Dictionary* root, const char* key)
{
	Dictionary* node = findNode(root, key);
	if (node == NULL) {
		return NULL;
	}
	return node->value;
}

Dictionary* findMinimum(Dictionary* node)
{
	if (node == NULL)
	{
		return NULL;
	}
	return node->left == NULL ? node : findMinimum(node->left);
}

Dictionary* removeMinimum(Dictionary* node)
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

Dictionary* deleteRecord(Dictionary* root, const char* key)
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
		Dictionary* left = root->left;
		Dictionary* right = root->right;
		root->key = NULL;
		root->value = NULL;
		free(root);
		if (right == NULL)
		{
			return left;
		}
		Dictionary* minimum = findMinimum(right);
		minimum->right = removeMinimum(right);
		minimum->left = left;
		return balanceTree(minimum);
	}
	return balanceTree(root);
}