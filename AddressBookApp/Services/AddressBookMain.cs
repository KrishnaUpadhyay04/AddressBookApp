using AddressBookApp.Models;

namespace AddressBookApp.Services;

public class AddressBookMain
{
    private readonly List<AddressBook> books;


    public AddressBookMain()
    {
        books = new();
    }

    public void AddAddressBook(AddressBook book)
    {
        books.Add(book);
    }

    public int CountContacts()
    {
        return books.Sum(b => b.contacts.Count);
    }

    public void SearchByCityOrState()
    {
        Console.WriteLine("Enter 1 if you want to seach by city else enter 2 if you want to search by state.");
        int choice = Convert.ToInt32(Console.ReadLine());

        if(choice == 1)
        {
            Console.WriteLine("Enter city name: ");
            string? city = Console.ReadLine();

            if(city == null)
            {
                Console.WriteLine("Invalid entry");
                return;
            }

            var result = books.SelectMany(b => b.contacts).Where(c => c.City.Equals(city, StringComparison.OrdinalIgnoreCase));
            foreach(var c in result)
            {
                Console.WriteLine(c.ToString());
            }
        }

        else if(choice == 2)
        {
            Console.WriteLine("Enter state name: ");
            string? state = Console.ReadLine();

            if(state == null)
            {
                Console.WriteLine("Invalid entry");
                return;
            }

            var result = books.SelectMany(b => b.contacts).Where(c => c.State.Equals(state, StringComparison.OrdinalIgnoreCase));
            foreach(var c in result)
            {
                Console.WriteLine(c.ToString());
            }
        }

        else
        {
            Console.WriteLine("Invalid Choice.");
        }
    }

    public void DisplayContactsGroupedByCity()                                  // UC9
    {
        Dictionary<string, List<Contact>> result = books.SelectMany(c => c.contacts)
                                                    .GroupBy(contact => contact.City)
                                                    .ToDictionary(g => g.Key, g => g.ToList());

        foreach(var entry in result)
        {
            Console.WriteLine(entry.Key);

            foreach(var contact in entry.Value)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            }
        }
    }

    public void DisplayContactsGroupedByState()
    {
        Dictionary<string, List<Contact>> result = books.SelectMany(c => c.contacts)
                                                    .GroupBy(contact => contact.State)
                                                    .ToDictionary(g => g.Key, g => g.ToList());

        foreach(var entry in result)
        {
            Console.WriteLine(entry.Key);

            foreach(var contact in entry.Value)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            }
        }
    }


    public void CountByCityOrState()                                          // UC10
    {
        Console.WriteLine("------Count by City--------");
        var countByCity = books.SelectMany(c => c.contacts).GroupBy(contact => contact.City);

        foreach(var entry in countByCity)
        {
            Console.WriteLine($"{entry.Key}= {entry.Count()}");
        }

        Console.WriteLine("------Count by State--------");
        var countByState = books.SelectMany(c => c.contacts).GroupBy(contact => contact.State);

        foreach(var entry in countByState)
        {
            Console.WriteLine($"{entry.Key}= {entry.Count()}");
        }
    }
}