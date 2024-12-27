using Iterator;

PeopleCollection people = new();

people.Add(new Person("SR", "Tiruppur"));
people.Add(new Person("Ashwin", "Bangalore"));
people.Add(new Person("Gautam", "Coimbatore"));
people.Add(new Person("Loki", "Chennai"));

var peopleIterator = people.CreateIterator();

for (Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
    Console.WriteLine(person.Name);

Console.ReadKey();
