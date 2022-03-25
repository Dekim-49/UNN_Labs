#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>
#pragma warning(disable : 4996)

#define q 70
#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

// Структура "Звено", элемент односвязного списка
struct ZVENO
{
	int info; //информационное поле
	ZVENO* next; //поле связки элементов, указатель на следующий элемент
};

// Прототипы функций
ZVENO* Neww();
ZVENO* AddFirst(ZVENO * head, int data, int* count);
ZVENO* AddLast(ZVENO * head, int data, int* count);
int AddNext(ZVENO * head, int value, int data, int* count);
ZVENO* DeleteHead(ZVENO* head, int* count);
int DeleteNext(ZVENO* head, int value, int* count);
int DeleteLast(ZVENO* head, int* count);
void Print(ZVENO* head, int* count);


int main()
{
	//Русский язык 
	setlocale(LC_ALL, "Rus"); system("chcp 1251");

	//Приветствие
	printf("Дисциплина: Основы алгоритмизации и алгоязыки\n\n");
	Space(23); printf("Лабораторная работа # 2\n\n");
	Space(15); printf("Односвязный список\n\n");
	Space(40); printf("Программа работает со структурой Список,\n");
	Space(40); printf("вносит значения в него и удаляет из него\n");
	Space(60); printf("------------------------------------------------------------\n\n");

	// Создание пустого списка
	ZVENO* head = NULL;

	// Открытие файла
	Space(q); printf("  | Происходит открытие файла\n");
	Space(q); printf("  | . . . \n");
	FILE* file;
	if ((file = fopen("laba2.txt", "r")) == NULL)
	{
		Space(q); perror("!!| Произошла ошибка чтения файла!\n");
		exit(0);
	}
	Space(q); printf("  | Файл успешно открыт!\n");

	//Создание нового пустого элемента, чтение данных из файла и печать
	
	int num = 0; //Считываемое значение
	int count = 0; //Количество элементов в списке
	
	ZVENO* itemList = Neww();
	while (fscanf_s(file, "%d", &num) != -1)
	{
		head = AddFirst(head, num, &count);
	}
	fclose(file);
	Print(head, &count);

menu:
	lineBreak;
	Space(q); printf("  | -------------------------------- |\n");
	Space(q); printf("? |          Выберите опцию          |\n");
	Space(q); printf("  | -------------------------------- |\n");
	Space(q); printf("  | 1 | Напечатать список            |\n");
	Space(q); printf("  | 2 | Сохранить изменения в файл   |\n");
	Space(q); printf("  | 3 | Добавить новый элемент       |\n");
	Space(q); printf("  | 4 | Удалить элемент              |\n");
	Space(q); printf("  | 5 | Вывести количество элементов |\n");
	Space(q); printf("  | 6 | Выход                        |\n");
	Space(q); printf("  | -------------------------------- |\n");
	Space(q); printf(">>| ");

	// Реализацияя выбора 
	int userChoose = 0;
	do
	{
		scanf_s("%d", &userChoose);
		if (userChoose > 7 || userChoose < 1)
		{
			Space(q); printf("!!| Опции не существует\n");
			Space(q); printf(">>|");
		}
	} while (userChoose > 7 || userChoose < 1);
	Space(q); printf("  | -------------------------------- |\n\n");
	
	switch (userChoose)
	{
	case 1:
	{
		Space(17); printf("Напечатать список\n");
		Space(31); printf("-------------------------------\n");
		Print(head, &count);
		goto menu;
	}
	case 2:
	{
		Space(26); printf("Сохранить изменения в файл\n");
		Space(31); printf("-------------------------------\n");
		FILE* file;
		if ((file = fopen("laba2.txt", "w")) == NULL)
		{
			Space(q); perror("!!| Произошла ошибка при открытии файла!\n");
			exit(0);
		}
		ZVENO* pointer = head;
		for (int i = 0; i < count; i++)
		{
			fprintf(file, "%d\n", pointer->info);
			pointer = pointer->next;
		}
		fclose(file);
		Space(q); printf("  | Изменения сохранены!\n");
		goto menu;
	}
	case 3:
	{
		Space(22); printf("Добавить новый элемент\n");
		Space(31); printf("-------------------------------\n");
		Space(q); printf(" ?| Куда вы хотите добавить новый элемент?\n");
		Space(q); printf("  | ------------------ |\n");
		Space(q); printf("  | 1 | В начало       |\n");
		Space(q); printf("  | 2 | В середину     |\n");
		Space(q); printf("  | 3 | В конец        |\n");
		Space(q); printf("  | ------------------ |\n");
		Space(q); printf(">>| ");
		
		// Реализация выбора
		int userChoose = 0;
		do
		{
			scanf_s("%d", &userChoose);
			if (userChoose > 3 || userChoose < 1)
			{
				Space(q); printf("!!| Опции не существует\n");
				Space(q); printf(">>|");
			}
		} while (userChoose > 3 || userChoose < 1);

		switch (userChoose)
		{
		case 1:
		{
			Space(q); printf(" ?| Какое число хотите добавить в начало?\n");
			Space(q); printf(">>| ");
			int userNumber = 0;
			scanf_s("%d", &userNumber);
			head = AddFirst(head, userNumber, &count);
			Print(head, &count);
			Space(q); printf(" !| Элемент успешно добавлен!\n");
			break;
		}
		case 2:
		{
			Space(q); printf(" ?| Какое число хотите добавить в середину?\n");
			Space(q); printf(">>| ");
			int userNumber = 0;
			scanf_s("%d", &userNumber);
			Space(q); printf(" ?| После какого числа нужно вставить ваше число?\n");
			Space(q); printf(">>| ");
			int userNumberFromList = 0;
			scanf_s("%d", &userNumberFromList);
			AddNext(head, userNumberFromList, userNumber, &count);
			Print(head, &count);
			Space(q); printf(" !| Элемент успешно добавлен!\n");
			break;
		}
		case 3:
		{
			Space(q); printf(" ?| Какое число хотите добавить в конец?\n");
			Space(q); printf(">>| ");
			int userNumber = 0;
			scanf_s("%d", &userNumber);
			head = AddLast(head, userNumber, &count);
			Print(head, &count);
			Space(q); printf(" !| Элемент успешно добавлен!\n");
			break;
		}
		}
		goto menu;
	}
	case 4:
	{
		Space(15); printf("Удалить элемент\n");
		Space(31); printf("-------------------------------\n");
		
		// Выбор вида удаления 
		Space(q); printf(" ?| Выберите тип удаляемых данных\n");
		Space(q); printf("  | ------------------------------------------ |\n");
		Space(q); printf("  | 1 | По конкретному значению                |\n");
		Space(q); printf("  | 2 | По чётности/нечетности места элементов |\n");
		Space(q); printf("  | 3 | Заданием неравенства                   |\n");
		Space(q); printf("  | ------------------------------------------ |\n");
		Space(q); printf(">>| ");
		
		//Реализация выбора
		int userChoose = 0;
		do
		{
			scanf_s("%d", &userChoose);
			if (userChoose > 3 || userChoose < 1)
			{
				Space(q); printf("!!| Опции не существует\n");
				Space(q); printf(">>|");
			}
		} while (userChoose > 3 || userChoose < 1);
		
		switch (userChoose)
		{
		case 1:
		{
			Space(q); printf(" ?| Откуда вы хотите удалить элемент?\n");
			Space(q); printf("  | ------------------- |\n");
			Space(q); printf("  | 1 | Из начала       |\n");
			Space(q); printf("  | 2 | Из середины     |\n");
			Space(q); printf("  | 3 | Из конца        |\n");
			Space(q); printf("  | ------------------- |\n");
			Space(q); printf(">>| ");

			int userChoose = 0;
			do
			{
				scanf_s("%d", &userChoose);
				if (userChoose > 3 || userChoose < 1)
				{
					Space(q); printf("!!| Опции не существует\n");
					Space(q); printf(">>|");
				}
			} while (userChoose > 3 || userChoose < 1);
			switch (userChoose)
			{
			case 1:
			{
				head = DeleteHead(head, &count);
				Print(head, &count);
				Space(q); printf(" !| Элемент успешно удалён!\n");
				Space(q); printf(" !| Память освобождена!\n");
				break;
			}
			case 2:
			{
				Space(q); printf(" ?| Напечатайте элемент, который хотите удалить\n");
				Space(q); printf(">>| ");
				int value = 0;
				scanf_s("%d", &value);
				if (DeleteNext(head, value, &count))
				{
					Print(head, &count);
					Space(q); printf(" !| Элемент успешно удалён!\n");
					Space(q); printf(" !| Память освобождена!\n");
					break;
				}
				else break;

			}
			case 3:
			{
				if (DeleteLast(head, &count))
				{
					Print(head, &count);
					Space(q); printf(" !| Элемент успешно удалён!\n");
					Space(q); printf(" !| Память освобождена!\n");
					break;
				}
				else break;
			}
			}
			break;
		}
		case 2:
		{
			Space(q); printf(" ?| Выберите чётность\n");
			Space(q); printf("  | ----------------------------- |\n");
			Space(q); printf("  | 1 | Удалить чётные элементы   |\n");
			Space(q); printf("  | 2 | Удалить нечетные элементы |\n");
			Space(q); printf("  | ----------------------------- |\n");
			Space(q); printf(">>| ");
			
			int userChoose = 0;
			do
			{
				scanf_s("%d", &userChoose);
				if (userChoose > 2 || userChoose < 1)
				{
					Space(q); printf("!!| Опции не существует\n");
					Space(q); printf(">>|");
				}
			} while (userChoose > 2 || userChoose < 1);

			if (userChoose == 1)
			{
				// Дубликат, хранящий изначальное кол-во элементов, т.к оно меняется в программе
				int c = count;
				for (int i = 1; i < (int)(c / 2) + 1; i++)
				{
					ZVENO* pointer = head;
					int counter = 0; // "индекс" элемента в списке
					while (counter != i)
					{
						pointer = pointer->next;
						counter++;
					}
					if (!DeleteNext(head, (pointer->info), &count)) DeleteLast(head, &count);
				};
				Print(head, &count);
				Space(q); printf(" !| Элементы успешно удалёны!\n");
				Space(q); printf(" !| Память освобождена!\n");
			}
			else
			{
				int c = count;
				for (int i = 0; i < (int)((c+1)/2); i++)
				{
					if (i == 0)
					{
						head = DeleteHead(head, &count);
					}
					else
					{
						ZVENO* pointer = head;
						int counter = 0;
						while (counter != i)
						{
							pointer = pointer->next;
							counter++;
						}
						if (!DeleteNext(head, (pointer->info), &count)) DeleteLast(head, &count);
					}
				}
				Print(head, &count);
				Space(q); printf(" !| Элементы успешно удалёны!\n");
				Space(q); printf(" !| Память освобождена!\n");
			}
			break;
		}
		case 3:
		{
			Space(q); printf(" ?| Укажите число, с которым вы хотите сравнить элементы\n");
			Space(q); printf(">>| ");
			int userNumber = 0;
			scanf_s("%d", &userNumber);
			Space(q); printf(" ?| Выберите знак неравенства\n");
			Space(q); printf("  | Элемент  V  %d?\n", userNumber);
			Space(q); printf("  | ---------------- |\n");
			Space(q); printf("  | 1 | >            |\n");
			Space(q); printf("  | 2 | > или =      |\n");
			Space(q); printf("  | 3 | <            |\n");
			Space(q); printf("  | 4 | < или =      |\n");
			Space(q); printf("  | ---------------- |\n");
			Space(q); printf(">>| ");

			int userChoose = 0;
			do
			{
				scanf_s("%d", &userChoose);
				if (userChoose > 4 || userChoose < 1)
				{
					Space(q); printf("!!| Опции не существует\n");
					Space(q); printf(">>|");
				}
			} while (userChoose > 4 || userChoose < 1);
			switch (userChoose)
			{
			case 1:
			{
				ZVENO* pointer = head;
				while (pointer->next != NULL)
				{
					if (pointer->info > userNumber)
					{
						if (pointer == head) head = DeleteHead(head, &count);
						else DeleteNext(head, pointer->info, &count);
						pointer = head;
					}
					else pointer = pointer->next;
				}
				if ((pointer->next == NULL) && (pointer->info > userNumber)) DeleteLast(head, &count);
				Print(head, &count);
				Space(q); printf(" !| Элементы успешно удалёны!\n");
				Space(q); printf(" !| Память освобождена!\n");
				break;
			}
			case 2:
			{
				ZVENO* pointer = head;
				while (pointer->next != NULL)
				{
					if (pointer->info >= userNumber)
					{
						if (pointer == head) head = DeleteHead(head, &count);
						else DeleteNext(head, pointer->info, &count);
						pointer = head;
					}
					else pointer = pointer->next;
				}
				if ((pointer->next == NULL) && (pointer->info >= userNumber)) DeleteLast(head, &count);
				Print(head, &count);
				Space(q); printf(" !| Элементы успешно удалёны!\n");
				Space(q); printf(" !| Память освобождена!\n");
				break;
			}
			case 3:
			{
				ZVENO* pointer = head;
				while (pointer->next != NULL)
				{
					if (pointer->info < userNumber)
					{
						if (pointer == head) head = DeleteHead(head, &count);
						else DeleteNext(head, pointer->info, &count);
						pointer = head;
					}
					else pointer = pointer->next;
				}
				if ((pointer->next == NULL) && (pointer->info < userNumber)) DeleteLast(head, &count);
				Print(head, &count);
				Space(q); printf(" !| Элементы успешно удалёны!\n");
				Space(q); printf(" !| Память освобождена!\n");
				break;
			}
			case 4:
			{
				ZVENO* pointer = head;
				while (pointer->next != NULL)
				{
					if (pointer->info <= userNumber)
					{
						if (pointer == head) head = DeleteHead(head, &count);
						else DeleteNext(head, pointer->info, &count);
						pointer = head;
					}
					else pointer = pointer->next;
				}
				if ((pointer->next == NULL) && (pointer->info <= userNumber)) DeleteLast(head, &count);
				Print(head, &count);
				Space(q); printf(" !| Элементы успешно удалёны!\n");
				Space(q); printf(" !| Память освобождена!\n");
				break;
			}
			}
			break;
		}
		}
		goto menu;
	}
	case 5:
	{
		Space(28); printf("Вывести количество элементов\n");
		Space(31); printf("-------------------------------\n");
		Space(q); printf("  | Count = %d\n", count);
		goto menu;
	}
	case 6:
	{
		Space(5); printf("Выйти\n\n");
		Space(31); printf("-------------------------------\n");
		Space(12); printf("До свидания!\n");
		exit(0); 
	}
	}
}

