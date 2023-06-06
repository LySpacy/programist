using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static long step(int[] arr)
        {
            long a = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                long d = arr[i];
                for (int s = i; s < arr.Length - 1; s++)
                    d *= 10;
                a += d;
            }
            return a;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox2.Visible = true;
            textBox2.Clear();

            long n;
            if (!long.TryParse(textBox1.Text, out n))
            {
                label2.Visible = true;
                return;
            }
            else
            {
                label2.Visible = false;
                n = Convert.ToInt64(textBox1.Text);
            }

            bool sign = true;
            if (n < 0) sign = false;

            n = Math.Abs(n);

            string line = Convert.ToString(n);

            int[] arr = new int[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                arr[i] = (int)Char.GetNumericValue(line[i]); ;
            }

            if (sign)
            {
                for (int i = 0; i < arr.Length-1; i++)
                {
                    for (int index = i + 1; index < arr.Length; index++)
                    {
                        if (arr[i] > arr[index])
                        {
                            int c = arr[index];
                            arr[index] = arr[i];
                            arr[i] = c;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int index = i + 1; index < arr.Length; index++)
                    {
                        if (arr[i] < arr[index])
                        {
                            int c = arr[index];
                            arr[index] = arr[i];
                            arr[i] = c;
                        }
                    }
                }
            }
             
            if (sign) textBox2.Text += " " + step(arr);
            else textBox2.Text += " -" + step(arr);
            
        }
    }
}
