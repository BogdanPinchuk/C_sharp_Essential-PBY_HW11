using System;
using System.Text;

namespace LesApp2
{
    /// <summary>
    /// Словник
    /// </summary>
    /// <typeparam name="TKey">Ключ</typeparam>
    /// <typeparam name="TValue">Значення</typeparam>
    class Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Масив ключів
        /// </summary>
        private TKey[] keys = new TKey[4];
        /// <summary>
        /// Масив значень
        /// </summary>
        private TValue[] values = new TValue[4];

        /// <summary>
        /// Кількість елементів в словнику
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Ємність словника
        /// </summary>
        public int Capacity { get { return keys.Length; } }

        /// <summary>
        /// Пошук індекса елемента по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int IndexOf(TKey key)
        {
            for (int i = 0; i < Count; i++)
            {
                if (key.Equals(keys[i]))
                {
                    return i;
                }
            }

            // помилка, такий елемент не знайдено
            return -1;
        }

        /// <summary>
        /// Доступ до елемнтів по індексу
        /// </summary>
        /// <param name="index">індекс</param>
        /// <returns></returns>
        public TValue this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return values[index];
                }
                else
                {
                    Error("Спроба виходу за межі колекції/масиву.");
                    return default;
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    values[index] =  value;
                }
                else
                {
                    Error("Спроба виходу за межі колекції/масиву.");
                }
            }
        }
        /// <summary>
        /// Доступ до елемнтів по ключу
        /// </summary>
        /// <param name="key">ключ</param>
        /// <returns></returns>
        public TValue this[TKey key]
        {
            get
            {
                // знаходження індекса елемента
                int index = IndexOf(key);
                // виведення сповіщення
                if (index != -1)
                {
                    return values[index];
                }
                else
                {
                    // якщо нічого не знайдено
                    Error("Вказаний ключ відсутній.");
                    return default;
                }
            }
            set
            {
                // знаходження індекса елемента
                int index = IndexOf(key);
                // виведення сповіщення
                if (index != -1)
                {
                    values[index] = value;
                }
                else
                {
                    // якщо нічого не знайдено
                    Error("Вказаний ключ відсутній.");
                }
            }
        }

        /// <summary>
        /// Помилка, вихід за межі масиву
        /// </summary>
        private void Error(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t" + s);
            Console.ResetColor();
        }

        /// <summary>
        /// Виведення інформації про колекцію
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"\n\tКількість елемнтів в колекції: {Count}");
            Console.WriteLine($"\tЄмність колекції: {Capacity}");
            Console.WriteLine($"\tТип даних ключа: {typeof(TKey).Name}");
            Console.WriteLine($"\tТип даних значення: {typeof(TValue).Name}");
        }

        /// <summary>
        /// Зміна розміну масивів
        /// </summary>
        /// <param name="newSize"></param>
        private void Resize(int newSize)
        {
            // створюємо нові масиви
            TKey[] keys = new TKey[newSize];
            TValue[] values = new TValue[newSize];
            // копіюємо значення
            for (int i = 0; i < Count; i++)
            {
                keys[i] = this.keys[i];
                values[i] = this.values[i];
            }
            // змінюємо ссилки
            this.keys = keys;
            this.values = values;
        }

        /// <summary>
        /// Додавання елемнтів в словник
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значення</param>
        public void Add(TKey key, TValue value)
        {
            // спочатку необхідно перевірити ключ на унікальність
            int index = IndexOf(key);

            // якщо такий ключ вже є то виходимо
            if (index != -1)
            {
                Error("Даний ключ не є унікальним.");
                return;
            }

            // перевірка жопустимої ємності масиву
            if (Count == Capacity)
            {
                Resize(Capacity * 2);
            }
            // додаємо елемент
            keys[Count] = key;
            values[Count++] = value;
        }
        /// <summary>
        /// Очищення даних
        /// </summary>
        public void Clear()
        {
            // задання нових масивів
            keys = new TKey[4];
            values = new TValue[4];
            // вказуємо, що елемнти відсутні
            Count = 0;
        }

        /// <summary>
        /// Вивід даних словника
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                s.Append($"\tkey: {keys[i]}, value: {values[i]};\n");
            }

            return s.ToString();
        }

    }
}
