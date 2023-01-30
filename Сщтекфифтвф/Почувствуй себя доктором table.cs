using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Таблица
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Содание шапки
            Table1.Columns.Add("Name", "Имя");
            Table1.Columns.Add("Height", "Рост");
            Table1.Columns.Add("Weight", "Вес");
            Table1.Columns.Add("Group", "Группа крови");
        }
        bool flag = false;//отслеживает была ли нажата кнопка дважды. На второе нажатие останавливает таймер 
        private void StartEnter_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                timer1.Start();
                flag = true;
            }
            else
            {
                timer1.Stop();
                flag= false;
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            string[] Name = { "Иван", "Василий", "Джордж","Полина"};
            string[] GroupBload = { "A", "B", "AB" };
            //Закидываем рандомные значения 
            Table1.Rows.Add(Name[random.Next(0, 4)], random.Next(160, 200), random.Next(60, 120), GroupBload[random.Next(0, 3)]);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            using (System.IO.StreamWriter Popka = new System.IO.StreamWriter("Cake.txt", false))//открываем файл для записи
            {               
                for(int str=0;str<Table1.Rows.Count-1;str++)//Сичтываем кол-во строк-1, тк последняя пустая
                {
                    for(int col=0;col<Table1.Columns.Count;col++)//перебираем столбцы
                    {
                        Popka.Write(Table1[col, str].Value);//записываем в файл слово,НО не переходим на другую строку
                        if(col!=Table1.Columns.Count-1)
                        {
                            Popka.Write(";");//Если записываемый элемент, не группа корови, то после него ставим ;
                        }
                            
                    }
                    Popka.WriteLine();//переходим на следующую строку
                }

            }

        }

        private void Loaging_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog()==DialogResult.OK)//Вызываем окно выбора файла, если нажали ОК то продолжаем
            {
                Table1.Rows.Clear();//очищаем строки
                string []str = File.ReadAllLines(openFile.FileName);//Записываем в массив строк строки из файла, в скобках указывается имя файла
                for(int i = 0; i < str.Length;i++)//пробигаем по всем считынным строкам
                {
                    //буферы в которые мы будем помещать значения Имен, Роста, Веса и группы крови для рассматриваемой строки
                    List<char> BufName = new List<char>();
                    List<char> BufHeight = new List<char>();
                    List<char> BufWight = new List<char>();
                    List<char> BufGroup = new List<char>();
                    int pole = 0;//Характеризуем какой элемент мы считываем посимвольно 
                    for( int c=0; c < str[i].Length;c++)
                    {
                        char sim=str[i][c];
                        if (sim != ';')
                        {
                            if (pole == 0)
                                BufName.Add(sim);//Помещаем в бурферы
                            if (pole == 1)
                                BufHeight.Add(sim);
                            if (pole == 2)
                                BufWight.Add(sim);
                            if (pole == 3)
                                BufGroup.Add(sim);
                        }
                        else pole++;//Если вдруг попался символ ; то начит переходим к считыванию следующего элемента
                    }
                    //Buf.ToArray() возвращает массив типа char, с помощью String.Concat(...) вы склеиваем массив char в одну строку
                    Table1.Rows.Add(String.Concat(BufName.ToArray()),String.Concat(BufHeight.ToArray()),String.Concat(BufWight.ToArray()),String.Concat( BufGroup.ToArray()));
                }

            }
            
        }
    }
}
