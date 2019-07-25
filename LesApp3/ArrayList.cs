using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    /// <summary>
    /// Простіше наближення реазілації базового ArrayList
    /// </summary>
    class ArrayList
    {
        /// <summary>
        /// масив елементів
        /// </summary>
        private object[] array = new object[4];
        /// <summary>
        /// Кількість елементів
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Ємність масиву
        /// </summary>
        public int Capacity { get { return array.Length; } }

        /// <summary>
        /// Доступ до авто
        /// </summary>
        /// <param name="index">індекс доступу до авто</param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return array[index];
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
                    array[index] = value;
                }
                else
                {
                    Error();
                }
            }
        }

        /// <summary>
        /// Зміна розміру
        /// </summary>
        /// <param name="newSize"></param>
        private void Resize(int newSize)
        {
            // створення нового масиву
            object[] temp = new object[newSize];
            // копіювання елементів
            for (int i = 0; i < Count; i++)
            {
                temp[i] = array[i];
            }
            // змінна ссилки на новий масив
            array = temp;
        }

        /// <summary>
        /// Додавання масиву
        /// </summary>
        /// <param name="values">масив</param>
        public void AddRange(params object[] values)
        {
            // перевірка чи не пусті вхідні параметри
            if (values.Length < 1)
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
                Math.Log(Count + values.Length) / Math.Log(2));

            if (Count + values.Length >= Capacity)
            {
                Resize((int)Math.Pow(2, power));
            }

            // додавання нових авто
            for (int i = 0; i < values.Length; i++)
            {
                array[Count++] = values[i];
            }
        }

        /// <summary>
        /// Додавання одного авто
        /// </summary>
        public void Add(object value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Видалення всіх елементів
        /// </summary>
        public void Clear()
        {
            array = new object[4];
            Count = 0;
        }

        /// <summary>
        /// Пошук індекса елемента по значенню
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (value.Equals(array[i]))
                {
                    return i;
                }
            }

            // помилка, такий елемент не знайдено
            return -1;
        }

        /// <summary>
        /// Видалення елемента по певному індексу
        /// </summary>
        /// <param name="index">індекс</param>
        public void RemoveAt(int index)
        {
            // якщо  іде звернення поза діапазоном
            if (!(0 <= index && index < Count))
            {
                Error();
                return;
            }

            // видаляємо елемнт простим зміщенням вліво
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            // Зменшуємо лічильник кількості елемнтів
            Count--;

            // для економії пам'яті перевіряємо величину  масиву
            if (Count == Capacity / 2)
            {
                Resize(Capacity / 2);
            }
        }
        
        /// <summary>
        /// Видалення тільки першого елемента по вказаному значенню
        /// </summary>
        /// <param name="value">елемент</param>
        /// <returns>результат успішності видалення елемента</returns>
        public bool Remove(object value)
        {
            // знаходимо індекс першого елемента масиву з відповідним значенням
            int index = IndexOf(value);
            // перевірка чи найдений елемент
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