// Печать списка на экран
void Print(ZVENO* head, int* count)
{
	ZVENO* pointer = head;
	Space(q); printf("  | LIST: ");
	Space(q); for (int i = 0; i < (*count); i++)
	{
		printf("%d ", pointer->info);
		pointer = pointer->next;
	}
	lineBreak;
}

//Создание нового элемента
ZVENO* Neww()
{
	ZVENO* itemList;
	itemList = (ZVENO*)malloc(sizeof(ZVENO));
	itemList->info = 0;
	itemList->next = NULL;
	return itemList;
}

/*       Удаление       */
//Удалить начало
ZVENO* DeleteHead(ZVENO* head, int* count)
{
	ZVENO* hewHead;
	hewHead = head->next;
	free(head);
	(*count)--;
	return hewHead;
}
//Удалить середину
int DeleteNext(ZVENO* head, int value, int* count)
{
	ZVENO* Element = head;
	if (Element->info == value)
	{
		Space(q); printf("!!| Выберите функцию\n"); 
		Space(q); printf("!!| \"Удалить элемент\" -> \"По конкретному значению\" -> \"Из начала\"\n");
		return 0;
	}
	int i = 0;
	for (i = 0; i < (*count); i++)
	{
		if (Element->info != value)
		{
			Element = Element->next;
		}
		else break;
	}
	if (i == (*count))
	{
		Space(q); printf("!!| Не существует!\n");
		return 0;
	}
	ZVENO* pointer = head;
	while (pointer->next != Element) pointer = pointer->next;
	pointer->next = Element->next;
	free(Element);
	(*count)--;
	return 1;
}
//Удалить последний элемент
int DeleteLast(ZVENO* head, int* count)
{
	ZVENO* Element = head;
	if (Element->next == NULL)
	{
		Space(q); printf("!!| Список пуст!\n");
		return 0;
	}
	while (Element->next != NULL) Element = Element->next;
	ZVENO* pointer = head;
	while (pointer->next != Element) pointer = pointer->next;
	pointer->next = NULL;
	free(Element);
	(*count)--;
	return 1;
}

/*       Добавление       */
// Добавление в начало списка
ZVENO* AddFirst(ZVENO* head, int data, int* count)
{
	ZVENO* itemList = Neww();
	itemList->info = data;
	itemList->next = head;
	(*count)++;
	return itemList;
}
// Добавление в конец списка
ZVENO* AddLast(ZVENO* head, int data, int* count)
{
	ZVENO* itemList = Neww();
	ZVENO* pointer = head;
	while (pointer->next != NULL) pointer = pointer->next;
	pointer->next = itemList;
	itemList->info = data;
	itemList->next = NULL;
	(*count)++;
	return head;
}
// Добавление в середину списка
int AddNext(ZVENO* head, int value, int data, int* count)
{
	ZVENO* pointer = head;       //текущий указатель
	//ищем место для вставки элемента и перемещаем текущий указатель
	while ((pointer->info != value) && (pointer->next != 0)) pointer = pointer->next;  
	//если дошли до последнего элемента, значит условие для вставки не выполнено
	if (pointer->next == NULL) return 0; 
	ZVENO* itemList = Neww();
	itemList->info = data;
	itemList->next = pointer->next;
	pointer->next = itemList;
	(*count)++;
	return 1;
}

