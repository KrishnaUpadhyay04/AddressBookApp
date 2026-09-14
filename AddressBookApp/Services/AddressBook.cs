using AddressBookApp.Models;

namespace AddressBookApp.Services;

public class AddressBook
{
    private List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void PrintAll()
    {
        foreach(Contact contact in contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }
}