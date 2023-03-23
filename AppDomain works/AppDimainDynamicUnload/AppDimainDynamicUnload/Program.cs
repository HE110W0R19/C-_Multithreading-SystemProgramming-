using System;
using System.Reflection;

namespace AppDimainDynamicUnload
{
    class Program
    {
        static void Main(string[] args)
        {
            //vvv Создаем наш домен
            AppDomain domainTest = AppDomain.CreateDomain("MyFirstDomain");

            //vvv Загружаем в него .dll из "Sample Library"
            Assembly asmTest = domainTest.Load(AssemblyName.GetAssemblyName("SampleLibrary.dll"));

            //vvv Зоздаем модуль для вызова
            Module moduleTest = asmTest.GetModule("SampleLibrary.dll");
            
            //vvv Получаем тип нужных методов
            Type typeTest = moduleTest.GetType("SampleLibrary.SampleClass");
            
            //vvv Получает сам метод из типа
            MethodInfo methodTest = typeTest.GetMethod("DoSome");
            
            //vvv Вызываем метод
            methodTest.Invoke(null, null);

            //vvv Тот же вызов, но через анон объекты и в одну строку
            asmTest.GetModule("SampleLibrary.dll")
                .GetType("SampleLibrary.SampleClass")
                .GetMethod("DoSome")
                .Invoke(null, null);

            //vvv После вызовов отгружаем наш домен
            AppDomain.Unload(domainTest);
            Console.ReadKey();
        }
    }
}
