#include "FSM.h"
#include <stdbool.h>
#include <ctype.h>

bool isRealNumber(char* string)
{
	int current = 0;
	int state = 0;
	while (true)
	{
		char token = string[current];
		switch (state)
		{
		case 0:
		case 2:
		case 5:
			if (isdigit(token))
			{
				state++;
				break;
			}
			return false;
		case 1:
			if (isdigit(token))
			{
				break;
			}
			if (token == '.')
			{
				state = 2;
				break;
			}
			else if (token == 'E')
			{
				state = 4;
				break;
			}
			else if (token == '\0' || token == '\n')
			{
				return true;
			}
			return false;
		case 3:
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
				state = 4;
				break;
			}
			return false;
		case 4:
			if (isdigit(token))
			{
				state = 6;
				break;
			}
			if (token == '-' || token == '+')
			{
				state = 5;
				break;
			}
			return false;
		case 6:
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