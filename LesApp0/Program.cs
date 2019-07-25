using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

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

            // проблем з перебором не виявилось,
            // але згідно теорії не рекомендується використовувати
            // методи де б був boxing and unboxing що суттєво уповільнює
            // роботу програми і вимагає багато ресурсів,
            // а при додаванны елементів висвітлюється, що ми додаємо
            // елемент як object, під чим розуміється упаковка і розпаковка

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
