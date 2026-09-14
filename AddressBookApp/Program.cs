using System.Data;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;

public class Program
{
    public static void Main(string[] args)
    {
        Contact contact = new Contact("Krishna", "Upadhyay", "1231", "Gurugram", "Haryana", "122001", "1111111111", "krishna0636.be23@chitkara.edu.in");

        string contactInfo = contact.ToString();
        Console.WriteLine(contactInfo);


        // Validate Contact
        try
        {
            ContactValidator.Validate(contact);
            Console.WriteLine("Validation Successful!");
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}