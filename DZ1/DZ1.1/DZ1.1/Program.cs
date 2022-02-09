using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1._1
{
    internal class Program1
    {


        //Минимальное число для ввода
        private static readonly int min_number = 2;
        //Максимальное
        private static readonly int max_number = int.MaxValue;

        static void Main(string[] args)
        {
            
            int number = NumberInput("Введите целое положительное число: ", min_number, max_number, false);

            Console.WriteLine("Число {0}{1} простое", number, PrimeNumberCheck(number) ? string.Empty : " Не");


            MessageWaitKey(string.Empty);

        }


        //Проверка числа на простое
        private static bool PrimeNumberCheck(int number)
        {
            int d = 0;
            int i = 2;
            while (i < number)
            {
                if(number % i == 0) d++;
                i++;
            }

            return (d == number);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="massage"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="isOneDigit"></param>
        /// <returns></returns>

        private static int NumberInput(string massage, int min, int max, bool isOneDigit = true)
        {
            bool isInputCorrect = false;
            int input = 0;
            Console.WriteLine($"{massage} (от {min} до {max})");
            while (!isInputCorrect)
            {
                if (isOneDigit)
                    isInputCorrect = int.TryParse(Console.ReadKey().KeyChar.ToString(), out input);
                else
                    isInputCorrect = int.TryParse(Console.ReadLine(), out input);
                if(isInputCorrect && (input < min || input > max))
                    isInputCorrect = false;

                if (!isInputCorrect)
                    if (isOneDigit)
                        try
                        {
                            Console.CursorLeft--;//Возвращение курсора назад если неверно вели
                        }
                        catch
                        {

                        }
                    else
                        Console.WriteLine("Ошибка,введите заново!");

            }
            return input;


        }

        /// <summary>
        /// Выводит на экран сообщение и ждет нажатия любой клавиши
        /// </summary>
        /// <param name="message"></param>

        private static void MessageWaitKey(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Нажмите любую кнопку");
            Console.ReadKey();
        }



    }
}
