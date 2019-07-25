using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Ствонення автопарку з першим авто
            CarCollection<Car> autopark = new CarCollection<Car>
                ("Mercedes-Benz GLS-Клас", 2015);

            // додавання авто
            // http://cyclowiki.org/wiki/Автомобили_серии_фильмов_«Форсаж»
            autopark.Add(new Car("Dodge Challenger SRT-8", 2008));
            autopark.Add("Mercedes-Benz Gelandewagen", 1979);

            // набір авто
            {
                Car car = new Car("Plymouth Road Runner", 1968);
                autopark.Add(car);
            }

            Car[] cars = new Car[]
            {
                new Car("Mercedes AMG GT", 2014),
                new Car("Bentley Continental GT", 2003),
                new Car("Lamborgini Murcielago", 2001),
                new Car("Chevrolet Chevy Fleetline Deluxe", 1941)
            };

            // додавання масиву авто
            autopark.AddRange(cars);
            // для тестування величини колекції і зміни її ємності
            //autopark.AddRange(cars);

            // вивід інформації
            Console.WriteLine("\n\tВсі наявні авто в автопарку:\n");
            for (int i = 0; i < autopark.Count; i++)
            {
                Console.WriteLine("\t" + autopark[i].ToString());
            }

            autopark.ShowInfo();

            // очищення автопарку
            autopark.Clear();

            Console.WriteLine("\n\tПісля очищення автопарку");
            autopark.ShowInfo();

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
