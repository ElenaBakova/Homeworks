#include "FSM.h"
#include <stdbool.h>
#include <ctype.h>

enum States {
	start,
	firstDigit,
	point, 
	secondDigit,
	seenE,
	sign, 
	thirdDigit
};

bool isRealNumber(char* string)
{
	enum States state = start;
	int current = 0;
	while (true)
	{
		char token = string[current];
		switch (state)
		{
		case start:
			if (isdigit(token))
			{
				state = firstDigit;
				break;
			}
			return false;
		case firstDigit:
			if (isdigit(token))
			{
				break;
			}
			if (token == '.')
			{
				state = point;
				break;
			}
			else if (token == 'E')
			{
				state = seenE;
				break;
			}
			else if (token == '\0' || token == '\n')
			{
				return true;
			}
			return false;
		case point:
			if (isdigit(token))
			{
				state = secondDigit;
				break;
			}
			return false;
		case secondDigit:
			if (isdigit(token))
			{
				break;
			}
			else if (token == '\0' || token == '\n')
			{
				return true;
			}
			if (token == 'E')
			{
				state = seenE;
				break;
			}
			return false;
		case seenE:
			if (isdigit(token))
			{
				state = thirdDigit;
				break;
			}
			if (token == '-' || token == '+')
			{
				state = sign;
				break;
			}
			return false;
		case sign:
			if (isdigit(token))
			{
				state = thirdDigit;
				break;
			}
			return false;
		case thirdDigit:
			if (isdigit(token))
			{
				break;
			}
			else if (token == '\0' || token == '\n')
			{
				return true;
			}
			return false;
		default:
			break;
		}
		current++;
	}
}