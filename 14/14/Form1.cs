using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Calculate(string years, string mounth, string day)
        {
            int m = 0;
            switch (mounth)
            {
                case "Январь": m = 1; break;
                case "Февраль": m = 2;  break;
                case "Март": m = 3; break;
                case "Апрель": m = 4; break;
                case "Май": m = 5; break;
                case "Июнь": m = 6; break;
                case "Июль": m = 7; break;
                case "Август": m = 8; break;
                case "Сентябрь": m = 9; break;
                case "Октябрь": m = 10; break;
                case "Ноябрь": m = 11; break;
                case "Декабрь": m = 12; break;
            }
            int a = (14 - m) / 12;
            int Y = Convert.ToInt32(years) - a;
            int M = m + 12 * a - 2;
            int N = (7000 + Convert.ToInt32(day) + Y + (Y / 4) - (Y / 100) + (Y / 400) + ((31 * M) / 12)) % 7;
            switch (N)
            {
                case 0: label5.Text = "Воскресенье"; break;
                case 1: label5.Text = "Понедельник"; break;
                case 2: label5.Text = "Вторник"; break;
                case 3: label5.Text = "Среда"; break;
                case 4: label5.Text = "Четверг"; break;
                case 5: label5.Text = "Пятница"; break;
                case 6: label5.Text = "Суббота"; break;
            }
        }
        static void reprit28(ComboBox cb)
        {
            cb.Text = "";
            cb.Items.Clear();
            for (int i = 1; i < 29; i++)
            {
                cb.Items.Add(i.ToString());
            }
        }
        static void reprit29(ComboBox cb)
        {
            cb.Text = "";
            cb.Items.Clear();
            for (int i = 1; i < 30; i++)
            {
                cb.Items.Add(i.ToString());
            }
        }

        static void reprit30(ComboBox cb)
        {
            cb.Text = "";
            cb.Items.Clear();
            for (int i = 1; i < 31; i++)
            {
                cb.Items.Add(i.ToString());
            }
        }
     
        static bool checkYears(string a)
        {
            int years = Convert.ToInt32(a);

            if (a == null) years = 0;
                if ((years % 4 == 0 && years % 100 != 0) || years % 400 == 0) return true;
            else return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            for (int i = 1583; i < 3201; i++)
            {
                comboBox3.Items.Add(i);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {

                case "Январь": break;
                case "Март": break;
                case "Май": break;
                case "Июль": break;
                case "Август": break;
                case "Октябрь": break;
                case "Декабрь": break;
                case "Апрель":
                case "Июнь":
                case "Сентябь":
                case "Ноябрь": reprit30(comboBox1); break;
                case "Февраль":
                    if (comboBox3.Text != String.Empty)
                    if (checkYears(comboBox3.Text))
                    {
                        reprit29(comboBox1);
                    }
                    else
                    {   
                        reprit28(comboBox1);
                    }
                    break;

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {

                case "Январь": break;
                case "Март": break;
                case "Май": break;
                case "Июль": break;
                case "Август": break;
                case "Октябрь": break;
                case "Декабрь": break;
                case "Апрель":
                case "Июнь":
                case "Сентябь":
                case "Ноябрь": reprit30(comboBox1); break;
                case "Февраль":
                    if (checkYears(comboBox3.Text))
                    {
                        reprit29(comboBox1);
                    }
                    else
                    {
                        reprit28(comboBox1);
                    }
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label5.Visible = true;
            if (comboBox1.Text == String.Empty || comboBox2.Text == String.Empty || comboBox3.Text == String.Empty)
            {
                label5.Text = "Выберите дату";
                label5.ForeColor = Color.Red;
            }
            else Calculate(comboBox3.Text, comboBox2.Text, comboBox1.Text);
        }
    }
}
