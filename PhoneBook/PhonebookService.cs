
namespace PhoneBook
{
    public class PhonebookService
    {
        public static void PerformOperation(int opt)
        {
            Console.Clear();
            UserInput userInput = new();
            PhonebookRepositiory repo = new();

            if (opt == 1)
            {
                string name = userInput.GetText();
                string number = userInput.GetNumber();
                string email = userInput.GetEmail();
                repo.AddContact(name, number, email);
            }

            Console.Clear() ;
            return;
        }
    }
}
