using System.Text.RegularExpressions;
using AddressBookApp.Models;
using AddressBookApp.Exceptions;

namespace AddressBookApp.Validation;

public class ContactValidator
{
    
    public static bool IsValidName(string name)
    {
        return Regex.IsMatch(name, @"^[A-Z][a-zA-Z]{2,}$");
    }

    public static bool IsValidAddressPart(string addressPart)
    {
        return Regex.IsMatch(addressPart, @"^.{4,}$");
    }

    public static bool IsValidZip(string zip)
    {
        return Regex.IsMatch(zip, @"^\d{6}$");
    }

    public static bool IsValidNumber(string number)
    {
        return Regex.IsMatch(number, @"^\d{10}$");
    }

    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    public static void Validate(Contact contact)
    {
        if(!IsValidName(contact.FirstName)) throw new InvalidContactException("Invalid First Name");

        if(!IsValidName(contact.LastName)) throw new InvalidContactException("Invalid Last Name");

        if(!IsValidAddressPart(contact.Address)) throw new InvalidContactException("Invalid Address");

        if(!IsValidAddressPart(contact.City)) throw new InvalidContactException("Invalid City");

        if(!IsValidAddressPart(contact.State)) throw new InvalidContactException("Invalid State");

        if(!IsValidZip(contact.Zip)) throw new InvalidContactException("Invalid Zip");
        
        if(!IsValidNumber(contact.PhoneNumber)) throw new InvalidContactException("Invalid Phone Number");
        
        if(!IsValidEmail(contact.Email)) throw new InvalidContactException("Invalid Email");

    }

}