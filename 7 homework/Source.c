#include "Tree.h"
#include <stdio.h>
#include <stdlib.h>

int main()
{
	Node* root = NULL;
	root = add(root, 2, "dkjdj");
	root = add(root, 1, "sdh");
	root = add(root, 3, "s");
	root = add(root, 3, "sue");
	root = add(root, 4, "sew");
	printf("%s", *getS(root));

	free(root);
	return 0;
}