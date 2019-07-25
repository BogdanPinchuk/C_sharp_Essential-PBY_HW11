using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // тестування роботи словника на тому, що
            // якщо буде випадок, що ключ заданий типом int
            // і є два індекатори з доступом по ключу і доступом по індексу
            // який же індексатор обереться

            // створюємо словник
            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            // скористаємося послідовністю Фібоначчі, на якій базується золотий перетин
            // https://uk.wikipedia.org/wiki/Послідовність_Фібоначчі
            // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
            int[] fibonachi = new int[] 
            {
                0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
            };

            var dayOfWeek = Enum.GetValues(typeof(DayOfWeek))
                .Cast<DayOfWeek>().ToArray();

            // заповнення масива даними
            for (int i = 0; i < dayOfWeek.Length; i++)
            {
                dictionary.Add(fibonachi[i], dayOfWeek[i].ToString());
            }

            // Результат словника
            Console.WriteLine("\n\tДані словника:\n");
            Console.WriteLine(dictionary.ToString());

            // тестування
            Console.WriteLine("\n\tСпроба звернутися за індексом: 4");
            Console.WriteLine($"\tkey: {4}, value: {dictionary[4]};\n");

            Console.WriteLine("\tСпроба звернутися за індексом: 8");
            Console.WriteLine($"\tkey: {8}, value: {dictionary[8]};\n");

            Console.WriteLine(new string('#', 80));

            // Висновок. Якщо в словника ключ типу int,
            // то домінує індесатор з доступом по індексу, а не по ключу

            // тестування методу на вбудованому словнику

            System.Collections.Generic.Dictionary<int, string> pairs = 
                new System.Collections.Generic.Dictionary<int, string>();

            // заповнення масива даними
            Console.WriteLine("\n\tДані вбудованого словника:\n");

            for (int i = 2; i < dayOfWeek.Length + 2; i++)
            {
                pairs.Add(fibonachi[i], dayOfWeek[i - 2].ToString());
                Console.WriteLine($"\tkey: {fibonachi[i]}, value: {dayOfWeek[i - 2].ToString()};");
            }

            // тестування
#if false
            Console.WriteLine("\n\tСпроба звернутися за індексом: 4");
            Console.WriteLine($"\tkey: {4}, value: {pairs[4]};\n"); 
#endif

            // у вбудованому словнику доступ відбувається
            // лише по ключу, а доступ по індексу: pairs.ElementAt(4);

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

