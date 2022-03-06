#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>
#define LIMIT 20
#define q 70
#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

// ������� ���������� �������
int Priority(char value)
{
	if (value == '(') return 1;
	if (value == ')') return 2;
	if ((value == '+') || (value == '-')) return 3;
	if ((value == '*') || (value == '/')) return 4;
	if ((value > 47) && (value < 58)) return 5;
}

//������� �������� �� �������, ��������������
int Empty(int top)
{
	if (top == -1) return 0; //������
	else if (top == LIMIT - 1) return 2; //������
	else if ((top > -1) && (top < LIMIT - 1)) return 1; //�� ������
}

//������� ���������� � ����
void Push(char* stack, int* top, char value)
{
	if ((Empty(*top) == 0) || (Empty(*top) == 1)) //�������� 
	{
		(*top)++; //���� ����� ���������� �� ������� ������
		stack[(*top)] = value;  //����������� �������� � ����
	}
	else
	{
		lineBreak; Space(q); printf("!!| ���� ����������!\n"); exit(0);
	}
}

//������� �������� �� �����
void Pop(char* stack, int* top)
{
	if ((Empty(*top) == 2) || (Empty(*top) == 1))
	{
		stack[(*top)] = '0';
		(*top)--;
	}
	else
	{
		lineBreak; Space(q); printf("!!| ���������� ������� �������!\n"); exit(0);
	}
}

//������� ������ �������� ��� ��������
char Peek(char* stack, int* top)
{
	if ((Empty(*top) == 2) || (Empty(*top) == 1)) //�������� 
	{
		return stack[(*top)];
	}
	else
	{
		lineBreak; Space(q); printf("!!| ���������� ����� �������!\n"); exit(0);
	}
}

//������� �������� �� ������������ ������
void ExaminationBracket(char* stack, char* buf, int* top)
{
	int Numeric = 0;
	for (int i = 0; ((i < LIMIT * 2) && (buf[i] != '0')); i++)
	{
		if (Priority(buf[i]) == 5) Numeric++;
		if ((buf[i] == ')') && (Empty(*top) == 0))
		{
			lineBreak; Space(q); printf("!!| ��������� �����������!\n");
			exit(0);
		}
		if (buf[i] == '(') Push(stack, top, '(');
		if (buf[i] == ')') Pop(stack, top);
	}
	if ((Empty(*top) == 0) && (Numeric > 1))
	{
		lineBreak; Space(q); printf("  | ��������� ��������� =)\n");
	}
	else
	{
		lineBreak; Space(q); printf("!!| ��������� �����������!\n");
		exit(0);
	}

}
