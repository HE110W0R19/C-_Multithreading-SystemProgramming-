using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntiVirusTask
{
    public partial class Form1 : Form
    {
        public static bool IsStarted = false;

        public string filePath = Path.GetFullPath("Virus_Hard.exe");

        public List<string> WindowNames = new List<string> {"Form1", "DefenderForm0", "DefenderForm1",
                "DefenderForm2", "DefenderForm3", "DefenderForm4" };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void CloseDelete_Windows()
        {
            await Task.Run((() =>
            {
                while (IsStarted != false)
                {
                    Parallel.Invoke(
                     () => { NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, WindowNames[0])); },
                     () => { NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, WindowNames[1])); },
                     () => { NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, WindowNames[2])); },
                     () => { NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, WindowNames[3])); },
                     () => { NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, WindowNames[4])); },
                     () => { NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, WindowNames[5])); });
                    Thread.Sleep(100);
                }

                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch (Exception)
                    {
                        label1.Text = "Error of delete";
                    }
                }
            }));
        }

        private void StartStop_Checker()
        {
            var Checker = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (NativeMethods.FindWindow(null, WindowNames[0]) == 0 &
                    NativeMethods.FindWindow(null, WindowNames[1]) == 0 &
                    NativeMethods.FindWindow(null, WindowNames[2]) == 0 &
                    NativeMethods.FindWindow(null, WindowNames[3]) == 0 &
                    NativeMethods.FindWindow(null, WindowNames[4]) == 0 &
                    NativeMethods.FindWindow(null, WindowNames[5]) == 0)
                    {
                        IsStarted = false;
                        button3.BackColor = System.Drawing.Color.Red;
                        button1.BackColor = System.Drawing.Color.WhiteSmoke;
                        break;
                    }
                }
            }));
            Checker.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsStarted = true;
            button1.Enabled = false;
            button3.Enabled = true;

            button1.BackColor = System.Drawing.Color.Green;
            button3.BackColor = System.Drawing.Color.WhiteSmoke;

            CloseDelete_Windows();
            StartStop_Checker();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            IsStarted = false;
            button3.Enabled = false;
            button1.Enabled = true;

            button3.BackColor = System.Drawing.Color.Red;
            button1.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var win_names = new List<string> {"Form1", "DefenderForm0", "DefenderForm1",
                "DefenderForm2", "DefenderForm3", "DefenderForm4" };
            foreach (var tmp in win_names)
            {
                NativeMethods.SendQuitMessage(NativeMethods.FindWindow(null, tmp));
            }
        }
    }
}
