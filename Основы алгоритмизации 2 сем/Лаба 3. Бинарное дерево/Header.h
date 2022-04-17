#pragma once

//Дерево
struct LEAF
{
	int info;
	LEAF* left;
	LEAF* right;
};
LEAF* CreateLeaf(int data); //Создать элемент дерева
LEAF* CreateTree(LEAF* list, int data); //Создать дерево
void PrintTree(LEAF* list); //Напечатать дерево
void Printwidth(LEAF* list); // Обход в ширину
int Count(LEAF* list); //количество узлов
void Printwidth(LEAF* list); //обход в ширину
void Print_pre_order(LEAF* v); //прямой обход
void Print_in_order(LEAF* v); //поперечный обход
void Print_post_order(LEAF* v); //обратный обход
int HeightTree(LEAF* list); //Высота дерева
int CountLeaf(LEAF* list, int* count); // Число листьев
void DeleteTree(LEAF* tree); //удаляет всё дерево

//Очередь
struct ZVENO
{
	LEAF list; //информационное поле
	ZVENO* next; //поле связки элементов, указатель на следующий элемент
};
ZVENO* Neww();
ZVENO* DeleteHead(ZVENO* head);
ZVENO* AddLast(ZVENO* head, LEAF* list);



