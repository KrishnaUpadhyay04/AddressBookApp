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
}