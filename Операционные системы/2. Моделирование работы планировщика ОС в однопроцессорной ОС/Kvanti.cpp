#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <locale.h>
#include <time.h>
#pragma warning(disable : 4996)

#define q 70
#define lineBreak printf("\n")
#define Space(lenghtString) for (int i = 0; i < ((80-lenghtString)/2); i++) printf(" ")

int main()
{
	//Русский язык
	setlocale(LC_ALL, "Rus"); system("chcp 1251");

	// переменные
	int timeKvant = 0; //Квант времени, данный процессору 
	int sumTimeKvant = 0; //Суммарное время квантов
	int processCount = 0; // Количество данных процессов
	int* indexProcess = NULL;  //Индекс процесса
	int* meaningProcess = NULL;  //Значение процесса
	int* processNumber = NULL; // Требуемый массив номеров процессов

	//Приветственное сообщение
	printf("Дисциплина: Операционные системы\n\n");
	Space(23); printf("Лабораторная работа # 2\n\n");
	Space(36); printf("Моделирование работы планировщика ОС\n\n");
	Space(43); printf("Программа принимает на вход время обработки\n");
	Space(40); printf("процессов и выводит порядок их обработки\n");
	Space(47); printf("-----------------------------------------------\n\n");

	// Меню выбора 
	Space(q); printf(" ?| Каким способом Вы хотите ввести данные?\n");
	Space(q); printf("  | --------------------------------------- |\n");
	Space(q); printf("  | 1 | Ввод с клавиатуры                   |\n");
	Space(q); printf("  | 2 | Чтение из файла                     |\n");
	Space(q); printf("  | 3 | Рандомизация данных                 |\n");
	Space(q); printf("  | --------------------------------------- |\n");
	Space(q); printf(">>| ");

	// Реализацияя выбора 
	int userChoose = 0;
	do
	{
		scanf_s("%d", &userChoose);
		if (userChoose > 3 || userChoose < 1)
		{
			Space(q); printf("!!| Опции не существует\n");
			Space(q); printf(">>| ");
		}
	} while (userChoose > 3 || userChoose < 1);
	Space(q); printf("  | -------------------------------- |\n\n");

	switch (userChoose)
	{
	case 1:
	{
		// Ввод с клавиатуры
		Space(q); printf(" ?| Введите количество процессов\n");
		Space(q); printf(">>| ");
		scanf_s("%d", &processCount);
		Space(q); printf(" ?| Введите время обработки процесса\n");
		indexProcess = (int*)malloc(sizeof(int) * processCount);
		meaningProcess = (int*)malloc(sizeof(int) * processCount);
		for (int index = 0; index < processCount; index++)
		{
			indexProcess[index] = index + 1;
			Space(q); printf(">>| №%d | ", index + 1);
			scanf_s("%d", &meaningProcess[index]);
		}
		break;
	}
	case 2:
	{
		// Чтение из файла
		Space(q); printf("  | Происходит открытие файла\n");
		Space(q); printf("  | . . . \n");
		FILE* file;
		if ((file = fopen("kvany.txt", "r")) == NULL)
		{
			Space(q); perror("!!| Произошла ошибка чтения файла!\n");
			exit(0);
		}
		Space(q); printf("  | Файл успешно открыт!\n");
		fscanf_s(file, "%d", &processCount);
		indexProcess = (int*)malloc(sizeof(int) * processCount);
		meaningProcess = (int*)malloc(sizeof(int) * processCount);
		for (int index = 0; index < processCount; index++)
		{
			fscanf_s(file, "%d %d", &indexProcess[index], &meaningProcess[index]);
		}
		fclose(file);
		break;
	}
	case 3:
	{
		//Рандомизация значений
		Space(q); printf(" ?| Введите количество процессов\n");
		Space(q); printf(">>| ");
		scanf_s("%d", &processCount);
		indexProcess = (int*)malloc(sizeof(int) * processCount);
		meaningProcess = (int*)malloc(sizeof(int) * processCount);
		for (int index = 0; index < processCount; index++)
		{
			indexProcess[index] = index + 1;
			meaningProcess[index] = rand() % 100 + 1;
		}
		break;
	}
	default:
		break;
	}
	
	//Создание массива с номерами процессов
	processNumber = (int*)malloc(sizeof(int) * processCount);
	int indexProcessNumber = 0;

	// Вывод значений на экран
	Space(q); printf("  | --------------------- |\n");
	Space(q); printf("  | Кол-во процессов: %d\n", processCount);
	Space(q); printf("  | --------------------- |\n");
	Space(q); printf("  | №  | Время процесса\n");
	Space(q); printf("  | ---+----------------- |\n");
	for (int i = 0; i < processCount; i++)
	{
		Space(q); printf("  | %-2d | %d\n", indexProcess[i], meaningProcess[i]);
	}
	Space(q); printf("  | ---+----------------- |\n");
	lineBreak;
	
	// Ввод изначального кванта времени
	Space(q); printf(" ?| Введите квант времени\n");
	Space(q); printf(">>|");
	scanf_s("%d", &timeKvant);
	sumTimeKvant += timeKvant;

	//Заголовок таблицы
	printf("|----+---------+-----------+----------+---------------+------------|\n");
	printf("| №  | Квант   | Суммарное | Номер    | Время выбран. | Оставшееся |\n");
	printf("|    | Времени | Время ЦП  | процесса | процесса      | время ЦП   |\n");
	printf("|----+---------+-----------+----------+---------------+------------|\n");
	int numberIteration = 1; //номер итерации
	int processCountDouble = processCount;
	
	//
	while (processCount > 0)
	{
		//Проверка, хватит ли данного кванта на выполнение
		//Выбор процесса, который пойдёт первый

		int maxElement = 0; //Тот самый процесс, который будет выполняться
		int indexMaxElement = -1; // Его порядковый номер в динам.списке, не в изначальном!
		
		// Выбор элемента
		for (int i = 0; i < processCount; i++)
		{
			if ((meaningProcess[i] > maxElement) && (meaningProcess[i] <= sumTimeKvant))
			{
				maxElement = meaningProcess[i];
				indexMaxElement = i;
			}
		}
		
		if (indexMaxElement == -1)
		{
			printf("|----+---------+-----------+----------+---------------+------------|\n");
			Space(q); printf(" ?| Введите квант времени\n");
			Space(q); printf(">>| ");
			scanf_s("%d", &timeKvant);
			sumTimeKvant += timeKvant;
			numberIteration += 1;
			printf("|----+---------+-----------+----------+---------------+------------|\n");
		}
		else
		{
			printf("| %-3d| %-8d| %-10d| %-9d| %-14d| %-11d|\n", numberIteration, timeKvant, sumTimeKvant, indexProcess[indexMaxElement], meaningProcess[indexMaxElement], sumTimeKvant - meaningProcess[indexMaxElement]);
			sumTimeKvant -= meaningProcess[indexMaxElement];
			processNumber[indexProcessNumber] = indexProcess[indexMaxElement];
			indexProcessNumber++;

			// Удаление из базы уже сделанного процесса
			for (int i = indexMaxElement; i < processCount; i++)
			{
				meaningProcess[i] = meaningProcess[i + 1];
				indexProcess[i] = indexProcess[i + 1];
			}
			processCount--;
		}
	}
	printf("|----+---------+-----------+----------+---------------+------------|\n");

	//Вывод ответа
	if (processCountDouble >= 21)
	{
		FILE* file;
		if ((file = fopen("answer.txt", "w")) == NULL)
		{
			Space(q); perror("!!| Произошла ошибка чтения файла!\n");
			exit(0);
		}
		Space(q); printf("  | Файл успешно создан!\n");
		
		for (int i = 0; i < processCountDouble; i++)
		{
			fprintf(file, "%d\n", processNumber[i]);
		}
	}
	else
	{
		Space(q); printf("  | Порядок выполнения:\n");
		Space(q); printf("  | ");
		for (int i = 0; i < processCountDouble; i++)
		{
			 printf("%d, ", processNumber[i]);
		}	
	}

	//Чистка динамической памяти
	free(meaningProcess);
	free(indexProcess);
	free(processNumber);
}
