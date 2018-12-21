using System;

namespace Creational.BuilderFacade
{
    public class Person
    {
        //Address;
        public string StreetAddress, PostCode, City;

        //Employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonBuilder // facade
    {
        // Reference!
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        //Used to convert to Person (see caller)
        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postcode)
        {
            person.PostCode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    public class BuilderWithFacade
    {
        public BuilderWithFacade()
        {
            var pb = new PersonBuilder();
            Person person = pb
                .Lives
                    .At("Juca Maia")
                    .In("Lafaiete")
                    .WithPostCode("36420000")
                .Works
                    .At("Energisa")
                    .AsA("Software Developer")
                    .Earning(50000);

            Console.WriteLine(person);
        }
    }
}
