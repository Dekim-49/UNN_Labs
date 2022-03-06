#pragma once
int Empty(int top); // Проверка стэка
void Push(char* stack, int* top, char value);
void Pop(char* stack, int* top); //удалить элемент из массива
char Peek(char* stack, int* top); //взять 
void ExaminationBracket(char* stack, char* buf, int* top);
int Priority(char value);
