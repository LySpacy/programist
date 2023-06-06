using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21
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
                    arr2[j, i] = arr[i, arr.GetLength(1)-1-j];
                }
            }

            return arr2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Controls.Clear();

            int n = Convert.ToInt32(numericUpDown1.Value);
            int m = Convert.ToInt32(numericUpDown2.Value);

            if (n < 1 || m < 1)
            {
                label5.Visible = true;
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = false;

                this.Width = 350 + m * 60;
                this.Height = 180 + n * 40;
                

                panel1.Height = n * 100;
                panel1.Width = m * 100;

                label4.Location = new Point(250 + m * 20, 30);

                int[,] arr = new int[n, m];
                int count = 1;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int number = 0; number < 4; number++)
                    {
                        for (int j = i; j < arr.GetLength(1); j++)
                        {
                            if (arr[i, j] > 0) continue;
                            if (j == i && number > 0) j++;
                            arr[i, j] = count;
                            count++;
                        }
                        arr = turn(arr);
                    }
                }

                Label[,] lb = new Label[n, m];
                
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        lb[i, j] = new System.Windows.Forms.Label();
                        lb[i, j].Location = new System.Drawing.Point(30 + j * 60, 15 + i * 40);
                        lb[i, j].Name = "label" + (i + 5).ToString();
                        lb[i, j].Size = new System.Drawing.Size(60, 40);
                        lb[i, j].Font = new Font("Microsoft Sans Serif", 14);
                        lb[i, j].TabIndex = i + 1;
                        lb[i, j].Text = arr[i, j].ToString();
                        panel1.Controls.Add(lb[i, j]);
                    }
                }
            }
        }
    }
}
