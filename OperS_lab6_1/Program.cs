using OperS_lab6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace OperS_lab6_1
{
     class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр формы из DLL
            MyForm form = new MyForm();

            // Отображаем форму
            form.Show();

            // Запускаем основной цикл приложения
            Application.Run();
            MyFunctions.MyFunction(); // Вызываем функцию из DLL
            // Создаем новый домен приложения
            AppDomain domain = AppDomain.CreateDomain("MyDomain");

            try
            {
                // Загружаем сборку в новый домен
                Assembly myLibrary = domain.Load(AssemblyName.GetAssemblyName(@"C:\Users\Admin\source\repos\OperS_lab6\OperS_lab6\obj\Debug\OperS_lab6.dll"));

                // Получаем тип класса из DLL
                Type myFunctionsType = myLibrary.GetType("MyLibrary.MyFunctions");

                // Получаем метод из типа
                MethodInfo myFunctionMethod = myFunctionsType.GetMethod("MyFunction");

                // Создаем экземпляр объекта
                object myFunctionsInstance = Activator.CreateInstance(myFunctionsType);

                // Вызываем функцию
                myFunctionMethod.Invoke(myFunctionsInstance, null);
            }
            finally
            {
                // Выгружаем домен приложения
                AppDomain.Unload(domain);
            }
        }
    }
}
