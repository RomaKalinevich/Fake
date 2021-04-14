using System;
using System.Collections.Generic;
using Bogus;
using ServiceStack.Text;

namespace Fake_data
{
    public class Person
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string location = args[0];
            int count = Convert.ToInt32(args[1].ToString());
            // получаем экземляр класса Faker<Person>
            Faker<Person> generatorPerson = getGeneratorPerson(location);
            // генерируем обьекты класса Person
            List<Person> persons = new List<Person>();
            persons = generatorPerson.Generate(count);
            // выводим полученные объекты на консоль
            printPersons(persons);

        }

        private static Faker<Person> getGeneratorPerson(string location)
        {
            // создаём экземпляр класса Faker<Person> и передаем локацию
            return new Faker<Person>(location)
                // задаём правило генерации для свойства FullName
                .RuleFor(x => x.FullName, f => f.Name.FullName())
                // задаём правило генерации для свойства Age
                .RuleFor(x => x.Address, f => f.Address.FullAddress())
                // задаём правило генерации для свойства Phone
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber());
        }

        private static void printPersons(List<Person> persons)
        {
            string str = CsvSerializer.SerializeToCsv<Person>(persons);
            Console.WriteLine(str);
        }
    }
}