using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; // для bm.Save(sf.FileName, ImageFormat.Bmp);
using System.Linq;
using System.Reflection; // буферизация
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        class Cube // класс Кубика
        {
            public int x; //координаты квадрата от 0 до 10
            public int y;
            public Color color;
            public bool isDown = false;

            public Cube(int x, int y, Color color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
            }

            public void Down(int size, Graphics g)
            {
                y++;
            }
           
        }
        int countCube = 0; //количество кубиков

        List<Cube> cubes = new List<Cube>();
        Graphics g;
        int sizeCube = 35;
        Brush brush;
        bool cubeInPanel = false;
        bool cubeTouch = false;

        bool isStart = false;

        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty |
                BindingFlags.Instance |
                BindingFlags.NonPublic,
                null,
                panel1,
                new object[] { true });
        }



       // Bitmap bmp;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = 351;
            panel1.Height = 351;

           
            g = e.Graphics;
            // прорисовка всех квадратов
            for (int i = 0; i < cubes.Count; i++)
            {
                brush = new SolidBrush(cubes[i].color);
                g.FillRectangle(brush, cubes[i].x * sizeCube, cubes[i].y * sizeCube, sizeCube, sizeCube);
            }

            //разлиновка
            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(Pens.Black, 0, i * sizeCube, panel1.Width, i * sizeCube);
                g.DrawLine(Pens.Black, i * sizeCube, 0, i * sizeCube, panel1.Width);
            }

            // если кнопка Старт нажата
            if (isStart == true)
            {
                if (cubeInPanel == false) //Если на панели нет нового активного кубика, то выполняй
                {
                    brush = new SolidBrush(cubes[countCube].color);

                    g.FillRectangle(brush, cubes[countCube].x * sizeCube, cubes[countCube].y * sizeCube, sizeCube, sizeCube);
                    cubeInPanel = true;
                }
                else //Если на панели есть активный кубик
                {
                    for (int i = 0; i < countCube; i++)
                    {
                        if (cubes[i].y == (cubes[countCube].y + 1) && (cubes[i].x) == (cubes[countCube].x))
                            cubeTouch = true;
                    }

                    if ((cubes[countCube].y + 1) * sizeCube + 1 < panel1.Height && cubeTouch == false) //Если дна нема
                    {
                        g.FillRectangle(Brushes.White, cubes[countCube].x * sizeCube, cubes[countCube].y * sizeCube, sizeCube, sizeCube);
                        g.DrawRectangle(Pens.Black, cubes[countCube].x * sizeCube, cubes[countCube].y * sizeCube, sizeCube, sizeCube);
                        cubes[countCube].Down(sizeCube, g);
                        brush = new SolidBrush(cubes[countCube].color);
                        g.FillRectangle(brush, cubes[countCube].x * sizeCube, cubes[countCube].y * sizeCube, sizeCube, sizeCube);
                    }
                    else
                    {
                        Random r = new Random();
                        countCube++;
                        cubes.Add(new Cube(r.Next(0, 10), 0, Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))));
                        cubeInPanel = false;
                        cubeTouch = false;
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (isStart == true) //Если мы нажали кнопку Старт опять, то
            {
                //Чистим всё и перезапускаем панель
                timer1.Stop();
                isStart = false;
                cubeInPanel = false;
                cubeTouch = false;
                cubes.Clear();
                countCube = 0;
                panel1.Invalidate();
            }


            isStart = true;
            Random r = new Random();
            cubes.Add(new Cube(r.Next(0, 10), 0, Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))));
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate(); //чистит всю панель с*ка
        }

        //Сохраняем изображение
        private void btnSave_Click(object sender, EventArgs e)
        {

            timer1.Stop();

            saveFileDialog1.Filter = "PNG image|*.png|All files|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            Bitmap bmp = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height);
            panel1.DrawToBitmap(bmp, panel1.ClientRectangle);
            bmp.Save(filename, ImageFormat.Bmp);


            //Перезапускаем программу
            isStart = false;
            cubeInPanel = false;
            cubeTouch = false;
            cubes.Clear();
            countCube = 0;
            panel1.Invalidate();
        }  
    }
}
