#pragma once
int Empty(int top); // �������� �����
void Push(char* stack, int* top, char value);
void Pop(char* stack, int* top); //������� ������� �� �������
char Peek(char* stack, int* top); //����� 
void ExaminationBracket(char* stack, char* buf, int* top);
int Priority(char value);
