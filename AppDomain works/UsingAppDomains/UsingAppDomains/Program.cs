using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace UsingAppDomains
{
    static class Program
    {
        static AppDomain Drawer;
        static AppDomain TextWindow;
        static Assembly DrawerAsm;
        static Assembly TextWindowAsm;
        static Form DrawerWindow;
        static Form TextWindowWnd;

        [STAThread]
        [LoaderOptimization(LoaderOptimization.MultiDomain)]

        static void Main()
        {
            Application.EnableVisualStyles();

            Drawer = AppDomain.CreateDomain("Drawer");

            TextWindow = AppDomain.CreateDomain("TextWindow");

            DrawerAsm = Drawer.Load(AssemblyName.GetAssemblyName("TextDrawer.exe"));

            TextWindowAsm = Drawer.Load(AssemblyName.GetAssemblyName("TextWindow.exe"));

            DrawerWindow = Activator.CreateInstance(DrawerAsm.GetType("TextDrawer.Form1")) as Form;

            TextWindowWnd = Activator.CreateInstance(TextWindowAsm.GetType("TextWindow.Form1"),
             new object[]
             {DrawerAsm.GetModule("TextDrawer.exe"),DrawerWindow}) as Form;

            (new Thread(new ThreadStart(RunVisualizer))).Start();
            (new Thread(new ThreadStart(RunDrawer))).Start();

            Drawer.DomainUnload += new EventHandler(Drawer_DomainUnload);
        }
        static void Drawer_DomainUnload(object sender, EventArgs e)
        {
            /*открываем MessageBox, в котором выводим имя 
             *текущего домена приложения*/
            MessageBox.Show("Domain with name " + (sender as AppDomain).FriendlyName + " has been succesfully unloaded!");
        }
        static void RunDrawer()
        {
            /*запускаем окно модально в текущем потоке*/
            DrawerWindow.ShowDialog();
            /*отгружаем домен приложения*/
            AppDomain.Unload(Drawer);
        }
        static void RunVisualizer()
        {
            /*запускаем окно модально в текущем потоке*/
            TextWindowWnd.ShowDialog();
            /*завершаем работу приложения, следствием чего 
             *станет закрытие потока*/
            Application.Exit();
        }

    }
}
