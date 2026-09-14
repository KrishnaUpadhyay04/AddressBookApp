using AddressBookApp.Models;
using AddressBookApp.Validation;
using AddressBookApp.Exceptions;

namespace AddressBookApp.tests;

public class Tests
{
    private Contact contact;
    [SetUp]
    public void Setup()
    {
        contact = new("Krishna", "Upadhyay", "1231", "Gurugram", "Haryana", "122001", "1111111111", "krishna0636.be23@chitkara.edu.in");
    }

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
            () => ContactValidator.Validate(new Contact("John", "Doe", "1231", "Gurugram", "Haryana", "122001", "1111111111", "krishna0636.be23@chitkara.edu.in"))
        );
    }
}
