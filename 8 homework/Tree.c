#include "Tree.h"
#include <stdio.h>

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
		return -1000;
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