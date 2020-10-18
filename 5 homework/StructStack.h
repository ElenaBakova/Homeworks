#pragma once

typedef struct StackElement {
	int value;
	struct StackElement* next;
}StackElement;