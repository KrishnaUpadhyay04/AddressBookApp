using System.Data;
using AddressBookApp.Models;

public class Program
{
    public static void Main(string[] args)
    {
        Contact contact = new Contact("Krishna", "Upadhyay", "123", "Gurugram", "Haryana", "122001", "1111111111", "krishna0636.be23@chitkara.edu.in");

        string contactInfo = contact.ToString();
        Console.WriteLine(contactInfo);
    }
}