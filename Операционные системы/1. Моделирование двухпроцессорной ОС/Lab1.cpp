#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>
#include <cstring> 
#pragma warning(disable : 4996)
#define q 70
#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

int main()
{
	//Русский язык
	setlocale(LC_ALL, "Rus"); system("chcp 1251");

	// Переменные 
	unsigned int count = 0; // Количество процессов
	int* arrCPU = NULL; // Массив времен обработки процессов
	int* arrID = NULL; // Массив идентификаторов
	

	printf("Дисциплина: Операционные системы\n\n");
	Space(23); printf("Лабораторная работа # 1\n\n");
	Space(33); printf("Моделирование двухпроцессорной ОС\n\n");
	Space(52); printf("Программа считывает с файла ID и время работы каждой\n");
	Space(59); printf("процедуры и возвращает распределние процедур по процессорам\n");
	Space(60); printf("------------------------------------------------------------\n\n");


	// Открытие файла
	Space(q); printf("  | Происходит открытие файла\n");
	Space(q); printf("  | . . . \n");
	FILE* file;
	if ((file = fopen("data2.txt", "r")) == NULL)
	{
		Space(q); perror("!!| Произошла ошибка чтения файла!\n");
		exit(0);
	}
	Space(q); printf("  | Файл успешно открыт!\n");
	Space(q); printf("  |------------------------------\n");

	// Чтение количества процессов 
	fscanf_s(file, "%d", &count);

	// Объявление размера массивов
	arrCPU = (int*)malloc(count * sizeof(int));
	arrID = (int*)malloc(count * sizeof(int));

	// Чтение данных из файла
	for (int index = 0; index < count; index++) fscanf_s(file, "%d %d", &arrID[index], &arrCPU[index]);

	// Вывод данных на экран
	Space(q); printf("  | Данные\n");
	Space(q); printf("  | ID  ");
	for (int index = 0; index < count; index++) printf("|%-3d ", arrID[index]); lineBreak;
	Space(q); printf("  | CPU ");
	for (int index = 0; index < count; index++) printf("|%-3d ", arrCPU[index]); lineBreak;
	Space(q); printf("  |------------------------------\n"); lineBreak;

	// Сортировка процессов по убыванию времени
	for (int index = 0; index < count-1; index++)
	{
		for (int jndex = index + 1; jndex < count; jndex++)
		{
			if (arrCPU[index] < arrCPU[jndex])
			{
				int a = arrCPU[index];
				arrCPU[index] = arrCPU[jndex];
				arrCPU[jndex] = a;

				int b = arrID[index];
				arrID[index] = arrID[jndex];
				arrID[jndex] = b;
			}
			
		}
	}

	// Вывод отсортированных данных
	Space(q); printf("  | Отсортированные данные \n");
	Space(q); printf("  | ID  ");
	for (int index = 0; index < count; index++) printf("|%-3d ", arrID[index]);
	lineBreak;
	Space(q); printf("  | CPU ");
	for (int index = 0; index < count; index++) printf("|%-3d ", arrCPU[index]);
	lineBreak;
	Space(q); printf("  |------------------------------\n");
	lineBreak;


	// Переменные
	int* FirstProcess = NULL;  // Массив для хранения ID первого процессора
	int* SecondProcess = NULL; // Массив для хранения ID второго процессора
	int firstSum = 0;          // Сумма времени процессов первого процессора
	int secondSum = 0;         // Сумма времени процессов второго процессора
	int firstIndex = 0;        // Индекс для перемещения по массиву FirstProcess
	int secondIndex = 0;       // Индекс для перемещения по массиву SecondProcess

	// Вывод таблицы распределения процессов
	Space(q); printf("  | --- | 1 процессор (Сумма) | 2 процессор (Сумма)\n");
	Space(q); printf("  | --- | ------------------- | ------------------- |\n");
	for (int index = 0; index < count; index++)
	{
		Space(q); printf("  | #%-2d | ", index + 1);
		if (firstSum <= secondSum)
		{
			firstSum += arrCPU[index];
			FirstProcess = (int*)realloc(FirstProcess, sizeof(int) * (firstIndex + 1));
			FirstProcess[firstIndex] = arrID[index];
			firstIndex++;
			for (int i = 0; i < firstIndex; i++) printf("%d ", FirstProcess[i]);
			printf(" (%d)\n", firstSum);
		}
		else
		{
			printf("                    | ");
			secondSum += arrCPU[index];
			SecondProcess = (int*)realloc(SecondProcess, sizeof(int) * (secondIndex + 1));
			SecondProcess[secondIndex] = arrID[index];
			secondIndex++;
			for (int i = 0; i < secondIndex; i++) printf("%d ", SecondProcess[i]);
			printf(" (%d)\n", secondSum);

		}
	}
	Space(q); printf("  | --- | ------------------- | ------------------- |\n"); lineBreak;

	// Вывод ответа
	Space(q); printf("  | Первый процессор:");
	for (int index = 0; index < firstIndex; index++) printf("%3d", FirstProcess[index]); lineBreak;
	Space(q); printf("  | Сумма: %d\n", firstSum);
	Space(q); printf("  | Второй процессор:");
	for (int index = 0; index < secondIndex; index++) printf("%3d", SecondProcess[index]); lineBreak;
	Space(q); printf("  | Сумма: %d\n", secondSum);
	
	// Чистка динамических массивов
	free(arrCPU);
	free(arrID);
	free(FirstProcess);
	free(SecondProcess);
}