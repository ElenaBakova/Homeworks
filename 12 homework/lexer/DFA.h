#pragma once

const int statesNumber;
const int symbolsNumber;

// Reads states table from file, returns table
int** readTable();

// Returns string only with commented part
char* DFA(int** statesTable, char* string);