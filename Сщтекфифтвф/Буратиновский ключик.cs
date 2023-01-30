using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Graphics g;
        // Карандаш для рисования линии соединения двух точек
        Pen penMouseDown = new Pen(Color.Gray, 7f);
        // Карандаш, стирающий предыдущую линию
        Pen penWhite = new Pen(Color.White, 7f);
        
        // Массив координах отмеченных курсором точек
        int[,] keyDot = new int[maxlines + 1, 2];
        //Массив координат пароля
        int[,] keyDotPassword = new int[maxlines + 1, 2];
        //Индекс текущего элемента
        int indexKeyDot = 0;

        //Количество соединительных линий
        static int maxlines = 5;

        // Корректно ли введен пароль
        bool isCorrectPassword = true;

        //Если ли текущий кругляш в нашем списке
        bool isInArray = false;

        int eSize = 50; //Размер квадрата сетки
        bool isMouseDown = false; //опущен ли курсор

        // Координаты точки, от которой строим новую линию соединения
        int indexX = 0;
        int indexY = 0;

        int cursorX = -1; // Кооржината курсора по х
        int cursorY = -1; // Координата курсора по у

        bool buttonIsDown = false; // Активирована ли кнопка записи нового кода
        public Form1()
        {
            InitializeComponent();
            panel1.Width = 350;
            panel1.Height = 350;

            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader stream = new StreamReader(openFile.FileName);
                for (int i = 0; i < maxlines+1; i++)
                {
                    keyDotPassword[i, 0] = Convert.ToInt32(stream.ReadLine());
                    keyDotPassword[i, 1] = Convert.ToInt32(stream.ReadLine());
                }
                stream.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = panel1.CreateGraphics();

            //Рисуем на панели точки 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    g.DrawEllipse(Pens.Black, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                    g.FillEllipse(Brushes.Blue, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            indexKeyDot = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (e.X < eSize * (2 * (i + 1)) &&
                        e.X > eSize * (2 * (i + 1) - 1) &&
                        e.Y < eSize * (2 * (j + 1)) &&
                        e.Y > eSize * (2 * (j + 1) - 1) &&
                        indexKeyDot < maxlines + 1)
                    {
                        //Курсор опущен
                        isMouseDown = true;

                        //Добавляем координаты кругляша в массив
                        if (buttonIsDown == false)
                        {
                            keyDot[indexKeyDot, 0] = i;
                            keyDot[indexKeyDot, 1] = j;
                        }
                        else
                        {
                            keyDotPassword[indexKeyDot, 0] = i;
                            keyDotPassword[indexKeyDot, 1] = j;
                        }
                                
                        indexKeyDot++;

                        //Обновляем координаты текущего кругляша
                        indexX = i;
                        indexY = j;

                        //Закрашиваем текущий кругляш серым
                        g.FillEllipse(Brushes.Gray, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);


                    }

                }

            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (indexKeyDot != maxlines + 1)
            {
                MessageBox.Show("Графический ключ должен состоять из " + maxlines + " соединительных линий");

                if (buttonIsDown == true)
                {
                    buttonIsDown = false;
                    button1.Enabled = true;
                    button1.Text = "Создать новый ключ";
                }
            }
            else
            {
                if (buttonIsDown == false)
                {
                    // Верен ли введенный пароль
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            if (keyDot[i, j] != keyDotPassword[i, j]) isCorrectPassword = false;
                        }
                    }
                    if (isCorrectPassword == false)
                    {
                        g.Clear(panel1.BackColor);
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                g.DrawEllipse(Pens.Black, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                                g.FillEllipse(Brushes.Red, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                            }
                        }
                        MessageBox.Show("Пароль неверный");
                    }

                    else
                    {
                        g.Clear(panel1.BackColor);
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                g.DrawEllipse(Pens.Black, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                                g.FillEllipse(Brushes.Green, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                            }
                        }
                        MessageBox.Show("Пароль верный");
                    }

                    isCorrectPassword = true;
                }
                else
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.DefaultExt = ".txt";
                    saveFileDialog.Filter = "Test files|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
                    {
                        StreamWriter stream = new StreamWriter(saveFileDialog.FileName, false);
                        for (int i = 0; i < maxlines+1; i++)
                        {
                            // Сохранение построчно
                            
                             stream.WriteLine(keyDotPassword[i, 0]);
                             stream.WriteLine(keyDotPassword[i, 1]);
                            
                        }
                        stream.Close();
                    }


                    MessageBox.Show("Пароль обновлён");
                    button1.Enabled = true;
                    button1.Text = "Создать новый ключ";
                    buttonIsDown = false;
                }
            }
            
            indexKeyDot = 0;
            // Чистим экран и рисуем кругляши заного
            g.Clear(panel1.BackColor);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    g.DrawEllipse(Pens.Black, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                    g.FillEllipse(Brushes.Blue, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);

                }
            }
            isMouseDown = false;
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //keyDot = Key(keyDot, indexKeyDot);
            
            if (isMouseDown == true)
            {
                g.DrawLine(penWhite, eSize * (2 * (indexX + 1) - 1) + (int)(eSize / 2), eSize * (2 * (indexY + 1) - 1) + (int)(eSize / 2), cursorX, cursorY);


                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        // Проверка: если ли текущий кругляш в нашем массиве.
                        isInArray = false;
                        if (e.X < eSize * (2 * (i + 1)) &&
                        e.X > eSize * (2 * (i + 1) - 1) &&
                        e.Y < eSize * (2 * (j + 1)) &&
                        e.Y > eSize * (2 * (j + 1) - 1))
                            for (int h = 0; h < indexKeyDot; h++)
                            {
                                if (buttonIsDown == false)
                                {
                                    if (keyDot[h, 0] == i && keyDot[h, 1] == j)
                                        isInArray = true;
                                }
                                else
                                {
                                    if (keyDotPassword[h, 0] == i && keyDotPassword[h, 1] == j)
                                        isInArray = true;
                                }
                                    
                            }


                        // Если курсор в одном из кругляшей и этого кругляша нет в массиве
                        if (e.X < eSize * (2 * (i + 1)) &&
                        e.X > eSize * (2 * (i + 1) - 1) &&
                        e.Y < eSize * (2 * (j + 1)) &&
                        e.Y > eSize * (2 * (j + 1) - 1) &&
                        indexKeyDot < maxlines + 1 &&
                        isInArray == false)
                        {
                            // Проверка: если ли текущий кругляш в нашем массиве. Если нет - добавляем
                            for (int h = 0; h < indexKeyDot; h++)
                            {
                                if (buttonIsDown == false)
                                {
                                    if (keyDot[h, 0] == i && keyDot[h, 1] == j)
                                        isInArray = true;
                                }
                                   
                                else
                                {
                                    if (keyDotPassword[h, 0] == i && keyDotPassword[h, 1] == j)
                                        isInArray = true;
                                }
                                    
                            }
                            if (isInArray == false)
                            {
                                if (buttonIsDown == false)
                                {
                                    keyDot[indexKeyDot, 0] = i;
                                    keyDot[indexKeyDot, 1] = j;
                                }
                                else
                                {
                                    keyDotPassword[indexKeyDot, 0] = i;
                                    keyDotPassword[indexKeyDot, 1] = j;
                                }
                                indexKeyDot++;

                            }

                            //Заполняем его серым
                            g.FillEllipse(Brushes.Gray, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);

                            //Рисуем линию от старого кругляша до нового
                            g.DrawLine(penMouseDown,
                                eSize * (2 * (indexX + 1) - 1) + (int)(eSize / 2),
                                eSize * (2 * (indexY + 1) - 1) + (int)(eSize / 2),
                                eSize * (2 * (i + 1) - 1) + (int)(eSize / 2),
                                eSize * (2 * (j + 1) - 1) + (int)(eSize / 2));

                            //Обновляем координаты
                            indexX = i;
                            indexY = j;
                        }
                        
                        // Закрашиваем все кругляши синим, дабы закрыть белые полосы
                        if (buttonIsDown == false)
                            g.FillEllipse(Brushes.Blue, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                        else
                            g.FillEllipse(Brushes.Magenta, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);

                    }
                }

                //Прорисовываем все выделенные кругляши и полосы

                for (int h = 0; h < indexKeyDot - 1; h++)
                {
                    if (buttonIsDown == false)
                    {
                        g.DrawLine(penMouseDown,
                        eSize * (2 * (keyDot[h, 0] + 1) - 1) + (int)(eSize / 2),
                        eSize * (2 * (keyDot[h, 1] + 1) - 1) + (int)(eSize / 2),
                        eSize * (2 * (keyDot[h + 1, 0] + 1) - 1) + (int)(eSize / 2),
                        eSize * (2 * (keyDot[h + 1, 1] + 1) - 1) + (int)(eSize / 2));

                        g.FillEllipse(Brushes.Gray, eSize * (2 * (keyDot[h, 0] + 1) - 1), eSize * (2 * (keyDot[h, 1] + 1) - 1), eSize, eSize);
                    }
                    else
                    {
                        g.DrawLine(Pens.Magenta,
                        eSize * (2 * (keyDotPassword[h, 0] + 1) - 1) + (int)(eSize / 2),
                        eSize * (2 * (keyDotPassword[h, 1] + 1) - 1) + (int)(eSize / 2),
                        eSize * (2 * (keyDotPassword[h + 1, 0] + 1) - 1) + (int)(eSize / 2),
                        eSize * (2 * (keyDotPassword[h + 1, 1] + 1) - 1) + (int)(eSize / 2));

                        g.FillEllipse(Brushes.Magenta, eSize * (2 * (keyDotPassword[h, 0] + 1) - 1), eSize * (2 * (keyDotPassword[h, 1] + 1) - 1), eSize, eSize);
                    }
                        
                }
                if (buttonIsDown == false)
                    g.FillEllipse(Brushes.Gray, eSize * (2 * (keyDot[indexKeyDot - 1, 0] + 1) - 1), eSize * (2 * (keyDot[indexKeyDot - 1, 1] + 1) - 1), eSize, eSize);
                else
                    g.FillEllipse(Brushes.Gray, eSize * (2 * (keyDotPassword[indexKeyDot - 1, 0] + 1) - 1), eSize * (2 * (keyDotPassword[indexKeyDot - 1, 1] + 1) - 1), eSize, eSize);


                //Рисуем новую линию, связанную с концом курсора
                cursorX = e.X;
                cursorY = e.Y;
                g.DrawLine(penMouseDown, eSize * (2 * (indexX + 1) - 1) + (int)(eSize / 2), eSize * (2 * (indexY + 1) - 1) + (int)(eSize / 2), cursorX, cursorY);

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonIsDown = true;
            button1.Enabled = false;
            button1.Text = "Идет ввод нового ключа";
            g.Clear(panel1.BackColor);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    g.DrawEllipse(Pens.Black, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);
                    g.FillEllipse(Brushes.Magenta, eSize * (2 * (i + 1) - 1), eSize * (2 * (j + 1) - 1), eSize, eSize);

                }
            }
        }
    }
}
