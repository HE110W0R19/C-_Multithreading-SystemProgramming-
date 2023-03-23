using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class WithoutLock
    {
        public static int counter = 0;
        static void PlusPlus_Method()
        {
            Thread[] PP_Threads = new Thread[50];
            Task[] PP_Tasks = new Task[50];
            for (int i = 0; i < 49; i++)
            {
                PP_Threads[i] = new Thread(new ThreadStart(() =>
                {
                    ++counter;
                    Console.WriteLine($"Thread ID: {PP_Threads[i]?.GetHashCode()}\t\t value: {counter}\n");
                }));
                PP_Threads[i].Start();
                PP_Tasks[i] = Task.Run(() =>
                {
                    ++counter;
                    Console.WriteLine($"Task ID: {PP_Tasks[i]?.Id}\t\t value: {counter}\n");
                });
            }
        }
        static void MinusMinus_Method()
        {
            Thread[] MM_Threads = new Thread[50];
            Task[] MM_Tasks = new Task[50];
            for (int i = 0; i < 49; i++)
            {
                MM_Threads[i] = new Thread(new ThreadStart(() => 
                { 
                    --counter;
                    Console.WriteLine($"Thread ID: {MM_Threads[i]?.GetHashCode()}\t\t value: {counter}\n"); 
                }));
                MM_Threads[i].Start();
                MM_Tasks[i] = Task.Run(()=> 
                {
                    --counter;
                    Console.WriteLine($"Task ID: {MM_Tasks[i]?.Id}\t\t value: {counter}\n");
                });
            }
        }
        static void Main(string[] args)
        {
            Parallel.Invoke(PlusPlus_Method, MinusMinus_Method);
            Console.ReadKey();
        }
    }
}
