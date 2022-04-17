#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>
#include "Header.h"
#pragma warning(disable : 4996)

#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

int main()
{
	//Русский язык 
	setlocale(LC_ALL, "Rus"); system("chcp 1251");
	printf("Дисциплина: Основы алгоритмизации и алгоритмические языки\n\n");
	Space(23); printf("Лабораторная работа #3\n\n");
	Space(15); printf("Бинарное дерево\n\n");
	Space(44); printf("Программа хранит элементы в бинарном дереве,\n");
	Space(48); printf("совершает рекурсивные обходы, считает количество\n");
	Space(46); printf("элементов, количество листьев и удаляет дерево\n");
	Space(60); printf("------------------------------------------------------------\n\n");

	// Корень дерева
	LEAF* Root = NULL;

	//Открытие файла
	FILE* file;
	if ((file = fopen("tree.txt", "r")) == NULL)
	{
		perror("!!| Произошла ошибка чтения файла!\n");
		exit(0);
	}

	// Считываемй элемент
	int num = 0;

	//Чтение из файла и добавление элементов в дерево
	printf("  | Элементы: ");
	while (fscanf_s(file, "%d", &num) != -1)
	{
		printf("%d ", num);
		Root = CreateTree(Root, num);
	}
	fclose(file);
	lineBreak;

	//Вывод дерева
	PrintTree(Root);
	lineBreak;

	printf("  | Количество элементов: %d\n", Count(Root));
	printf("  | Высота дерева: %d\n", HeightTree(Root));
	int count = 0;
	printf("  | Число листьев дерева: %d\n", CountLeaf(Root, &count));	
	
	//Вывод обходов (рекурсивных)
	printf("  | Обход в ширину:  ");  Printwidth(Root); lineBreak;
	printf("  | Прямой обход:    ");  Print_pre_order(Root); lineBreak;
	printf("  | Поперечный обход:");  Print_in_order(Root); lineBreak;
	printf("  | Обратный обход:  ");  Print_post_order(Root); lineBreak;

	lineBreak;
	printf("  | Удаление дерева\n"); DeleteTree(Root);
}







