using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _22
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int[,] turn(int[,] arr)
        {
            int[,] arr2 = new int[arr.GetLength(1), arr.GetLength(0)];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr2[j, i] = arr[i, arr.GetLength(1) - 1 - j];
                }
            }

            return arr2;
        }

        static bool checkMatrix(int[,] arr)
        {
            bool status = true;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1) - i; j++)
                {
                    if (arr[i,j] != arr[arr.GetLength(0)-1-j, arr.GetLength(1)-1-i]) status = false;
                    if (status == false) break;
                }
                if (status == false) break;
            }
            return status;
        }

        TextBox[,] tb;
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            comboBox1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            label6.Visible = false;

            panel1.Controls.Clear();
           
            int n = Convert.ToInt32(numericUpDown1.Value);

            if (n < 1)
            {
                label3.Visible = true;

                this.Width = 320;
                this.Height = 225;

            }
            else
            {
                panel1.Height = n * 100;
                panel1.Width = n * 100;

                label4.Visible = true;
                comboBox1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;

                this.Width = 1000;
                this.Height = 500;

                tb = new TextBox[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        tb[i, j] = new System.Windows.Forms.TextBox();
                        tb[i, j].Location = new System.Drawing.Point(20 + j * 60, 20 + i * 28);
                        tb[i, j].Name = "textBox" + (i + 1).ToString();
                        tb[i, j].Size = new System.Drawing.Size(60, 40);
                        tb[i, j].Font = new Font("Microsoft Sans Serif", 14);
                        tb[i, j].TabIndex = i + 1;
                        panel1.Controls.Add(tb[i, j]);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            label6.Visible = false;
            Random random = new Random();
            for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(0); j++)
                {
                    tb[i, j].Text = random.Next(-10, 11).ToString();                   
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label5.Visible = true;

            int[,] arr = new int[tb.GetLength(0), tb.GetLength(0)];
            bool check = true;
            for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(0); j++)
                {
                    if (int.TryParse(tb[i, j].Text, out arr[i, j]) && tb[i, j].Text != String.Empty) { }
                    else check = false;
                }
            }

            if (check)
            {
                for (int i = 0; i < tb.GetLength(0); i++)
                {
                    for (int j = 0; j < tb.GetLength(0); j++)
                    {
                        if (tb[i, j].Text == String.Empty) { }
                    }
                }

                if (comboBox1.Text == String.Empty)
                {
                    label6.Visible = true;
                    label6.Text = "Выберите диагональ, для проверки";
                    label6.ForeColor = Color.Red;
                }
                else if (comboBox1.Text == "Главная")
                {
                    arr = turn(arr);
                    if (checkMatrix(arr))
                    {
                        label5.Text = "Матрица \nсимметрична относительно \nглавной диагонали";
                        label5.ForeColor = Color.Green;
                    }
                    else
                    {
                        label5.Text = "Матрица \nне симметрична относительно \nглавной диагонали";
                        label5.ForeColor = Color.Purple;
                    }
                }
                else
                {
                    if (checkMatrix(arr))
                    {
                        label5.Text = "Матрица \nсимметрична относительно \nвспомогательной диагонали";
                        label5.ForeColor = Color.Green;
                    }
                    else
                    {
                        label5.Text = "Матрица \nне симметрична относительно \nвспомогательной диагонали";
                        label5.ForeColor = Color.Purple;
                    }
                }
            }
            else label6.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (comboBox1.Text == "Главная")
            {
                for (int i = 0; i < tb.GetLength(0); i++)
                {
                    for (int j = 0; j < tb.GetLength(0); j++)
                    {
                        if (i == j) tb[i,j].BackColor = Color.Green;
                        if ((i == tb.GetLength(0) - 1 - j || j == tb.GetLength(0) - 1 - i) && i != j) tb[i, j].BackColor = Color.White;
                    }
                }
            }
            else
            {
                for (int i = 0; i < tb.GetLength(0); i++)
                {
                    for (int j = 0; j < tb.GetLength(0); j++)
                    {
                        if (i == tb.GetLength(0)-1-j || j == tb.GetLength(0) - 1 - i) tb[i, j].BackColor = Color.Green;
                        if (i == j && i != tb.GetLength(0) - 1 - j || j != tb.GetLength(0) - 1 - i) tb[i, j].BackColor = Color.White;
                    }
                }
            }
        }
    }
}
