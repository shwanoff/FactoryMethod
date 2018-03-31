using System;

namespace FactoryMethod
{
    /// <summary>
    /// Российский рубль.
    /// </summary>
    public class Ruble : MoneyBase
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Номинал валюты.
        /// </summary>
        public int Denomination { get; private set; }

        /// <summary>
        /// Создать новый экземпляр рубля.
        /// </summary>
        /// <param name="denomination"> Номинал валюты. </param>
        public Ruble(int denomination) 
            : base("Российский рубль", "₽")
        {
            // Проверяем входные данные на корректность.
            if(denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(denomination));
            }

            // Создаем генератор случайных чисел.
            var rnd = new Random();
            
            // Устанавливаем значения.
            Number = rnd.Next(1000000, 9999999);
            Denomination = denomination;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Информация о купюре. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} номиналом {Denomination}{Symbol}";
        }
    }
}
