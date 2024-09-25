using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using Spectre.Console;
using System.Data;

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
            AnsiConsole.Markup("[blue]Contact added[/]\n\n");
        }

        internal void ViewContacts()
        {
            var entities = _context.Contact.ToList();

            if (entities.Count == 0)
            {
                AnsiConsole.Markup("[red]Table is empty[/]\n\n");
                return;
            }

            Table table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            table.AddColumn("Contact Number");
            table.AddColumn("Email ID");
            AnsiConsole.Markup("[blue]Phone Book[/]\n");
            foreach (var entity in entities)
            {
                int id = entity.Id; 
                string name = entity.Name;
                string email = entity.Email;
                string number = entity.PhoneNumber;

                table.AddRow(
                    id.ToString(), name, number, email
                    );
            }

            AnsiConsole.Write(table);
            Console.WriteLine("\n");

        }

        public void DeleteContact(int id)
        {
            var entity = _context.Contact.FirstOrDefault(x => x.Id == id);
          
            _context.Remove(entity);
            _context.SaveChanges();
            AnsiConsole.Markup("[blue]Contact deleted[/]\n");

            ViewContacts();
        }

        public void UpdateContacts(int id, string updateValue, string updateColumn)
        {
            var entity = _context.Contact.FirstOrDefault(x=> x.Id == id);

            if (updateColumn == "Name")
            {
                entity.Name = updateValue;
            }
            else if (updateColumn == "PhoneNumber")
            {
                entity.PhoneNumber = updateValue;
            }
            else if (updateColumn == "Email")
            {
                entity.Email = updateValue;
            }
            else
            {
                entity.Category = updateValue;
            }

            _context.Update(entity);
            _context.SaveChanges();

            AnsiConsole.Markup($"[blue]Contact {updateColumn} is updated[/]\n\n");

            ViewContacts();

        }

        internal bool CheckIdExists(int id)
        {
            var entity = _context.Contact.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        internal void GetCurrentValue(int id, string updateColumn)
        {
            var entity = _context.Contact
                    .Where(c => c.Id == id)
                    .Select(c => EF.Property<string>(c, updateColumn))
                    .FirstOrDefault();

            Console.WriteLine("Current value: " + entity);
        }
    }
}
