using Bogus;
using SampleDataContact;

public class Program
{    
    public static void Main()
    {
        Console.WriteLine("Hello, World!");        
        var userFaker = new Faker<ContactViewList>()
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18))) // Ages between 18 and 48
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());

        // Generate a list of fake users
        List<ContactViewList> users = userFaker.Generate(10);

        // Print the generated users
        foreach (var user in users)
        {
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}, Email: {user.Email}, DOB: {user.DateOfBirth}, Phone: {user.PhoneNumber}");
        }
    }
}