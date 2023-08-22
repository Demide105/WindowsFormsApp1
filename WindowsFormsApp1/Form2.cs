using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void загрузить_данные_ученика(Classученик ученик)
        {
            label1.Text = ученик.имя;
            string ii = "";
            bool двойка = false;
            bool пятёрка = false;
            foreach (int i in Class2.list.ученики[номер_ученика].оценка)
            {
                ii += i + ", ";
                if (i == 2)
                    двойка = true;
                if (i == 5)
                    пятёрка = true;
            }
            label3.Text = двойка ? "Есть двойка!" : "Нету двойки!";
            label2.Text = ii;
            label4.Text = пятёрка ? "есть пятёрка" : "НЕТУ ПЯТЁРКИ!";
            загрузить_данные_соседа(ученик.сосед());
        }
        private void загрузить_данные_соседа(Classученик ученик)
        {
            if (ученик.Valid)
            {
                label5.Text = ученик.имя;
                string ii = "";
                bool двойка = false;
                bool пятёрка = false;
                foreach (int i in Class2.list.ученики[номер_ученика].оценка)
                {
                    ii += i + ", ";
                    if (i == 2)
                        двойка = true;
                    if (i == 5)
                        пятёрка = true;
                }
                label7.Text = двойка ? "Есть двойка!" : "Нету двойки!";
                label6.Text = ii;
                label8.Text = пятёрка ? "есть пятёрка" : "НЕТУ ПЯТЁРКИ!";

            }
            else
            {
                label5.Text = "НЕТ СОСЕДА";
                label7.Text = "НЕТ СОСЕДА";
                label6.Text = "НЕТ СОСЕДА";
                label8.Text = "НЕТ СОСЕДА";
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            загрузить_данные_ученика(Class2.list.ученики[0]);
        }
        int номер_ученика = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            номер_ученика = номер_ученика + 1;
            if (номер_ученика == Class2.list.ученики.Count)
            {
                номер_ученика = 0;
            }
            загрузить_данные_ученика(Class2.list.ученики[номер_ученика]);
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            номер_ученика = номер_ученика - 1;
            if(номер_ученика == -1)
            {
                номер_ученика = Class2.list.ученики.Count-1;
            }
            загрузить_данные_ученика(Class2.list.ученики[номер_ученика]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Class2.list.ученики[номер_ученика].имя = textBox1.Text;
            загрузить_данные_ученика(Class2.list.ученики[номер_ученика]);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int одна_оценка = int.Parse(textBox2.Text);
                if (одна_оценка > 5 || одна_оценка < 1)
                {
                    throw new ArgumentException(message: "Ты чо дурачок или куда?");
                }
                Class2.list.ученики[номер_ученика].оценка.Add(int.Parse(textBox2.Text));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRor " + ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Class2.list.парты.Count; i++)
            {
                if (Class2.list.парты[i].ученик1 == Class2.list.ученики[номер_ученика] ||
                    Class2.list.парты[i].ученик2 == Class2.list.ученики[номер_ученика])
                    textBox3.Text = i.ToString();
            }
        }
    }
}
