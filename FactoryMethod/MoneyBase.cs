using System;

namespace FactoryMethod
{
    /// <summary>
    /// Базовый класс для любой валюты.
    /// </summary>
    public abstract class MoneyBase
    {
        /// <summary>
        /// Название валюты.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Символ валюты.
        /// </summary>
        public string Symbol { get; protected set; }

        /// <summary>
        /// Создать новый экземпляр валюты.
        /// </summary>
        /// <param name="name"> Название валюты. </param>
        /// <param name="symbol"> Символ валюты. </param>
        public MoneyBase(string name, string symbol)
        {
            // Проверяем входные данные на корректность.
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(string.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            // Устанавливаем значения.
            Name = name;
            Symbol = symbol;
        }

        /// <summary>
        /// Приведение объекта к строке. 
        /// </summary>
        /// <returns> Название валюты. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
