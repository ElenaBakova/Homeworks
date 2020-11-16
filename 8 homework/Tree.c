#include "Tree.h"
#include <stdio.h>
#include <string.h>

typedef struct Node {
	char* key;
	char* value;
	int height;
	struct Node* left;
	struct Node* right;
} Node;

int getHeight(Node* node)
{
	if (node == NULL) {
		return 0;
	}
	return node->height;
}

int getBalanceFactor(Node* node)
{
	if (node == NULL) {
		return NULL;
	}
	return node->right->height - node->left->height;
}

void recountHeight(Node* node)
{
	int maxSonHeight = (node->right->height > node->left->height ? node->right->height : node->left->height);
	node->height = maxSonHeight + 1;
}

Node* rotateRight(Node* node)
{
	Node* newNode = node->left;
	node->left = newNode->right;
	newNode->right = node;
	recountHeight(node);
	recountHeight(newNode);
	return newNode;
}

Node* rotateLeft(Node* node)
{
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
		if (getBalanceFactor(node->right) < 0) {
			node->right = rotateRight(node->right);
		}
		return rotateLeft(node);
	}
	else if (getBalanceFactor(node) == -2)
	{
		if (getBalanceFactor(node->left) > 0) {
			node->left = rotateLeft(node->left);
		}
		return rotateRight(node);
	}
	return node;
}

Node* initNode(const char* key, const char* value)
{
	Node* newNode = calloc(1, sizeof(Node));
	if (newNode == NULL) {
		return NULL;
	}
	newNode->key = key;
	newNode->value = value;
	return newNode;
}

Node* addNode(Node* root, const char* key, const char* value)
{
	if (root == NULL) {
		return initNode(key, value);
	}
	int cmpRes = strcmp(root->key, key);
	if (cmpRes == 0) {
		strcpy(root->value, value);
	}
	else if (cmpRes > 0) {
		root->left = addNode(root->left, key, value);
	}
	else {
		root->right = addNode(root->right, key, value);
	}
	return balanceTree(root);
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

char* findValueByNode(Node* root, const char* key)
{
	Node* node = findNode(root, key);
	if (node == NULL) {
		return NULL;
	}
	return node->value;
}

Node* deleteNode(Node* root, const char* key)
{

}