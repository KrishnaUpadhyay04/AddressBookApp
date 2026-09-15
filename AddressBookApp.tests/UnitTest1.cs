using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;
using AddressBookApp.Services;

namespace AddressBookApp.tests;

[TestFixture]
public class Tests
{
    private Contact contact;
    private AddressBook addressBook;
    [SetUp]
    public void Setup()
    {
        addressBook = new();
        contact = new("Krishna", "Upadhyay", "1231", "Gurugram", "Haryana", "122001", "1111111111", "krishna0636.be23@chitkara.edu.in");
    }



    // Validation Test

    [Test]
    public void ValidFirstName()
    {
        Assert.That(ContactValidator.IsValidName(contact.FirstName), Is.True);
    }

    [Test]
    public void ValidLastName()
    {
        Assert.That(ContactValidator.IsValidName(contact.LastName), Is.True);
    }

    [Test]
    public void InvalidFirstName()
    {
        Assert.Throws<InvalidContactException>(
            () => ContactValidator.Validate(new Contact("1John", "Doe", "1231", "Gurugram", "Haryana", "122001", "1111111111", "krishna0636.be23@chitkara.edu.in"))
        );
    }


    [Test]
    public void NameStartsWithLowerCaseLetter()
    {
        contact.FirstName = "krishna";
        Assert.That(ContactValidator.IsValidName(contact.FirstName), Is.False);
    }

    [Test]
    public void NameIsTooShort()
    {
        contact.FirstName = "Jo";
        Assert.That(ContactValidator.IsValidName(contact.FirstName), Is.False);
    }

    [Test]
    public void NameStartsWithANumber()
    {
        contact.FirstName = "1john";
        Assert.That(ContactValidator.IsValidName(contact.FirstName), Is.False);
    }

     [Test]
    public void NameEndsWithANumber()
    {
        contact.FirstName = "John1";
        Assert.That(ContactValidator.IsValidName(contact.FirstName), Is.False);
    }

    [Test]
    public void NameIsEmpty()
    {
        contact.FirstName = "";
        Assert.That(ContactValidator.IsValidName(contact.FirstName), Is.False);
    }




    // Contact CRUD Test

    [Test]
    public void AddValidContact()
    {
        addressBook.AddContact(contact);

        Assert.That(addressBook.contacts.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddAlreadyExistingContact()
    {
        addressBook.AddContact(contact);
        Assert.Throws<InvalidContactException>(() => addressBook.AddContact(contact));
    }

    [Test]
    public void AddInvalidContact()
    {
        contact.FirstName = "1John";

        Assert.Throws<InvalidContactException>(() => addressBook.AddContact(contact));
    }
}
