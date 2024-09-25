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

        internal string GetNumber()
        {
            string phoneNumber;
            while (true)
            {
                Console.Write("Enter Contact Number (10 digits): ");
                phoneNumber = Console.ReadLine();
                if (validation.IsValidNumber(phoneNumber))
                {
                    break;
                }
            }
            return phoneNumber;
        }

        internal string GetText()
        {
            string name;
            while (true)
            {
                Console.Write("Enter Contact Name: ");
                name = Console.ReadLine();
                if (validation.IsValidName(name))
                {
                    break;
                }
            }
            return name.Substring(0, 1).ToUpper() + name.Substring(1);  
        }
    }
}
