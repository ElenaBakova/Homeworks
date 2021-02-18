#include "Tree.h"
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include <ctype.h>

typedef struct Node {
	char operator;
	int value;
	struct Node* left;
	struct Node* right;
} Node;

typedef struct Tree {
	struct Node* root;
} Tree;

Tree* makeTree(void)
{
	return calloc(1, sizeof(Tree));
}

bool isOperator(char symbol)
{
	return (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/');
}

int makeNumber(char* string, int* position)
{
	int number = 0;
	for (; isdigit(string[*position]); (*position)++)
	{
		number = number * 10 + (string[*position] - '0');
	}
	return number;
}

Node* createTree(Node* node, char* string, int* position)
{
	while ((*position) < strlen(string) && !isdigit(string[*position]) && !isOperator(string[*position]))
	{
		(*position)++;
	}

	node = calloc(1, sizeof(Node));
	if (node == NULL)
	{
		return NULL;
	}
	if (isOperator(string[*position]))
	{
		node->operator = string[*position];
		(*position)++;
		node->left = createTree(node->left, string, position);
		node->right = createTree(node->right, string, position);
	}
	else if (isdigit(string[*position]))
	{
		node->value = makeNumber(string, position);
		(*position)++;
	}
	return node;
}

void buildTree(Tree* tree, char* string)
{
	if (tree == NULL)
	{
		return;
	}
	int position = 0;
	tree->root = createTree(tree->root, string, &position);
}

int countExpression(Node* root)
{
	if (root == NULL)
	{
		return 0;
	}
	switch (root->operator)
	{
	case '+':
		return countExpression(root->left) + countExpression(root->right);
	case '-':
		return countExpression(root->left) - countExpression(root->right);
	case '*':
		return countExpression(root->left) * countExpression(root->right);
	case '/':
		return countExpression(root->left) / countExpression(root->right);
	default:
		return root->value;
	}
}

int getExpressionResult(Tree* tree)
{
	if (tree == NULL)
	{
		return 0;
	}
	return countExpression(tree->root);
}

Node* freeNodes(Node* root)
{
	if (root == NULL)
	{
		return root;
	}
	root->left = freeNodes(root->left);
	root->right = freeNodes(root->right);
	free(root);
	root = NULL;
	return root;
}

void freeTree(Tree* dictionary)
{
	if (dictionary == NULL)
	{
		return;
	}
	dictionary->root = freeNodes(dictionary->root);
	free(dictionary);
}