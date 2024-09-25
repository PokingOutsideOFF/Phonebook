using PhoneBook.Models;
using Spectre.Console;

namespace PhoneBook
{
    internal class PhonebookRepositiory
    {
        PhonebookContext _context = new();

        public void AddContact(string name, string number, string email)
        {
            Contact contact = new Contact
            {
                Name = name,
                Email = email,
                PhoneNumber = number
            };
             
            _context.Add(contact);
            _context.SaveChanges();
            AnsiConsole.Markup("[blue]Contact added[/]");
        }
    }
}
