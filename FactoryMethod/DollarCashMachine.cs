using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryMethod
{
    public class DollarCashMachine : CashMachineBase
    {
        /// <summary>
        /// Номинал купюры.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// Создать новый экземпляр устройства для печати американских долларов.
        /// </summary>
        /// <param name="denomination"> Номинал. </param>
        public DollarCashMachine(int denomination = 100) 
            : base("Устройство для печати американских долларов")
        {
            // Проверяем входные данные на корректность.
            if (denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(denomination));
            }

            // Возможные номиналы валюты.
            var correntDenomination = new int[] { 5, 10, 50, 100, 500, 1000 };

            // Проверяем корректность номинала.
            if (!correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Некорректный номинал валюты.", nameof(denomination));
            }

            // Устанавливаем значение.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // Количество купюр на одном листе бумаги.
            var countOnPage = 50;

            // Подсчитываем количество денег, которое должно быть напечатано.
            var count = countOnPage * pageCount;

            // Создаем коллекцию для сохранения денег.
            var money = new List<MoneyBase>();

            // Создаем деньги и добавляем в коллекцию.
            for (var i = 0; i < count; i++)
            {
                var ruble = new Dollar(_denomination);
                money.Add(ruble);
            }

            // Возвращаем готовые деньги.
            return money.ToArray();
        }
    }
}
