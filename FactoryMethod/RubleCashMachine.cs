using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryMethod
{
    /// <summary>
    /// Устройство для печати российских рублей.
    /// </summary>
    public class RubleCashMachine : CashMachineBase
    {
        /// <summary>
        /// Количество купюр на одном листе бумаги.
        /// </summary>
        private readonly int _countOnPage = 64;

        /// <summary>
        /// Номинал купюры.
        /// </summary>
        private int _denomination;

        /// <summary>
        /// Возможные номиналы валюты.
        /// </summary>
        private int[] _correntDenomination = { 50, 100, 200, 500, 1000, 2000, 5000 };

        /// <summary>
        /// Создать новый экземпляр устройства для печати российских рублей.
        /// </summary>
        /// <param name="denomination"> Номинал. </param>
        public RubleCashMachine(int denomination = 1000) 
            : base("Устройство для печати российских рублей")
        {
            // Проверяем входные данные на корректность.
            if(denomination <= 0)
            {
                throw new ArgumentException("Номинал валюты должен быть больше нуля.", nameof(denomination));
            }

            if(!_correntDenomination.Contains(denomination))
            {
                throw new ArgumentException($"Некорректный номинал валюты.", nameof(denomination));
            }

            // Устанавливаем значение.
            _denomination = denomination;
        }

        /// <inheritdoc />
        public override MoneyBase[] Create(int pageCount)
        {
            // Подсчитываем количество денег, которое должно быть напечатано.
            var count = _countOnPage * pageCount;

            // Создаем коллекцию для сохранения денег.
            var money = new List<MoneyBase>();

            // Создаем деньги и добавляем в коллекцию.
            for(var i = 0; i < count; i++)
            {
                var ruble = new Ruble(_denomination);
                money.Add(ruble);
            }

            // Возвращаем готовые деньги.
            return money.ToArray();
        }
    }
}
