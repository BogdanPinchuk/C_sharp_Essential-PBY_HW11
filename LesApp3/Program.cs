using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Взято із 1-го завдання
            // створення колекції
            ArrayList arrayList = new ArrayList();

            // довання елементів струкрутного типу
            arrayList.Add(new Random().Next());
            arrayList.Add(DateTime.Now);

            // додавання елментів ссилочного типу
            arrayList.Add(Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>().ToArray()[new Random().Next(0, 7)]);
            arrayList.Add("Bogdan");
            arrayList.Add((object)27);

            // вивід результату
            Console.WriteLine("Тестування Arraylist:\n");

            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }
            #endregion

            // видалення елемента по значенню
            arrayList.Remove(27);
            // видалення елемента по ындексу
            arrayList.RemoveAt(new Random().Next(0, arrayList.Count));

            // вивід результату
            Console.WriteLine("\nРезультат Arraylist після видалення:\n");

            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.WriteLine(arrayList[i]);
            }

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
