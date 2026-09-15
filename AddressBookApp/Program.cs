using System.Data;
using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using AddressBookApp.Services;

public class Program
{
    public static void Main(string[] args)
    {

        AddressBook addressBook = new();
        AddressBookMain addressBookMain = new();
        addressBookMain.AddAddressBook(addressBook);

        Console.WriteLine("--------ADDRESS BOOK MENU--------");

        while(true)
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Show All Contacts");
            Console.WriteLine("5. Total Contact Count");
            Console.WriteLine("6. Search By City/State");
            Console.WriteLine("7. View By City");
            Console.WriteLine("8. View By State");
            Console.WriteLine("9. Count By City/State");
            Console.WriteLine("10. Sort By Name");
            Console.WriteLine("11. Sort By City, Name, Zip");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    addressBook.AddContact();
                    break;

                case 2:
                    addressBook.UpdateContact();
                    break;

                case 3:
                    addressBook.RemoveByName();
                    break;

                case 4:
                    addressBook.PrintAll();
                    break;

                case 5:
                    int count = addressBookMain.CountContacts();
                    Console.WriteLine(count);
                    break;

                case 6:
                    addressBookMain.SearchByCityOrState();
                    break;

                case 7:
                    addressBookMain.DisplayContactsGroupedByCity();
                    break;

                case 8:
                    addressBookMain.DisplayContactsGroupedByState();
                    break;

                case 9:
                    addressBookMain.CountByCityOrState();
                    break;

                case 10:
                    addressBookMain.SortEntriesByName();
                    break;

                case 11:
                    Console.WriteLine("Enter field you want to sort by City(c), State(s), Zip(z)");
                    char ch = Console.ReadLine()[0];

                    if(ch == 'c')
                    {
                        addressBookMain.SortEntriesByCity();
                    }

                    else if(ch == 's')
                    {
                        addressBookMain.SortEntriesByState();
                    }

                    else if(ch == 'z')
                    {
                        addressBookMain.SortEntriesByZip();
                    }

                    else
                    {
                        Console.WriteLine("Invalid input");
                    }

                    break;

                case 0:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Choice! Try again");
                    break;
            }
        }
    }
}