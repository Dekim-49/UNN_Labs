#pragma once

//������
struct LEAF
{
	int info;
	LEAF* left;
	LEAF* right;
};
LEAF* CreateLeaf(int data); //������� ������� ������
LEAF* CreateTree(LEAF* list, int data); //������� ������
void PrintTree(LEAF* list); //���������� ������
void Printwidth(LEAF* list); // ����� � ������
int Count(LEAF* list); //���������� �����
void Printwidth(LEAF* list); //����� � ������
void Print_pre_order(LEAF* v); //������ �����
void Print_in_order(LEAF* v); //���������� �����
void Print_post_order(LEAF* v); //�������� �����
int HeightTree(LEAF* list); //������ ������
int CountLeaf(LEAF* list, int* count); // ����� �������
void DeleteTree(LEAF* tree); //������� �� ������

//�������
struct ZVENO
{
	LEAF list; //�������������� ����
	ZVENO* next; //���� ������ ���������, ��������� �� ��������� �������
};
ZVENO* Neww();
ZVENO* DeleteHead(ZVENO* head);
ZVENO* AddLast(ZVENO* head, LEAF* list);



