using ActionFilterSample.Models;

namespace ActionFilterSample.Repositories
{
    public interface IPersonRepository
    {
        ICollection<Person> GetPersons();
        Person GetPerson(int id);
    }

    public class PersonRepository : IPersonRepository
    {
        List<Person> people = new List<Person> {
                new Person { Id = 1,Name="Saeed" , Family="Rezaei",Gender=1,MilitaryServiceStatus=1},
                new Person { Id = 2,Name="Sara" , Family="Mohammadi",Gender=2,MilitaryServiceStatus=0},
                new Person { Id = 3,Name="Ali" , Family="Nori",Gender=1,MilitaryServiceStatus=1},
                new Person { Id = 4,Name="Maryam" , Family="Minaei",Gender=2,MilitaryServiceStatus=0}
            };
        public Person GetPerson(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);

            if (person == null)
                return new Person();

            return person;

        }

        public ICollection<Person> GetPersons()
        {
            return people.ToList();
        }
    }
}
