using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SystemCodingWinWorm
{
    public partial class Form1 : Form
    {
        public Random rand = new Random();
        public int counter = 0;
        public int NotepadWindowID = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NativeMethods.MsgBox(System.IntPtr.Zero, $"{this.textBox1.Text}", "WinAPI output ", 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int PC_random = rand.Next(0, 100);

            if (Convert.ToInt16(this.textBox2.Text) == PC_random)
            {
                this.textBox2.Text = "";
                this.label5.Text = "";
                NativeMethods.MsgBox(System.IntPtr.Zero, $"Угадал! Ваше число: {PC_random}", "WinAPI output ", 0);
            }
            else
            {
                var tmp = NativeMethods.MsgBox(System.IntPtr.Zero, $"{PC_random}\nПК не угадал, продолжить поиск?", "WinAPI output ", 1);
                if (tmp == 1)
                {
                    ++counter;
                    this.label5.Text = counter.ToString();
                    button2_Click(sender, e);
                }
                else
                {
                    this.textBox2.Text = "";
                    this.label5.Text = "";
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.label5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int tmp = NativeMethods.FindWindow("Notepad", null);
            if (tmp > 0)
            {
                this.timer1.Start();
                this.label2.Text = "Блокнот найден!";
                this.NotepadWindowID = NativeMethods.FindWindow("Notepad", null);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NativeMethods.SendMessage(this.NotepadWindowID, NativeMethods.WM_SETTEXT, 0, Convert.ToString(DateTime.Now));
            if(NativeMethods.FindWindow("Notepad", null) == 0)
            {
                this.timer1.Stop();
                this.label2.Text = "Блокнот не найден!";
                this.NotepadWindowID = 0;
            }
        }

        /*private void thr(string name)
        {
            NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, name));
        }*/
    }
}
