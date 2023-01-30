using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Шарики
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            Speed.Text = "50";
            timer1.Interval = 50;
            CountTap.Text = ($"Количество нажатий: {CountTapInt}");
        }
        class Ball// класс шараl
        {
            public int x0;
            public int y0;
            public int Radius = 6;
            public Brush color = new SolidBrush(Color.White);
            public Ball(int X, int Y, Brush color)
            {
                this.x0 = X;
                this.y0 = Y;
                this.color = color;
            }

        }
        List<Ball> Balls = new List<Ball>();//список шаров
        int CountTapInt = 0;//Количество нажатий 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.White;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Random rnd = new Random();
            Brush brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(255)));
            g.FillEllipse(brush, e.X - 6, e.Y - 6, 12, 12);
            Balls.Add(new Ball(e.X, e.Y, brush));
            CountTapInt++;
            CountTap.Text = ($"Количество нажатий: {CountTapInt}");//Количество нажатий 
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Graphics g = panel1.CreateGraphics();
            for (int i = 0; i < Balls.Count; i++)//перебор всех шаров
            { 
                bool flag = true;//проверка, если true неободимо создавать новый шар, если false, то нет
                Balls[i].Radius++;//увеличиваю радиус
                //проверка на соприкосновение с границей panel
                if (Balls[i].x0 + Balls[i].Radius > panel1.Width || Balls[i].x0 - Balls[i].Radius < 0 || Balls[i].y0 + Balls[i].Radius > panel1.Height || Balls[i].y0 - Balls[i].Radius < 0)
                {
                    g.FillEllipse(Brushes.White, Balls[i].x0 - Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[i].Radius * 2, Balls[i].Radius * 2);
                    Balls.RemoveAt(i);
                    flag = false;
                }
                //если шар не коснулся границы panel, проверим на прикосновение к другим шарам
                else
                {
                    for (int j = 0; j < Balls.Count; j++)//перебираем каждый i шар с остальными 
                    {
                        if (i != j)
                        {
                            //проверка находится ли левый нижний угол в огибающем квадрате j куба
                            bool left_down = Oblost(Balls[i].x0 - Balls[i].Radius, Balls[i].y0 + Balls[i].Radius, Balls[j]);
                            //проверка правого нижнего
                            bool right_down = Oblost(Balls[i].x0 + Balls[i].Radius, Balls[i].y0 + Balls[i].Radius, Balls[j]);
                            //левого верхнего
                            bool left_up = Oblost(Balls[i].x0 - Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[j]);
                            // правого верхнего
                            bool right_up = Oblost(Balls[i].x0 + Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[j]);
                                       //if (Oblost(Balls[i].x0 - Balls[i].Radius, Balls[i].y0 + Balls[i].Radius, Balls[j]) || Oblost(Balls[i].x0 + Balls[i].Radius, Balls[i].y0 + Balls[i].Radius, Balls[j]) || Oblost(Balls[i].x0 - Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[j]) || Oblost(Balls[i].x0 + Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[j]))
                            //далее проверка, если хотя бы один угол находится вне огибающего квадрата, то значит они пересеклись. Может 
                            //быть ситуалция когда один шар находится в другом и тогда их огибащие квадрате не пересекутсься
                            if (left_down != right_down) flag = false;
                            if (left_down != right_up) flag = false;
                            if (left_down != left_up) flag = false;
                            if (right_down != left_up) flag = false;
                            if (right_down != right_down) flag = false;
                            if (left_up != right_up) flag = false;
                            //если шары пересеклись значит стераем их и убираем из массива
                            if (!flag)
                            {
                                g.FillEllipse(Brushes.White, Balls[j].x0 - Balls[j].Radius, Balls[j].y0 - Balls[j].Radius, Balls[j].Radius * 2, Balls[j].Radius * 2);
                                g.FillEllipse(Brushes.White, Balls[i].x0 - Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[i].Radius * 2, Balls[i].Radius * 2);
                                flag = false;
                                //т.к не наем какой из них идет раньше а какой позже, что бы не обращаться к несуществующему числу делаем проверку

                                if (i < j)
                                {
                                    Balls.RemoveAt(j);
                                    Balls.RemoveAt(i);
                                    break;
                                }
                                else
                                {
                                    Balls.RemoveAt(i);
                                    Balls.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                    }
                }
                if (flag)//если квадрат ничего не задел но рисуем его
                {
                    g.FillEllipse(Balls[i].color, Balls[i].x0 - Balls[i].Radius, Balls[i].y0 - Balls[i].Radius, Balls[i].Radius * 2, Balls[i].Radius * 2);
                }
            }
        }
        private bool Oblost(int x, int y, Ball ball)//проверка точкy на вхождение ее в описывающий квадрат другого круга 
        {
            if ((x < ball.x0 + ball.Radius && x > ball.x0 - ball.Radius) && (y < ball.y0 + ball.Radius && y > ball.y0 - ball.Radius))
                return true;
                      //if ((x == ball.x0 + ball.Radius || x == ball.x0 - ball.Radius) && (y < ball.y0 + ball.Radius && y > ball.y0 - ball.Radius))
                     //{
                    //    return true;
                   //}
                  //if ((y == ball.y0 + ball.Radius || y == ball.y0 - ball.Radius) && (x < ball.x0 + ball.Radius && x > ball.x0 - ball.Radius))
                 //{
                //    return true;
               //}
            return false;
        }
        private void Apply_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Speed.Text, out int speed))
            {
                if (int.Parse(Speed.Text) > 100 || int.Parse(Speed.Text) <= 0)
                {
                    MessageBox.Show("Максимальная скороть 100");
                }
                else { timer1.Interval =( 101 - int.Parse(Speed.Text)); }
            }
        }
    }
}