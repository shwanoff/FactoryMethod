using System;

namespace FactoryMethod
{
    /// <summary>
    /// Базовый класс для устройств печати денег.
    /// </summary>
    public abstract class CashMachineBase
    {
        /// <summary>
        /// Название устройства.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Создать новый экземпляр устройства печати денег.
        /// </summary>
        /// <param name="name"> Название. </param>
        public CashMachineBase(string name)
        {
            // Проверяем входные данные на корректность.
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            // Устанавливаем значение.
            Name = name;
        }

        /// <summary>
        /// Напечатать новую партию денег.
        /// </summary>
        /// <param name="pageCount"> Количество листов бумаги для денег. </param>
        /// <returns> Напечатанные деньги. </returns>
        public abstract MoneyBase[] Create(int pageCount);

        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Название. </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
