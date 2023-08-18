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
    }
}
