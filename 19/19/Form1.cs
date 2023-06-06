using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
            listBox1.Visible = true;
            listBox1.Items.Clear();

            int n = 0;
            int m = 0;
            bool status = int.TryParse(textBox1.Text, out n);
            if (status == false) label5.Visible = true;
            status = int.TryParse(textBox2.Text, out m);
            if (status == false) label5.Visible = true;
            if (n != m || n == 0 || m == 0 )
            {
                label5.Visible = true;
                status = false;
            }

            listBox1.Height = n * 40;
            listBox1.Width = m * 50;
            Random rnd = new Random();

            if (status == true)
            {
                int[,] arr = new int[n, m];
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (i != j && j != n-1 - i && i != n-1 - j)
                        {
                            arr[i, j] = rnd.Next(0, 6);
                        }
                        else if (i == j)
                        {
                            arr[i, j] = i;
                        }
                        else  arr[i, j] = j;
                    }
                }
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    string line = "";
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        line += arr[i, j].ToString() + "  ";
                    }
                    listBox1.Items.Add(line);
                }


            }
        }
    }
}
