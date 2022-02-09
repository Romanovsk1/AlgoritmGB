using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace program1
{
    internal class Program
    {
        // Выводит на экран сообщение и ждет нажатия любой клавиши

        private static void MessageWaitKey(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите номер задания из первого проэкта:");
            Console.WriteLine("1. Напишите на C# функцию согласно блок-схеме");
            Console.WriteLine("2. Посчитайте сложность функции");
            Console.WriteLine("3. Реализуйте функцию вычисления числа Фибоначчи ");
            
            
            int number = Convert.ToInt32(Console.ReadLine());


            if(number == 1)
            {
                System.Diagnostics.Process.Start(@"C:\Users\roman\OneDrive\Рабочий стол\Algoritms\DZ1\DZ1.1\DZ1.1\bin\Debug\DZ1.1.exe");
            }

            if (number == 2)
            {
                System.Diagnostics.Process.Start(@"C:\Users\roman\OneDrive\Рабочий стол\Algoritms\DZ1\DZ1.2\DZ1.2\bin\Debug\DZ1.2.exe");
            }

            if(number == 3)
            {
                System.Diagnostics.Process.Start(@"C:\Users\roman\OneDrive\Рабочий стол\Algoritms\DZ1\DZ1.3\DZ1.3\bin\Debug\DZ1.3.exe
");
            }

            else
            {
                Console.WriteLine("Такого номера задания нету!");
            }

            // Выводит на экран сообщение и ждет нажатия любой клавиши
            MessageWaitKey("");
        }
    }

}
