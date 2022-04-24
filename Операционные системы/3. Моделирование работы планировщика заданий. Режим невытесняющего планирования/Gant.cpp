#include <stdio.h>
#include <conio.h>
#include <locale.h>
#include <string.h>
#include <stdlib.h>
#pragma warning(disable : 4996)

#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

int FCFS(int* arr, int* ind, int count);
int SJF(int* arr, int* ind, int count);

int main()
{
	//Русский язык
	setlocale(LC_ALL, "Rus"); system("chcp 1251");

	printf("Дисциплина: Операционные системы\n\n");
	Space(23); printf("Лабораторная работа # 3\n\n");
	Space(49); printf("Моделирование работы планировщика потоков заданий\n");
	Space(32); printf("Режим - невытесняющее планирование\n\n");
	Space(43); printf("Программа принимает на вход время обработки\n");
	Space(54); printf("процессов, выводит порядок их обработки и график Ганта\n");
	Space(55); printf("-------------------------------------------------------\n\n");

	int countCPUburst = 0; //колеичество процессов
	int* CPUburst = NULL; //Массив времён обрабортки
	int* indexCPUburst = NULL; //массив нумерации процессов

	printf(" ?| Каким способом Вы хотите ввести данные?\n");
	printf("  | ------------------------ |\n");
	printf("  | 1 | Ввод с клавиатуры    |\n");
	printf("  | 2 | Чтение из файла      |\n");
	printf("  | ------------------------ |\n");
	printf(">>| ");

	// Реализацияя выбора 
	int userChoose = 0;
	do
	{
		scanf_s("%d", &userChoose);
		if (userChoose > 2 || userChoose < 1)
		{
			printf("!!| Опции не существует\n");
			printf(">>| ");
		}
	} while (userChoose > 2 || userChoose < 1);
	printf("  | ------------------------ |\n");

	switch (userChoose)
	{
	case 1:
	{
		lineBreak;
		Space(17); printf("Ввод с клавиатуры\n\n");
		printf(" ?| Введите количество процессов\n");
		printf(">>| ");
		scanf_s("%d", &countCPUburst);
		CPUburst = (int*)malloc(sizeof(int) * countCPUburst);
		indexCPUburst = (int*)malloc(sizeof(int) * countCPUburst);
		printf(" ?| Введите время обработки процессов\n");
		for (int i = 0; i < countCPUburst; i++)
		{
			printf(">>| #%-3d | ", i + 1);
			scanf_s("%d", &CPUburst[i]);
			indexCPUburst[i] = i;
		}
		break;
	}
	case 2:
	{
		Space(15); printf("Чтение из файла\n\n");
		printf("  | Происходит открытие файла\n");
		printf("  | . . . \n");
		FILE* file;
		if ((file = fopen("gant.txt", "r")) == NULL)
		{
			perror("!!| Произошла ошибка чтения файла!\n");
			exit(0);
		}
		printf("  | Файл успешно открыт!\n");
		fscanf_s(file, "%d", &countCPUburst);
		CPUburst = (int*)malloc(sizeof(int) * countCPUburst);
		indexCPUburst = (int*)malloc(sizeof(int) * countCPUburst);
		for (int i = 0; i < countCPUburst; i++)
		{
			fscanf_s(file, "%d", &CPUburst[i]);
			printf("  | #%-3d | %d\n", i + 1, CPUburst[i]);
			indexCPUburst[i] = i;
		}
		fclose(file);
		break;
	}
	}

	printf("\n   Алгоритм FCFS\n");
	printf("   --------------- \n");
	FCFS(CPUburst, indexCPUburst, countCPUburst);
	printf("\n   Алгоритм SJF\n");
	printf("   -------------- \n");
	SJF(CPUburst, indexCPUburst, countCPUburst);
	
	free(CPUburst);
	free(indexCPUburst);
}

int FCFS(int* arr, int* ind, int count)
{
	int avgTime = 0; //Среднее время
	int tekushee = 0;
	//Среднее время ожидания
	printf("%2d| ", ind[0]+1);
	for (int j = 0; j < arr[0]; j++) printf("*");
	lineBreak;
	for (int i = 0; i < count - 1; i++)
	{
		tekushee += arr[i];
		avgTime += tekushee;
		printf("%2d| ", ind[i+1]+1);
		for (int j = 0; j < tekushee; j++) printf("-");
		for (int j = 0; j < arr[i+1]; j++) printf("*");
		lineBreak;
	}

	printf("  | Среднее время ожидания = %-10.2f \n", float(avgTime) / float(count));

	tekushee = 0;
	avgTime = 0;
	//Среднее время исполнения
	for (int i = 0; i < count; i++)
	{
		tekushee += arr[i];
		avgTime += tekushee;
	}
	printf("  | Среднее время исполнения = %-10.2f \n", float(avgTime) / float(count));
	return 0;

}

int SJF(int* arr, int* ind, int count)
{
	//Сортировка массива времени процессов по возрастанию
	for (int i = 0; i < count - 1; i++)
	{
		for (int j = i; j < count; j++)
		{
			if (arr[j] < arr[i])
			{
				int u = 0;
				//сортируем времена
				u = arr[i];
				arr[i] = arr[j];
				arr[j] = u;
				//сортируем индексы
				u = ind[i];
				ind[i] = ind[j];
				ind[j] = u;
			}
		}
	}
	FCFS(arr, ind, count);
	return 0;
}
