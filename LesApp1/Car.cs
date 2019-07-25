namespace LesApp1
{
    /// <summary>
    /// Авто
    /// </summary>
    class Car
    {
        /// <summary>
        /// Назва авто
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Рік випуску
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Конструктор створення екземпляру
        /// </summary>
        public Car() { }

        /// <summary>
        /// Конструктор ствоненя авто
        /// </summary>
        /// <param name="name">Назва авто</param>
        /// <param name="year">Рік випуску</param>
        public Car(string name, int year)
        {
            Name = name;
            Year = year;
        }

        /// <summary>
        /// Вивід інформації про авто
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Авто: {Name}, {Year} року випуску.";
        }

    }
}
