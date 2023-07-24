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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked )
            {
                Console.WriteLine(textBox1.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int timer = 125;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            int minute = timer / 60;
            int second = timer - minute * 60;
            label1.Text = minute.ToString()  + ":"+ second.ToString();
        }
    }
}
