#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>

//Дерево
struct LEAF
{
	int info;
	LEAF* left;
	LEAF* right;
};
LEAF* CreateLeaf(int data)
{
	//Создание пустого элемента типа Лист
	LEAF* list = (LEAF*)malloc(sizeof(LEAF));
	//Заполняем указатели и поле info
	list->left = NULL;
	list->right = NULL;
	list->info = data;
	return list;
}
LEAF* CreateTree(LEAF* list, int data)
{
	// Добавление первого значения в корень
	if (list == NULL) return CreateLeaf(data);
	// Поиск места и добавление элемента
	if (list->info > data) list->left = CreateTree(list->left, data);
	else list->right = CreateTree(list->right, data);
	return list;
}
void PrintTree(LEAF* list)
{
	static int level = 0;
	//Если дерево пустое
	if (list == NULL) return;
	level++;
	PrintTree(list->left);
	printf("(Level %d) %d\n", level, list->info); // вывод информации о вершине
	PrintTree(list->right);
	level--;
}
int Count(LEAF* list)
{
	if (list == NULL)
		return 0;
	return Count(list->right) + Count(list->left) + 1;
}
void Print_pre_order(LEAF* v)
{
	if (v)
	{
		printf("%d ", v->info);
		Print_pre_order(v->left);
		Print_pre_order(v->right);
	}
}
void Print_in_order(LEAF* v)
{
	if (v)
	{
		Print_in_order(v->left);
		printf("%d ", v->info);
		Print_in_order(v->right);
	}
}
void Print_post_order(LEAF* v)
{
	if (v)
	{
		Print_post_order(v->left);
		Print_post_order(v->right);
		printf("%d ", v->info);
	}
}
int HeightTree(LEAF* list)
{
	static int level = 0;
	static int height = -1;

	if (list == NULL) return 0;	//Если дерево пустое
	
	level++;
	if (level-1 > height) height = level - 1;
	HeightTree(list->left);
	HeightTree(list->right);
	level--;
	return height;
}
int CountLeaf(LEAF* list, int* count)
{
	if (!list) return 0;
	else
	{
		if ((list->left == NULL) && (list->right == NULL)) (*count)++;
	}
	CountLeaf(list->left, count);
	CountLeaf(list->right, count);
	return *count;
}
void DeleteTree(LEAF* tree)
{
	if (tree->left) DeleteTree(tree->left);
	if (tree->right) DeleteTree(tree->right);
	delete tree;
}

//Очередь
struct ZVENO
{
	LEAF list; //информационное поле
	ZVENO* next; //поле связки элементов, указатель на следующий элемент
};
ZVENO* Neww()
{
	ZVENO* itemList;
	itemList = (ZVENO*)malloc(sizeof(ZVENO));
	
	itemList->list.info = 0;
	itemList->list.right = NULL;
	itemList->list.left = NULL;

	itemList->next = NULL;
	return itemList;
}
ZVENO* DeleteHead(ZVENO* head)
{
	ZVENO* hewHead;
	hewHead = head->next;
	free(head);
	return hewHead;
}
ZVENO* AddLast(ZVENO* head, LEAF* list)
{
	ZVENO* itemList = Neww();
	ZVENO* pointer = head;
	while (pointer->next != NULL) pointer = pointer->next;
	pointer->next = itemList;
	
	itemList->list.info = list->info;
	itemList->list.right = list->right;
	itemList->list.left = list->left;
	itemList->next = NULL;
	return head;
}
void Printwidth(LEAF* list)
{
	int count = Count(list);
	ZVENO* Head = Neww();
	Head->list.info = list->info;
	Head->list.right = list->right;
	Head->list.left = list->left;

	for (int i = 0; i < count; i++)
	{
		printf("%d ", Head->list.info);
		if (Head->list.left != NULL) Head = AddLast(Head, Head->list.left);
		if (Head->list.right != NULL) Head = AddLast(Head, Head->list.right);
		Head = DeleteHead(Head);
	}
}