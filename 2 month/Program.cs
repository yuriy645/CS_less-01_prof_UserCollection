using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_month
{//Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
 //   количество дней в соответствующем месяце.Реализуйте возможность выбора месяцев, как по
 //  порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
 //  только один месяц.

 //Простейший список однотипных объектов - это класс List<T>, работаем с ней через LINQ.
    struct Month
    {
        public int Number { get; set; }
        public string Monthh { get; set; }
        public int Days { get; set; }
        public Month(int number, string month, int days)
        {
            Number = number;
            Monthh = month;
            Days = days;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var сollection = new List<Month>()
            {
                new Month(1, "January  ", 31),
                new Month(2, "February ", 28),
                new Month(3, "March    ", 31),
                new Month(4, "April    ", 30),
                new Month(5, "May      ", 31),
                new Month(6, "June     ", 30),
                new Month(7, "July     ", 31),
                new Month(8, "August   ", 31),
                new Month(9, "September", 30),
                new Month(10, "October ", 31),
                new Month(11, "November", 30),
                new Month(12, "December", 31),
                //Console.WriteLine("Hello World!");
            };

            foreach (var item in сollection) // вывод всего List<Month>()
            {
                Console.WriteLine($" {item.Number}, Месяц {item.Monthh}, {item.Days} ");
            }
            Console.WriteLine();

            Console.Write("Выбор  месяца по порядковому номеру. Ведите порядковый номер :  ");
            int number = int.Parse(Console.ReadLine());

            // Построить запрос.
            var query = from mo in сollection     // из коллекции элементов,
                        where mo.Number == number // где номер совпадает с введенным
                        select new                // выбрать и записать в новый экземпляр
                        {
                            Monthh = mo.Monthh,   // поле - месяц
                            Days = mo.Days        // и поле - день
                        };
            Console.Write("Данные, выбранные согласно порядковому номеру :  ");

            foreach (var item in query)            // из набора всех новых экземпляров
            {
                Console.WriteLine($"Месяц {item.Monthh}, Дней в месяце {item.Days} "); //вывести поля

            }
            Console.WriteLine();

            Console.Write("Выбор записей по кол-ву дней в месяце. Ведите количество дней :  ");
            int days = int.Parse(Console.ReadLine());

            // Построить запрос.
            var query1 = from mo in сollection     // из коллекции элементов,
                        where mo.Days == days // где номер совпадает с введенным
                        select new                // выбрать и записать в новый экземпляр
                        {
                            Number = mo.Number,
                            Monthh = mo.Monthh,   // поле - месяц
                            Days = mo.Days        // и поле - день
                        };
            Console.Write("Данные, выбранные соответственно дням в месяце:  ");
            Console.WriteLine();

            foreach (var item in query1)            // из набора всех новых экземпляров
            {
                Console.WriteLine($"Порядковый номер {item.Number}, Месяц {item.Monthh}, Дней в месяце {item.Days}"); //вывести поля

            }

        }
    }
}
