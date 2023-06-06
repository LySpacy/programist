using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TextBox[,] tb;
        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;

            bool check = int.TryParse(textBox1.Text, out n);
            if (!check) label2.Visible = true;
            else
            {
                button2.Visible = true;
                button3.Visible = true;
                panel1.Visible = true;
                button4.Visible = true;
                panel1.Controls.Clear();

                panel1.Height = n * 100;
                panel1.Width = n * 100;

                    tb = new TextBox[n, n];

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        tb[i, j] = new System.Windows.Forms.TextBox();
                        tb[i, j].Location = new System.Drawing.Point(30 + j * 60, 140 + i * 28);
                        tb[i, j].Name = "textBox" + (i + 1).ToString();
                        tb[i, j].Size = new System.Drawing.Size(60, 40);
                        tb[i, j].Font = new Font("Microsoft Sans Serif", 14);
                        tb[i, j].TabIndex = i + 1;
                        panel1.Controls.Add(tb[i, j]);
                    }
                }
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            List<int> list = new List<int>();
            for (int i = 1; i < tb.GetLength(0) * tb.GetLength(0) + 1; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    int randomIndex = rnd.Next(list.Count);
                    tb[i, j].Text = list[randomIndex].ToString();
                    list.Remove(list[randomIndex]);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(1); j++)
                {                  
                    tb[i, j].Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label3.Text = "";

            bool status = true;
            int[,] arr = new int[tb.GetLength(0), tb.GetLength(0)];
            for (int i = 0; i < tb.GetLength(0); i++)
            {
                for (int j = 0; j < tb.GetLength(1); j++)
                {
                    status = int.TryParse(tb[i, j].Text, out arr[i, j]);
                    if (!status)
                    {
                        label2.Visible = true;
                    }
                }
            }
            if (status)
            {
                bool checkLine = true;
                bool checkColums = true;
                int M = arr.GetLength(0) * (arr.GetLength(0) * arr.GetLength(0) + 1) / 2;

                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        sum += arr[i, j]; 
                    }
                    if (sum != M)
                    {
                        checkLine = false;
                        break;
                    }                          
                }
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    int sum = 0;
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        sum += arr[j, i];
                    }
                    if (sum != M)
                    {
                        checkColums = false;
                        break;
                    }
                }
                if (checkLine && checkColums) 
                { 
                    label3.Text = "Квадарт магический";
                    label3.ForeColor = Color.Purple;
                }
                else if (checkColums || checkLine)
                {
                    label3.Text = "Квадарт полумагический";
                    label3.ForeColor = Color.Green;
                }
                else
                {
                    label3.Text = "Квадарт не магический";
                    label3.ForeColor = Color.Red;
                }
            }
        }

            }
}
