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
        Random random;
        public static DateTime time = DateTime.UtcNow;
        List<int> придумать_случайные_оценки(int inu = 6)
        {
            List<int> ints = new List<int> { };
            for (int i = 0; i < inu; i++)
            {
                ints.Add(random.Next(1, 6));
            }
            return ints;
        }
        float просчёт_среднего_балла(List<int> массив_оценок)
        {
            float b = 0;
            for (int i = 0; i < массив_оценок.Count; i++)
            {
                b = b + массив_оценок[i];
            }
            return (float)b / (float)массив_оценок.Count;
        } 
        List<string> массив_имён_учеников = new List<string> { "Алик", "Александр", "Айнур", "Агата", "Артемий", "Аид", "Устин", "Урсула", "Умар", "Шерлок", "Шелли" };

        string предумать_случайное_имя()
        {
            return массив_имён_учеников[random.Next(0, массив_имён_учеников.Count)];
        }
        DateTime предумать_случайную_дату_рождения()
        {
            int Year = random.Next(2010, 2012);
            int Month = random.Next(1, 12);
            int Day = random.Next(1, 28);
            DateTime datarogdenia = new DateTime(Year, Month, Day);
            return datarogdenia;
        }
        int придумать_случайный_рост()
        {
            return random.Next(90, 250);
        }
        Classученик придумать_ученика()
        {
            Classученик list = new Classученик(предумать_случайное_имя(), придумать_случайные_оценки(), придумать_случайный_рост(), предумать_случайную_дату_рождения());
            return list;
        }
        List<Classученик> придумать_учеников(int сколько_учеников)
        {
            List<Classученик> list1 = new List<Classученик> { };
            for (int i = 0; i < сколько_учеников; i++)
                list1.Add(придумать_ученика());
            return list1;
        }
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            Class2.list = new Classкабинет(придумать_учеников(10));
            Class2.list.рассадить_учеников();
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
            int hour = minute / 60;
            int minute1 = minute - hour * 60;
            int second = timer - minute * 60;
            label1.Text = hour.ToString() + ":" + minute1.ToString()  + ":"+ second.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void минута1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer = timer + 60;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer = 0;
        }

        private async Task VivodYchenika()
        {
            Task awaiter = Task.Run(Class2.list.ученики[0].р);
            for (int i = 1; i < Class2.list.ученики.Count; i++)
            {
                awaiter = Task.Run(Class2.list.ученики[i].р);
            }
            await awaiter;
        }
        private async void button4_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            Task.Run(VivodYchenika);
            DateTime date1 = DateTime.Now;
            TimeSpan время_выполнения_программы  = date1 - date;
            Console.WriteLine(время_выполнения_программы.TotalMilliseconds);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Class2.list.ученики.Add(new Classученик(textBox2.Text, придумать_случайные_оценки(), trackBar1.Value, предумать_случайную_дату_рождения()));
            Class2.list.рассадить_учеников();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Удалить ученика");
                Class2.list.ученики.RemoveAt(int.Parse(textBox3.Text));
                Class2.list.рассадить_учеников();
            }
            catch (Exception ex)
            {
              Console.WriteLine("ERROR" + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Измените имя ученика");
                int k = int.Parse(textBox3.Text);
                if (textBox3.Text == "")
                {
                    new ArgumentException(message: "Ты чо дурачок или куда?");
                }
                if (k >= Class2.list.ученики.Count || k < 0) { }
                else
                    Class2.list.ученики[k].имя = textBox2.Text;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRor " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int m = 0;
            for (int i = 0; i < Class2.list.ученики.Count; i++)
            {
                bool Отличник = true;
                for (int j = 0; j < Class2.list.ученики[i].оценка.Count; j++)
                {
                    if (Class2.list.ученики[i].оценка[j] != 5)
                    {
                        Отличник = false;
                    }
                }
                if (Отличник)
                {
                    m = m + 1;
                }
            }
            float r = ((float)m / (float)Class2.list.ученики.Count) * 100f;
            Console.WriteLine(r);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int m = 0;
            for (int i = 0; i < Class2.list.ученики.Count; i++)
            {
                m = m + Class2.list.ученики[i].рост;
            }
            int c = m / Class2.list.ученики.Count;
            Console.WriteLine(c);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int количествоучеников = 0;
            int c = 0;
            for (int q = 90; q <= 300; q = q + 10)
            {
                int h = 0;
                for (int i = 0; i < Class2.list.ученики.Count; i++)
                {
                    if ((Class2.list.ученики[i].рост / 10) * 10 == q)
                    {
                        h = h + 1;
                    }
                }
                if (количествоучеников < h)
                {
                    количествоучеников = h;
                    c = q;
                }
            }
            float r = ((float)количествоучеников / (float)Class2.list.ученики.Count) * 100f;
            Console.WriteLine(r);
            Console.WriteLine(c);
            Console.WriteLine(количествоучеников);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Class2.list.ученики.Count; i++)
            {
                Console.WriteLine(Class2.list.ученики[i].имя);
                for (int o = 0; o < Class2.list.ученики[i].оценка.Count; o++)
                {
                    Console.WriteLine(Class2.list.ученики[i].оценка[o]);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int q = 0; q < Class2.list.ученики.Count; q++)
            {
                Console.WriteLine(Class2.list.ученики[q].имя);
                Console.WriteLine(просчёт_среднего_балла(Class2.list.ученики[q].оценка));
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < Class2.list.парты.Count; i++)
            {
                Console.WriteLine("парта номер " + i);
                Console.WriteLine(Class2.list.парты[i].ученик1?.имя);
                if (Class2.list.парты[i].ученик2.Valid)
                {
                    Console.WriteLine(Class2.list.парты[i].ученик2?.имя);
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    new ArgumentException(message: "Ты чо дурачок или куда?");
                }
                Class2.list.доска.написать_на_доске(textBox1.Text);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERRor " + ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Class2.list.доска.посмотреть_на_доску());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Class2.list.доска.очистить_доску();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Class2.list.парты.Count; i++)
            {
                Console.WriteLine("номер парты " + i);
                if (Class2.list.парты[i].ученик1.Valid)
                    Class2.list.парты[i].ученик1.р();
                if (Class2.list.парты[i].ученик2.Valid)
                    Class2.list.парты[i].ученик2.р();
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            List<int> массив_всех_оценок = new List<int> { };
            for (int i = 0; i < Class2.list.ученики.Count; i++)
            {
                массив_всех_оценок.AddRange(Class2.list.ученики[i].оценка);
            }
            Console.WriteLine(просчёт_среднего_балла(массив_всех_оценок));
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    new ArgumentException(message: "Ты чо дурачок или куда?");
                }
                for (int i = 0; i < Class2.list.ученики.Count; i++)
                {
                    Class2.list.ученики[i].имя = textBox1.Text;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRor " + ex.Message);
            }
            
        }

        private void button20_Click(object sender, EventArgs e)
        {

            try
            {

                if (textBox1.Text == "")
                {
                    new ArgumentException(message: "Ты чо дурачок или куда?");
                }
                Task.Run(() =>
                {
                    int ochenka = int.Parse(textBox1.Text);
                    if (ochenka >= 1 && ochenka <= 5)
                    {
                        for (int k = 0; k < Class2.list.ученики.Count; k++)
                        {
                            Class2.list.ученики[k].оценка.Add(ochenka);
                        }

                    }
                    Console.WriteLine("Сгущёнка намазана");
                });
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRor " + ex.Message);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            label2.Text = (DateTime.UtcNow - time).ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Task.Run(() => {
                for (int i = 0; i < 1000000; i++)
                {
                    Class2.list.ученики.Add(new Classученик(предумать_случайное_имя(), придумать_случайные_оценки(), придумать_случайный_рост(), предумать_случайную_дату_рождения()));
                }
                Class2.list.рассадить_учеников();
                Console.WriteLine("Милион горячих пирожжков уже на готове!");
            });

            
        }
    }
}
