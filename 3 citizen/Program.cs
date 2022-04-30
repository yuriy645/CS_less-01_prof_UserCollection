using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_citizen
{//Создайте абстрактный класс Гражданин. Создайте классы Студент, Пенсионер, Рабочий
 //   унаследованные от Гражданина.Создайте непараметризированную коллекцию со следующим
 //  функционалом:

    //1. Добавление элемента в коллекцию.
    //1) Можно добавлять только Гражданина.
    //2) При добавлении, элемент добавляется в конец коллекции.Если Пенсионер, – то в
    //начало с учетом ранее стоящих Пенсионеров. Возвращается номер в очереди.
    //3) При добавлении одного и того же человека(проверка на равенство по номеру
    //паспорта, необходимо переопределить метод Equals и/или операторы равенства для
    //сравнения объектов по номеру паспорта) элемент не добавляется, выдается
    //сообщение.

    //2. Удаление
    //1) Удаление – с начала коллекции.
    //2) Возможно удаление с передачей экземпляра Гражданина.

    //3. Метод Contains возвращает true/false при налчичии/отсутствии элемента в коллекции и
    //номер в очереди.
    //4. Метод ReturnLast возвращsает последнего чеолвека в очереди и его номер в очереди.
    //5. Метод Clear очищает коллекцию.
    //6. С коллекцией можно работать опертаором foreach.

    //Метод создания гражданина собирает данные, создает Пенсионера/Студента/Рабочего и апкастит к гражданину,
    //чтоб хранить его в базе
    //перед помещением в базу проверяем наличие номера паспорта в базе и проверяем нет ли такого же номера в базе (переопределение Equals)
    //перед помещением в базу определяем тип гражданина и соответственно определяем его позицию в списке
   
    public abstract class Citizen
    {
        public string Name { get; set; }
        public string Passport { get; set; }
        public override bool Equals(Object obj)
        {
            //if (obj == null || this.GetType() != obj.GetType()) //если тип текущего класса не равен типу аргумента (вдруг 
            //{
            //    Console.WriteLine("несовпадение типов");
            //    return false;                                   // захотим сравнить яблоко с коровой
            //}
            Citizen citizen = (Citizen)obj; //в citizen записываем экземпляр, который пришел на вход, приведенный к object
            return (this.Passport == citizen.Passport); //сравниваем паспорт нашего класса, с паспортом, который зашел с объектом
                                                         //если совпадение паспортов экземпляров, то возвращаем true
        }
        //тут неплохо бы и GetHashCode() переопределить
        
    }
    class Student : Citizen
    {
        public int HoursPerWeek { get; set; } //сколько часов учится в неделю
    }
    class Pensioner : Citizen
    {
        public int Grandchilds { get; set; } //количество внуков
    }
    class Worker : Citizen
    {
        public double Salary { get; set; } //зарплата
    }

    class Program
    {
        static string GetPassport() //Метод принимает номер паспорта
        {
            Console.WriteLine("Введите номер паспорта");
            string input = Console.ReadLine();
            if (input != "-")
                return input;
            else return null;
        }

        static Citizen GetPeople() //Метод создает гражданина
        {
            Console.WriteLine();
            Console.WriteLine("Новая запись данных гражданина. Введите ответ на запрос или прочерк - ");
            
            Console.WriteLine("Введите количество часов учебы в неделю");
            string input = Console.ReadLine();
            if (input != "-")
            {
                var people = new Student();
                people.HoursPerWeek = int.Parse(input);
                people.Passport = GetPassport();
                return people;
            }

            Console.WriteLine("Введите количество внуков");
            input = Console.ReadLine();
            if (input != "-")
            {
                var people = new Pensioner();
                people.Grandchilds = int.Parse(input);
                people.Passport = GetPassport();
                return people;
            }

            Console.WriteLine("Введите зарплату");
            input = Console.ReadLine();
            if (input != "-")
            {
                var people = new Worker();
                people.Salary = int.Parse(input);
                people.Passport = GetPassport();
                return people;
            }
            else return null;
        }

        static void GetCitizenInfo(Citizen citizen) //Метод распечатывает карточку гражданина
        {
            Console.WriteLine("--------");
            Console.WriteLine("Вывод данных по гражданину");
            var people = citizen as Student;
            if (people != null)
                Console.WriteLine($"Это студент. Кол-во часов учебы в неделю {people.HoursPerWeek}. Паспорт {people.Passport}" );
            var people1 = citizen as Pensioner;
            if (people1 != null)
                Console.WriteLine($"Это пенсионер. Кол-во внуков {people1.Grandchilds}. Паспорт {people1.Passport}");
            var people2 = citizen as Worker;
            if (people2 != null)
                Console.WriteLine($"Это рабочий. Зарплата {people2.Salary}. Паспорт {people2.Passport}");
            Console.WriteLine("-----------");
        }
        static void Main(string[] args)
        {
            var list = new ArrayList();

            Citizen citizen;

            for (int i = 0; i < 3; i++) // цикл добавления граждан
            {
                citizen = GetPeople();

                if ((citizen.Passport == "-") || (citizen.Passport == "-"))
                {
                    Console.WriteLine("Невозможно добавить гражданина. Отсутсвует номер паспорта");
                    break;
                }

                foreach (var item in list) // проверка, есть ли уже такой номер паспорта в базе 
                {
                    if (citizen.Equals(item)) // проверка переопределенным методом
                    {
                        Console.WriteLine("Невозможно добавить гражданина. Гражданин с таким номером паспорта уже есть в списке.");
                        break; // чтоб дальше долго не искать выходим из цикла
                    }

                }


                if ((citizen as Pensioner) != null)  //если гражданин- это пенсионер, то запускаем процедуру его вставки в начало после других пенсионеров
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if ((list[j] as Pensioner) == null) // если это не пенсионер
                        {
                            list.Insert(j, citizen); // то добавляем его в эту позицию, котрая первая без пенсионеров после пенсионеров
                            break; // только один раз добавили и выходим из цикла
                        }
                    }
                }
                else list.Add(citizen); // если не пенсионер, то в конец его добавляем


            }

            foreach (var item in list) // вывод всего содержимого
            {
                GetCitizenInfo((Citizen)item);
            }

            Console.WriteLine("Подтвердите удаление первого элемента коллекции " );
            Console.ReadLine();
            list.RemoveAt(0);
            foreach (var item in list) // вывод всего содержимого
            {
                GetCitizenInfo((Citizen)item);
            }

            Console.WriteLine("Введите номер паспорта для удаления гражданина ");
            for (int i = 0; i < list.Count; i++)
            {
                if ( ((Citizen)list[i]).Passport == Console.ReadLine() )
                    list.RemoveAt(i);
            }
            foreach (var item in list) // вывод всего содержимого
            {
                GetCitizenInfo((Citizen)item);
            }


            Console.WriteLine("Ведите номер паспорта для проверки, есть ли он в базе ");
            for (int i = 0; i < list.Count; i++)
            {
                if (((Citizen)list[i]).Passport == Console.ReadLine())
                    Console.WriteLine($"Номер паспорта присутствует в базе, порядковый номер в базе {i+1}"); ;
            }

            Console.WriteLine($"Последняя запись в базе ");
            GetCitizenInfo((Citizen)list[list.Count - 1]);

            Console.WriteLine("Подтвердите очистку коллекции");
            Console.ReadLine();
            list.Clear();
            foreach (var item in list) // вывод всего содержимого
            {
                GetCitizenInfo((Citizen)item);
            }

        }
    }
}
