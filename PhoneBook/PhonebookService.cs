using Spectre.Console;

namespace PhoneBook
{
    public class PhonebookService
    {
        public static void PerformOperation(int opt)
        {
            Console.Clear();
            UserInput userInput = new();
            PhonebookRepositiory repo = new();
            Validation validation = new();

            int choice;

            switch (opt)
            {
                case 1:
                    Console.Write("Enter Contact Name: ");
                    string name = userInput.GetText();
                    Console.Write("Enter Contact Number (10 digits): ");
                    string number = userInput.GetNumber();
                    Console.Write("Enter Contact email: ");
                    string email = userInput.GetEmail();
                    string category = null;
                    Console.Write("Press (y/Y) to add to category?: ");
                    if(Console.ReadLine().Substring(0, 1).ToLower() == "y")
                    {
                        Console.Write("Enter category: ");
                        category = Console.ReadLine();

                    }
                    repo.AddContact(name, number, email, category);
                    break;

                case 2:
                    choice = userInput.ViewMenuChoice();
                    if (choice == 3) return;

                    switch (choice)
                    {
                        case 1:
                            repo.ViewContacts();
                            break;
                        case 2:
                            var categories = repo.GetCategories();
                            category = userInput.CategoryMenu(categories);
                            repo.ViewContacts(category);
                            break;
                    }
                    break;

                case 3:

                    choice = userInput.UpdateMenuChoice();

                    if (choice == 5) return;

                    repo.ViewContacts(); 

                    Console.Write("Enter Phone id which is to be updated: ");
                    int id = userInput.GetId();
                    if (!repo.CheckIdExists(id))
                    {
                        AnsiConsole.Markup("[red]Phone Id doesn't exist. Returning to Main Menu....[/]\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                    }

                    switch (choice)
                    {
                        case 1:
                            string updateColumn = "Name";
                            repo.GetCurrentValue(id, updateColumn);

                            Console.Write("Enter new contact name: ");
                            name = userInput.GetText();
                            repo.UpdateContacts(id, name, updateColumn);
                            break;

                        case 2:
                            updateColumn = "PhoneNumber";
                            repo.GetCurrentValue(id, updateColumn);

                            Console.Write("Enter new contact number: ");
                            number = userInput.GetNumber();
                            
                            repo.UpdateContacts(id, number, updateColumn);
                            break;

                        case 3:
                            updateColumn = "Email";
                            repo.GetCurrentValue(id, updateColumn);

                            Console.Write("Enter new contact email: ");
                            email = userInput.GetEmail() ;
                            repo.UpdateContacts(id, email, updateColumn);
                            break;

                        case 4:
                            updateColumn = "Category";
                            repo.GetCurrentValue(id, updateColumn);

                            Console.Write("Enter new contact category: ");
                            category = Console.ReadLine();
                            validation.IsValidName(category);
                            repo.UpdateContacts(id, category, updateColumn);
                            break;
                    }
                    break;

                case 4:
                    repo.ViewContacts();
                    Console.Write("\nEnter contact id to be deleted: ");
                    id = userInput.GetId();

                    if (!repo.CheckIdExists(id))
                    {
                        AnsiConsole.Markup("[red]Phone Id doesn't exist. Returning to Main Menu....[/]\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                    }

                    repo.DeleteContact(id);
                    break;
            }

            AnsiConsole.Markup("[blue]Press any key to continue[/]");
            Console.ReadLine();
            Console.Clear() ;
            return;
        }
    }
}
