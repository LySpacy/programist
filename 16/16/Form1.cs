using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            Random random = new Random();

            int[] arr = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                arr[i] = random.Next(1, 7);
            }

            int maxLong = 1;
            int start = arr[0];
            int end = 0;
            int obj = arr[0];

            for (int i = 0; i < 1000; i++)
            {
                int sLong = 0;
                int send = 0;
                int sstart = 0;
                if (i != 0) sstart = arr[i-1];
                for (int index = i + 1; index < 1000; index++)
                {
                    sLong++;
                    if (arr[index] != arr[i])
                    {
                        send = arr[index];
                        sLong--;
                        if (sLong > maxLong)
                        {
                            end = send;
                            start = start;
                            maxLong = sLong;
                            obj = arr[i];
                            i = index;
                        }
                        break;

                    }
                }
            }

            textBox1.Text += " " + obj;
            textBox2.Text += " " + maxLong;
            textBox3.Text += " " + start;
            textBox4.Text += " " + end;
        }
    }
}
