using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Graphics graphics;
        Pen pen;

        bool isMouseDown = false; // Нажата ли клавиша мыши
        bool isDrawing = false;   // Нарисован ли рисунок
        
        int cursorX = -1; // Кооржината курсора по х
        int cursorY = -1; // Координата курсора по у
        List<Point> points = new List<Point>(); // Лист (Массив) точек рисунка
        int index = 1; // Индекс, по которому будет пробег.
        double speed = 200; //Скорость воспроизведения по умолчанию
        int maxspeed = 1000; //Максимальная скорость

        int time = 0; // Выводит время, отмеряемое таймером, на экран


        public Form2()
        {
            InitializeComponent();

            //Создаём элементы для рисования
            graphics = panel1.CreateGraphics();
            pen = new Pen(Color.Black, 3f);

            //Гладкость рисованной линии
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
            //Отключение кнопки "Воспроизвести
            btnStart.Enabled = false;

            //Указание текущей скорости в окне скорости
            txtSpeed.Text = "200";
        }

        //Событие нажатия ЛКМ
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //Если рисунок не нарисован, выполнять:
            if (!isDrawing)
            {
                isMouseDown = true; // Кнока нажата
                cursorX = e.X; // Передаем текущие координаты курсора
                cursorY = e.Y;
                points.Add(new Point(cursorX, cursorY)); // Добавляем точку в массив
            }
            
        }

        //Событие при отпускании ЛКМ
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            btnStart.Enabled = true; // Активируем кнопку "Воспроизвести"
            isMouseDown = false; // Мышь не нажата
            cursorX = -1; // Обнуляем координаты мыши
            cursorY = -1;
            isDrawing = true; //Говорим, что рисунок есть
        }

        //Событие движения курсора
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Если ЛКМ нажата и курсор внутри области рисования, выполняй
            if (cursorX != -1 && cursorY != -1 && isMouseDown == true)
            {
                // Рисуется линия, соединяющая предыдущую точку и текущую
                graphics.DrawLine(pen, new Point(cursorX, cursorY), e.Location);
                // Обновляем координаты курсора
                cursorX = e.X;
                cursorY = e.Y;
                points.Add(new Point(cursorX, cursorY)); //Добавляем точну в массив 
            }
        }

        //Событие нажатия на кнопку с цветом
        private void btnColor_Click(object sender, EventArgs e)
        {
            // Если цвет выбран, выполняй
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog1.Color; // Создаем переменную типа Color
                btnColor.BackColor = color; // Присваимем перу и кнопке этот цвет
                pen.Color = color;
            }
        }

        // Событие нажатия на кнопку "Воспроизвести"
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Отключаем кнопки "Воспроизвести" и поле изменения скорости
            btnStart.Enabled = false;
            txtSpeed.Enabled = false;

            //Чистим холст
            graphics.Clear(panel1.BackColor);

            //Задаем скорость таймеру
            timer.Interval = (int)speed;
            
            //Запускаем таймер
            timer.Start();
        }

        //Событие работы таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            // Если текущий индекс не равен последнему (Если рисунок ещё не нарисован полность), выполняй
            if (index + 1 != points.Count)
            {
                time++;
                lbltime.Text = time.ToString();

                // Рисуется линия, соединяющая две точки из массива
                graphics.DrawLine(pen, points[index - 1], points[index]);
                index++;
            }
            else //Иначе (если рисунок нарисован)
            {
                graphics.Clear(panel1.BackColor); // Чистится холст
                points.Clear(); //Чистится лист
                isDrawing = false; // Рисунка нет
                panel1.Enabled = true; // Активируем холст для пользователя
                txtSpeed.Enabled = true; //Активируем поле ввода скорости
                index = 1; //"обнуляем" индекс
                time = 0;
                lbltime.Text = time.ToString();
                timer.Stop(); //Останавливаем таймер
            }

        }

        //Событие изменения текста в поле ввода скорости
        private void txtSpeed_TextChanged(object sender, EventArgs e)
        {
            
            if (txtSpeed.Text != "")
            {
                for (int i = 0; i < txtSpeed.Text.Length; i++)
                {
                    if (!Char.IsDigit(txtSpeed.Text, i))
                    {
                        MessageBox.Show("Нельзя ввести символы, отличные от цифр", "Ошибка ввода", MessageBoxButtons.OK);
                        txtSpeed.Text = "200";
                    }
                }

                if (Convert.ToInt32(txtSpeed.Text) > maxspeed || Convert.ToInt32(txtSpeed.Text) <= 0)
                {
                    MessageBox.Show("Скорость должна быть в диапозоне от 1 до " + maxspeed, "Ошибка ввода", MessageBoxButtons.OK);
                    txtSpeed.Text = "200";
                }

                speed = maxspeed / Convert.ToDouble(txtSpeed.Text);
            }
            else
            {
                speed = maxspeed / 200;
            }

            
        }
    }
}
