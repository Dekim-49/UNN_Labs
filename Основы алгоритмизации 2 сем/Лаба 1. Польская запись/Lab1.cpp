#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>
#include <cstring> 
#include "Stack.h"

//Константы и функции для оформления
#define q 70
#define LIMIT 20
#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

//   Прототипы
// Функция, выводящая польскую запись
void PolishEntry(char* stack_expression, char* polish_entry, int *index_polish_entry);
// Функция, считающая значение выражение в польской записи
int PolishCalculator(char* polish_entry, int* index_polish_entry);

void main()
{
	//Русский язык
	setlocale(LC_ALL, "Rus"); system("chcp 1251");

	//Переменные
	char stack_bracket[LIMIT] = { 0 };         // Стэк для скобок
	char input_buffer[LIMIT * 2 + 1] = { 0 };  // Вводимое выражение
	int top = -1;                              // Вершина стэка
	char value;                                // Помещаемое в стэк значение

	Space(23); printf("Лабораторная работа # 1\n\n");
	Space(15); printf("Польская запись\n\n");
	Space(51); printf("Программа выясняет корректность расставления скобок\n");
	Space(43); printf("и переписывает префиксную запись в польскую\n");
	Space(60); printf("------------------------------------------------------------\n\n");
	Space(q); printf("? | Введите выражение, содержащее цифры и символы (), +, -, *, /\n");
	Space(q); printf(">>| ");

	//Читаем строку
	gets_s(input_buffer);
	//Проверяем её на корректность
	ExaminationBracket(stack_bracket, input_buffer, &top);

	char polish_entry[LIMIT] = { 0 }; // Строка, хранящая польскую запись
	int index_polish_entry = -1;      // Вершина строки

	// Польская запись
	Space(q); printf("  | Польская запись: ");
	PolishEntry(input_buffer, polish_entry, &index_polish_entry);
	lineBreak;
	// Вывод ответа выражения
	Space(q); printf("  | Значение выражения: ");
	index_polish_entry++; 
	printf("%d", PolishCalculator(polish_entry, &index_polish_entry));
	lineBreak;
	Space(q); printf("  |----------------------------------------\n\n");
}
void PolishEntry(char* stack_expression, char* polish_entry, int *index_polish_entry)
{
	// Переменные
	int p = *index_polish_entry; 
	char stack_sign[LIMIT] = { 0 };  // Стэк для арифметических знаков и скобок 
	int top_sign = -1;               // Вершина стэка для знаков

	for (int i = 0; i < strlen(stack_expression) + 1; i++)
	{
		//Операция над числами
		if (Priority(stack_expression[i]) == 5)
		{
			printf("%c ", stack_expression[i]);
			(p)++;
			polish_entry[p] = stack_expression[i];
		}

		//Операция над (
		if (Priority(stack_expression[i]) == 1) Push(stack_sign, &top_sign, '(');

		//Операция над )
		if (Priority(stack_expression[i]) == 2)
		{
			while (stack_sign[top_sign] != '(')
			{
				printf("%c ", Peek(stack_sign, &top_sign));
				p++;
				polish_entry[p] = Peek(stack_sign, &top_sign);
				Pop(stack_sign, &top_sign);
			}
			Pop(stack_sign, &top_sign);
		}

		// Операция над знаками
		if ((Priority(stack_expression[i]) == 3) || (Priority(stack_expression[i]) == 4))
		{
			if (Empty(top_sign) == 0) Push(stack_sign, &top_sign, stack_expression[i]);
			else
			{
				if (Priority(stack_expression[i]) > Priority(stack_sign[top_sign]))
				{
					Push(stack_sign, &top_sign, stack_expression[i]);
				}
				else
				{
					while ((Priority(stack_expression[i]) <= Priority(stack_sign[top_sign])) && (top_sign != -1))
					{
						printf("%c ", Peek(stack_sign, &top_sign));
						p++;
						polish_entry[p] = Peek(stack_sign, &top_sign);
						Pop(stack_sign, &top_sign);
					}
					Push(stack_sign, &top_sign, stack_expression[i]);
				}
			}
		}
		if (stack_expression[i] == '\0')
		{
			while (top_sign != -1)
			{
				printf("%c ", Peek(stack_sign, &top_sign));
				p++;
				polish_entry[p] = Peek(stack_sign, &top_sign);
				Pop(stack_sign, &top_sign);
			}
		}
	}
	*index_polish_entry = p;
}
int PolishCalculator(char* polish_entry, int* index_polish_entry)
{
	// Переменные
	char stack_number[LIMIT] = { 0 };  // Стэк для цифр
	int index_stack_number = -1;       // Вершина стэка

	for (int i = 0; i < *index_polish_entry; i++)
	{
		if (Priority(polish_entry[i]) == 5) Push(stack_number, &index_stack_number, polish_entry[i]);
		if ((Priority(polish_entry[i]) == 3) || (Priority(polish_entry[i]) == 4))
		{
			char number1 = Peek(stack_number, &index_stack_number);
			Pop(stack_number, &index_stack_number);

			char number2 = Peek(stack_number, &index_stack_number);
			Pop(stack_number, &index_stack_number);


			char arithmetic_operation = polish_entry[i];
			char numeric = 0;
			switch (arithmetic_operation)
			{
			case '+': 
			{
				numeric = (number2 - '0') + (number1 - '0') + '0';
				Push(stack_number, &index_stack_number, numeric);
				break;
			}
			case '-':
			{
				numeric = (number2 - '0') - (number1 - '0') + '0';
				Push(stack_number, &index_stack_number, numeric);
				break;
			}
			case '*':
			{
				numeric = ((number2 - '0') * (number1 - '0')) + '0';
				Push(stack_number, &index_stack_number, numeric);
				break;
			}
			case '/':
			{
				if ((number1 - 48) == 0)
				{
					printf("Деление невозможно!");
					exit(0);
				}
				numeric = ((number2 - '0') / (number1 - '0')) + '0';
				Push(stack_number, &index_stack_number, numeric);
				break;
			}
			default:
				break;
			}
		}
	}
	return (stack_number[0]-48);
}