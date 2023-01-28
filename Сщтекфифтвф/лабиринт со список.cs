using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Елернинг
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form1 f;
        int one = 50;
        Point smeh;
        Point start;
        int randX;
        int randY;
        int[,] Matrix = new int[10, 10];

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = 501;
            panel1.Height = 501;
        }

        private void up_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Вверх");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Влево");
        }

        private void Gener_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);

            int sirina = panel1.Width;
            int visota = panel1.Height;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Matrix[i, j] = 0;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                randX = random.Next(10);
                randY = random.Next(10);
                Matrix[randX, randY] = 1;
                g.FillRectangle(Brushes.Silver, randX * one, randY * one, one, one);
            }
            for (int i = 0; i <= 10; i++)
            {
                g.DrawLine(Pens.Black, 0, i * one, panel1.Width, i * one);
                g.DrawLine(Pens.Black, i * one, 0, i * one, panel1.Width);
            }
            do
            {
                randX = random.Next(10);
                randY = random.Next(10);
                if(Matrix[randX, randY] == 0)
                g.FillEllipse(Brushes.Red, one * randX  , one * randY, 50, 50);
                start = new Point(randX,randY);
            } while (Matrix[randX, randY] == 1);
            int k = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void right_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Вправо");
        }

        private void Down_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Вниз");
        }

        private void Srartt_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                Graphics g = panel1.CreateGraphics();
                if (listBox1.Items[0] == "Вверх")
                {
                    if (start.Y != 0)
                    {
                        smeh = new Point(0, -50);
                        g.FillEllipse(Brushes.White, start.X * one, start.Y * one, 50, 50);
                        g.FillEllipse(Brushes.Red, start.X * one, (start.Y - 1) * one, one, one);
                        start.Y = start.Y - 1;
                    }
                }
                if (listBox1.Items[0] == "Вниз")
                {
                    if (start.Y != 9)
                    {
                        smeh = new Point(0, 50);
                        g.FillEllipse(Brushes.White, start.X * one, start.Y * one, 50, 50);
                        g.FillEllipse(Brushes.Red, start.X * one, (start.Y + 1) * one, one, one);
                        start.Y = start.Y + 1;
                    }
                }
                if (listBox1.Items[0] == "Вправо")
                {
                    if (start.X != 9)
                    {
                        smeh = new Point(50, 0);
                        g.FillEllipse(Brushes.White, start.X * one, start.Y * one, 50, 50);
                        g.FillEllipse(Brushes.Red, (start.X + 1) * one, start.Y * one, one, one);
                        start.X = start.X + 1;
                    }
                }
                if (listBox1.Items[0] == "Влево")
                {
                    if (start.Y != 0)
                    {
                        smeh = new Point(-50, 0);
                        g.FillEllipse(Brushes.White, start.X * one, start.Y * one, 50, 50);
                        g.FillEllipse(Brushes.Red, (start.X - 1) * one, start.Y * one, one, one);
                        start.X = start.X - 1;
                    }
                }
                listBox1.Items.RemoveAt(0);
                if (Matrix[start.X, start.Y] == 1)
                {
                    timer1.Stop();
                    listBox1.Items.Clear();
                    MessageBox.Show("Game over");
                }
            }
            else timer1.Stop();
        }
    }
}
