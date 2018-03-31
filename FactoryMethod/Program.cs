using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // Устанавливаем кодировку чтобы корректно отобразился символ рубля.
            Console.OutputEncoding = Encoding.Unicode;

            // Создаем коллекцию устройств для печати денег.
            // Обратите внимание, что мы можем хранить их все в одной коллекции.
            var machines = new List<CashMachineBase>
            {
                new RubleCashMachine(),
                new DollarCashMachine()
            };

            // Создаем коллекцию для хранения денег.
            // Опять таки здесь могут храниться любые классы, унаследованные от MoneyBase.
            var money = new List<MoneyBase>();

            // Генератор случайных числе.
            var rnd = new Random();

            // По очереди запускаем устройства для печати денег.
            foreach(var machine in machines)
            {
                // Случайное количество листов для разнообразия.
                var pageCount = rnd.Next(1, 3);

                // Вызываем фабричный метод для создания валюты.
                var newMoney = machine.Create(pageCount);

                // Добавляем созданную валюту в общую коллекцию.
                money.AddRange(newMoney);
            }

            // Выводим данные о деньгах на экран.
            foreach(var note in money)
            {
                Console.WriteLine(note);
            }

            Console.ReadLine();
        }
    }
}
