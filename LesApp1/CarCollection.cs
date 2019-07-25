using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    /// <summary>
    /// Колекція авто
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class CarCollection<T>
        where T : Car, new()   // фільтр - перевірка чи додаються тільки авто а не інший транспорт
    {
        /// <summary>
        /// парк авто
        /// </summary>
        private T[] cars;
        /// <summary>
        /// Кількість авто в автопарку
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність автопарку
        /// </summary>
        public int Capacity { get { return cars.Length; } }

        /// <summary>
        /// Доступ до авто
        /// </summary>
        /// <param name="index">індекс доступу до авто</param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return cars[index];
                }
                else
                {
                    Error();
                    return default;
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    cars[index] = value;
                }
                else
                {
                    Error();
                }
            }
        }

        /// <summary>
        /// Створюємо автопарк із 4-ма пустими місцями
        /// </summary>
        public CarCollection()
        {
            Clear();
        }

        /// <summary>
        /// Можливість створити автопарк і зразу додати перше авто
        /// </summary>
        /// <param name="name">Назва авто</param>
        /// <param name="year">Рік випуску</param>
        public CarCollection(string name, int year)
        {
            // створення автопарку
            Clear();
            // додавання першого авто
            Add(name, year);
        }

        /// <summary>
        /// Зміна розміру автопарку
        /// </summary>
        /// <param name="newSize"></param>
        private void Resize(int newSize)
        {
            // створення нового масиву
            T[] temp = new T[newSize];
            // копіювання елементів
            for (int i = 0; i < Count; i++)
            {
                temp[i] = cars[i];
            }
            // змінна ссилки на новий масив
            cars = temp;
        }

        /// <summary>
        /// Додавання масиву авто
        /// </summary>
        /// <param name="enterCars">масив авто</param>
        public void AddRange(params T[] enterCars)
        {
            // перевірка чи не пусті вхідні параметри
            if (enterCars.Length < 1)
            {
                return;
            }

            #region вибір розміру масиву
            // в даному випадку для керування об'ємом масиву необхідно
            // розв'язати рівняння: capacity = 2^n > count
            // 2^n > count
            // log_2(2^n) > log_2(count)
            // n > log_2(count)
            // n = ln(count) / ln(2)
            // а так як передається певна кількість елементів length,
            // які необхідно доадти в масив, то рівняння прийме вигляд
            // n = ln(count + length) / ln(2)
            // якщо count + length == capacity то в такому випадку степінь n,
            // буде цілим числом і ємність залишиться такою як і була і неможливо додати
            // нові об'єкти, а тому необхідно додати 1
            // якщо ж count + length > capacity, то ми отримаємо дійсне n
            // округливши його в напрямку + безкінечності функцією ceiling
            // ми отримаємо ціле число n, яке вмыщатиме всі нові об'єкти
            #endregion

            // розрахунок степіня двійки, який визначатиме ємність автопарку
            int power = (int)Math.Ceiling(
                Math.Log(Count + enterCars.Length) / Math.Log(2));

            // перевірка чи кількість наявних авто і тих які прибувають
            // не рівна ємності автопарку, якщо так то знаядений степінь вкаже
            // на навну ємність автопарку і її необхідно збільшити в 2 рази додавши 1 до спеня
            // якщо більше то степінь зразу покаже необхідну ємність
            if (Count + enterCars.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, power));
            }

            // додавання нових авто
            for (int i = 0; i < enterCars.Length; i++)
            {
                cars[Count++] = enterCars[i];
            }
        }

        /// <summary>
        /// Додавання одного авто
        /// </summary>
        public void Add(T car)
        {
            AddRange(car);
        }
        /// <summary>
        /// Додавання авто
        /// </summary>
        /// <param name="name">Назва авто</param>
        /// <param name="year">Рік  випуску</param>
        public void Add(string name, int year)
        {
            Add(new T()
            {
                Name = name,
                Year = year
            });
        }

        /// <summary>
        /// Помилка, вихід за межі масиву
        /// </summary>
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tСпроба виходу за межі колекції/масиву.");
            Console.ResetColor();
        }

        /// <summary>
        /// Видалення всіх авто в автопарку,
        /// та створення нового на 4 місця
        /// </summary>
        public void Clear()
        {
            cars = new T[4];
            Count = 0;
        }

        /// <summary>
        /// Виведення інформації про колекцію
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"\n\tКількість елемнтів в колекції: {Count}");
            Console.WriteLine($"\tЄмність колекції: {Capacity}");
            Console.WriteLine($"\tТип даних: {typeof(T).Name}");
        }

    }
}
