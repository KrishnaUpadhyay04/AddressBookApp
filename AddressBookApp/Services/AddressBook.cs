using AddressBookApp.Exceptions;
using AddressBookApp.Models;

using AddressBookApp.Validation;

namespace AddressBookApp.Services;

public class AddressBook
{
    public List<Contact> contacts;

    public AddressBook()
    {
        contacts = new List<Contact>();
    }


    // Testing
    public void AddContact(Contact contact)
    {
        ContactValidator.Validate(contact);

        if(ContactExists(contact))
        {
            throw new InvalidContactException("Contact Already Exists.");
        }
        contacts.Add(contact);
    }

    public void AddContact()
    {

        Console.WriteLine("Enter first name: ");
        string? firstName = Console.ReadLine();

        Console.WriteLine("Enter last name: ");
        string? lastName = Console.ReadLine();

        Console.WriteLine("Enter address: ");
        string? address = Console.ReadLine();

        Console.WriteLine("Enter City: ");
        string? city = Console.ReadLine();

        Console.WriteLine("Enter state: ");
        string? state = Console.ReadLine();

        Console.WriteLine("Enter Zip: ");
        string? zip = Console.ReadLine();

        Console.WriteLine("Enter Mobile No.: ");
        string? number = Console.ReadLine();

        Console.WriteLine("Enter Email Id: ");
        string? email = Console.ReadLine();

        Contact contact = new Contact(firstName, lastName, address, city, state, zip, number, email);

        ContactValidator.Validate(contact);

        if(ContactExists(contact))
        {
            throw new InvalidContactException("Contact Already Exists.");
        }
        contacts.Add(contact);
    }

    public bool ContactExists(Contact contact)                                            // UC7
    {
        return contacts.Any(c => string.Equals(c.FirstName, contact.FirstName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.LastName, contact.LastName, StringComparison.OrdinalIgnoreCase));
    }

    // UC 4
    public void PrintAll()
    {
        foreach(Contact contact in contacts)
        {
            Console.WriteLine(contact.ToString());
        }
    }

    public void UpdateContact()
    {
        Console.WriteLine("Enter the first name: ");
        string? firstName = Console.ReadLine();

        Console.WriteLine("Enter last name: ");
        string? lastName = Console.ReadLine();

        Contact? contact = contacts.FirstOrDefault(c => string.Equals(c.FirstName, firstName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.LastName, lastName, StringComparison.OrdinalIgnoreCase));

        if(contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("Enter new fields(press enter if don't want to update a field.)");

        Console.WriteLine("Enter first name: ");
        firstName = Console.ReadLine();

        Console.WriteLine("Enter last name: ");
        lastName = Console.ReadLine();

        Console.WriteLine("Enter address: ");
        string? address = Console.ReadLine();

        Console.WriteLine("Enter City: ");
        string? city = Console.ReadLine();

        Console.WriteLine("Enter state: ");
        string? state = Console.ReadLine();

        Console.WriteLine("Enter Zip: ");
        string? zip = Console.ReadLine();

        Console.WriteLine("Enter Mobile No.: ");
        string? number = Console.ReadLine();

        Console.WriteLine("Enter Email Id: ");
        string? email = Console.ReadLine();

        string newFirstName = (!String.IsNullOrWhiteSpace(firstName)) ? firstName : contact.FirstName;
        string newLastName = (!String.IsNullOrWhiteSpace(lastName)) ? lastName : contact.LastName;
        string newAddress = (!String.IsNullOrWhiteSpace(address)) ? address : contact.Address;
        string newCity = (!String.IsNullOrWhiteSpace(city)) ? city : contact.City;
        string newState = (!String.IsNullOrWhiteSpace(state)) ? state : contact.State;
        string newZip = (!String.IsNullOrWhiteSpace(zip)) ? zip : contact.Zip;
        string newNumber = (!String.IsNullOrWhiteSpace(number)) ? number : contact.PhoneNumber;
        string newEmail = (!String.IsNullOrWhiteSpace(email)) ? email : contact.Email;

        Contact newContact = new(newFirstName, newLastName, newAddress, newCity, newState, newZip, newNumber, newEmail);

        ContactValidator.Validate(newContact);

        if(!ContactExists(newContact))
        {
            contact.FirstName = newContact.FirstName;
            contact.LastName = newContact.LastName;
            contact.Address = newContact.Address;
            contact.City = newContact.City;
            contact.State = newContact.State;
            contact.Zip = newContact.Zip;
            contact.PhoneNumber = newContact.PhoneNumber;
            contact.Email = newContact.Email;
        }

        Console.WriteLine("Fields updated");
    }

    public void RemoveByName()
    {
        Console.Write("Enter first name: ");
        string? firstName = Console.ReadLine();

        Console.Write("\nEnter last name: ");
        string? lastName = Console.ReadLine();

        Console.WriteLine();

        Contact? contact = contacts.FirstOrDefault(c => string.Equals(c.FirstName, firstName, StringComparison.OrdinalIgnoreCase) && string.Equals(c.LastName, lastName, StringComparison.OrdinalIgnoreCase));

        if(contact == null)
        {
            Console.WriteLine("Data not found");
            return;
        }

        contacts.Remove(contact);
        Console.WriteLine("Contact deleted");
    }

}