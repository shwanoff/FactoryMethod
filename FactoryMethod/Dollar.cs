using System;

namespace FactoryMethod
{
    /// <summary>
    /// Американский доллар.
    /// </summary>
    public class Dollar : MoneyBase
    {
        /// <summary>
        /// Уникальный код.
        /// </summary>
        public Guid Number { get; private set; }

        /// <summary>
        /// Номинал валюты.
        /// </summary>
        public int Volume { get; private set; }

        /// <summary>
        /// Создать новый экземпляр американского доллара.
        /// </summary>
        /// <param name="volume"> Номинал. </param>
        public Dollar(int volume) 
            : base("American dollar", "$")
        {
            // Проверяем входные данные на корректность.
            if (volume <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(volume));
            }

            Number = Guid.NewGuid();
            Volume = volume;
        }

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Информация о купюре. </returns>
        public override string ToString()
        {
            return $"{Name} {Number} номиналом {Volume}{Symbol}";
        }
    }
}
