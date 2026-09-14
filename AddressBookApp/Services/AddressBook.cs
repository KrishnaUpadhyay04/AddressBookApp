using AddressBookApp.Models;
<<<<<<< HEAD
=======
using AddressBookApp.Validation;
>>>>>>> feature/UC4-edit-contact

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
<<<<<<< HEAD
=======

    public void UpdateContact()
    {
        Console.WriteLine("Enter the first name: ");
        string? firstName = Console.ReadLine();

        Console.WriteLine("Enter last name: ");
        string? lastName = Console.ReadLine();

        Contact? contact = contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

        if(contact == null)
        {
            Console.WriteLine("Contact not found.");
            return;
        }

        Console.WriteLine("Enter new fields(press enter if don't want to update a field.)");

        Console.WriteLine("Enter first name: ");
        firstName = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(firstName))
        {
            if(ContactValidator.IsValidName(firstName))
            {
                contact.FirstName = firstName;
            }

            else Console.WriteLine("Invalid Entry");
        }

        Console.WriteLine("Enter last name: ");
        lastName = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(lastName))
        {
            if(ContactValidator.IsValidName(lastName))
            {
                contact.LastName = lastName;
            }

            else Console.WriteLine("Invalid Entry");
        }

        Console.WriteLine("Enter address: ");
        string? address = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(address))
        {
            if(ContactValidator.IsValidAddressPart(address))
            {
                contact.Address = address;
            }

            else Console.WriteLine("Invalid Entry");
        }

        Console.WriteLine("Enter City: ");
        string? city = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(city))
        {
            if(ContactValidator.IsValidAddressPart(city)) contact.City = city;
        }

        else Console.WriteLine("Invalid Entry");

        Console.WriteLine("Enter state: ");
        string? state = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(state))
        {
            if(ContactValidator.IsValidAddressPart(state)) contact.State = state;
        }

        else Console.WriteLine("Invalid Entry");

        Console.WriteLine("Enter Zip: ");
        string? zip = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(zip))
        {
            if(ContactValidator.IsValidZip(zip)) contact.Zip = zip;
        }

        else Console.WriteLine("Invalid Entry");


        Console.WriteLine("Enter Mobile No.: ");
        string? number = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(number))
        {
            if(ContactValidator.IsValidNumber(number)) contact.PhoneNumber = number;
        }

        else Console.WriteLine("Invalid Entry");


        Console.WriteLine("Enter Email Id: ");
        string? email = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(email))
        {
            if(ContactValidator.IsValidEmail(email)) contact.Email = email;
        }

        else Console.WriteLine("Invalid Entry");

        Console.WriteLine("Fields updated");
    }
>>>>>>> feature/UC4-edit-contact
}