using Microsoft.IdentityModel.Tokens;
using Spectre.Console;

namespace PhoneBook
{
    public class UserInput
    {
        Validation validation = new();
        public void MainMenuChoice()
        {
            while (true)
            {
                string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("[blue] MAIN MENU[/]")
                    .PageSize(5)
                    .AddChoices(
                    new[]
                    {
                    "[springgreen2]1. Add Contact[/]", "[springgreen2]2. View Contacts[/]", "[springgreen2]3. Edit Contact[/]", "[springgreen2]4. Delete Contact[/]", "[red]5. Exit[/]"
                    }));

                int opt = int.Parse(choice.Substring(choice.IndexOf(']') + 1, 1));

                if (opt == 5)
                {
                    AnsiConsole.Markup("[red] Exiting ....... [/]");
                    Thread.Sleep(1000);
                    return;
                }

                PhonebookService.PerformOperation(opt);
            }

        }

        internal int UpdateMenuChoice()
        {
            string choice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("[blue]UPDATE MENU[/]")
                .PageSize(5)
                .AddChoices(new[]
                {
                    "[springgreen2]1. Update Contact Name[/]", "[springgreen2]2. Update Contact Number[/]", "[springgreen2]3. Update Email Id[/]","[springgreen2]4. Update Category[/]","[red]5. Back to Main Menu[/]"
                }));

            int opt = int.Parse(choice.Substring(choice.IndexOf(']') + 1, 1));

            return opt;
        }

        internal string GetEmail()
        {
            string email;
            while (true)
            {
                Console.Write("Enter Contact email: ");
                email = Console.ReadLine();
                if (validation.IsValidEmail(email))
                {
                    break;
                }
            }
            return email;
        }

        public int GetId()
        {
            int id;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    AnsiConsole.Markup("[red]Enter integer[/]\n");
                    Console.Write("Enter again: ");
                }
                break;
            }
            return id;
        }

        internal string GetNumber()
        {
            string phoneNumber;
            while (true)
            {
                phoneNumber = Console.ReadLine();
                if (validation.IsValidNumber(phoneNumber))
                {
                    break;
                }
                Console.Write("Enter Contact Number (10 digits): ");
            }
            return phoneNumber;
        }

        internal string GetText()
        {
            string name;
            while (true)
            {
                name = Console.ReadLine();
                if (validation.IsValidName(name))
                {
                    break;
                }
                Console.Write("Enter Contact Name: ");
            }
            return name.Substring(0, 1).ToUpper() + name.Substring(1);  
        }

        
    }
}
