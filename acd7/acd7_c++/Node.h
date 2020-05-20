#pragma once
#include <Bits.h>

class Node
{
public:
	char Data;
	Node* Link;
	Node(char data) {
		Data = data;
		Link = NULL;
	}
};