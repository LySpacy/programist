using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15
{
    public partial class Form1 : Form
    {

        int[] arr;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = false;
            textBox2.Visible = false;
            textBox2.Clear();
            button2.Visible = true;
            textBox1.Clear();
            Random rnd = new Random();
            arr = new int[20];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 4);
                textBox1.Text += arr[i] + "  ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            textBox2.Visible = true;
            textBox2.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int index = i + 1; index < arr.Length; index++)
                {
                    if (arr[i] == arr[index] && index != 1)
                    {
                        arr[index] = arr[index] * index;
                    }
                    else if (arr[i] == arr[index]) arr[i] = arr[i] * i;
                }
                textBox2.Text += arr[i] + "  ";
            }
        }
    }
}
