using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) // Кнопка "Метод центральных прямоугольников" 
        {
            double a, b, N;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            N = Convert.ToDouble(textBox3.Text);//Присвоение значений из textBox'ов соответствующим переменным
            textBox4.Text = NewtonLeibniz(a, b).ToString("n7");//Подсчет точного значения интеграла
            textBox5.Text = CentralRectangleMethod(a, b, N).ToString("n7");//Подсчет значения методом парабол
            textBox6.Text = Math.Abs( NewtonLeibniz(a, b) - CentralRectangleMethod(a, b, N) ).ToString("n7");//Абсолютная погрешность
        }
       
        private void button2_Click(object sender, EventArgs e) //Кнопка "Метод параболы"
        {
            double a, b, N;
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            N = Convert.ToDouble(textBox3.Text);//Присвоение значений из textBox'ов соответствующим переменным
            textBox7.Text = NewtonLeibniz(a, b).ToString("n7"); //Подсчет точного значения интеграла
            textBox8.Text = ParabolaMethod(a, b, N).ToString("n7");//Подсчет значения методом парабол
            textBox9.Text = Math.Abs(NewtonLeibniz(a, b) - ParabolaMethod(a, b, N)).ToString("n7");//Абсолютная погрешность
        }
        public static double CentralRectangleMethod(double a, double b, double N)//Функция подсчета значения методлом Центр. Прямоуг.
        {
            double x, h, sum=0;
            h = (b - a) / N; //определение шага
            for (int i = 1; i <= N; i++) 
            {
                x = a + i * h - h / 2;
                sum += Integrand(x);
            }
            return h * sum;
        }
        public static double ParabolaMethod(double a, double b, double N)//Функция подсчета значения методом парабол
        {
            double sum, p = 1, x;
            double h = (b - a) / N;
            sum = Integrand(a) + Integrand(b);
            for(int i = 1; i <= N - 1; i++)
            { 
                x = a + i * h;
                sum += Integrand(x) * (3 + p);
                p = -p;
            }
            return sum * h / 3.0;
        }
        public static double Integrand(double x) // Подынтегральное выражение
        {
            return 2 * Math.Pow(x, 3) + 4 * Math.Sin(x);
        }
        public static double Antiderivative_Function(double x) //Первообразная функция
        {
            return Math.Pow(x, 4) / 2 - 4 * Math.Cos(x);
        }
        public static double NewtonLeibniz(double a, double b) // Метод Ньютона-Лейбница для вычисления точного значения интеграла
        {
            return Antiderivative_Function(b) - Antiderivative_Function(a);
        }   
    }
}
