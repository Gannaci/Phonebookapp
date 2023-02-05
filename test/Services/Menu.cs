using Newtonsoft.Json;
using test.Models;

namespace test.Services
{
    public class Menu
    {
        static List<ContactCreate> contacts = new List<ContactCreate>();
        static string jsonFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\contacts.json";

        static void Main(string[] args)
        {
            Console.Clear();
            if (File.Exists(jsonFile))
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                contacts = JsonConvert.DeserializeObject<List<ContactCreate>>(File.ReadAllText(jsonFile));
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            while (true)
            {
                Console.WriteLine("Välkommen till adressboken");

                Console.WriteLine("1. Skapa en kontakt");
                Console.WriteLine("2. Visa alla kontakter");
                Console.WriteLine("3. Visa en specifik kontakt");
                Console.WriteLine("4. Ta bort en kontakt");
                Console.WriteLine("5. Stäng ner");
                Console.WriteLine("Välj ett alternativ ovan för att köra programmet");

                int choice = int.Parse(Console.ReadLine() ?? string.Empty);
                switch (choice)
                {
                    case 1:
                        CreateContact();
                        break;
                    case 2:
                        ShowAllContacts();
                        break;
                    case 3:
                        ShowSpecificContact();
                        break;
                    case 4:
                        RemoveSpecificContact();
                        break;
                    case 5:
                        CloseDown();
                        break;
                }
            }
        }

        static void CreateContact()
        {
            Console.Clear();
            Console.WriteLine("Skapa en kontakt");

            ContactCreate contact = new ContactCreate();
            Console.Write("Förnamn: ");
            contact.FirstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Efternamn: ");
            contact.LastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Epost adress: ");
            contact.Email = Console.ReadLine() ?? string.Empty;
            Console.Write("Telefonnummer: ");
            contact.PhoneNumber = Console.ReadLine() ?? string.Empty;
            Console.Write("Adress: ex Storgatan 2, 70210 Örebro: ");
            contact.Address = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Kontakten är skapad");

            contacts.Add(contact);
            File.WriteAllText(jsonFile, JsonConvert.SerializeObject(contacts));

            Console.WriteLine("Tryck på valfri tanget för att komma vidare");
            Console.ReadLine();
            Console.Clear();
        }

        static void ShowAllContacts()
        {
            Console.Clear();
            Console.WriteLine("Visa alla kontakter");

            foreach (ContactCreate contact in contacts)
            {
                Console.WriteLine($"Förnamn: {contact.FirstName} \nEfternamn: {contact.LastName} \nEpost adress: {contact.Email}");
            }
            Console.WriteLine("Tryck på valfri tanget för att komma vidare");
            Console.ReadLine();
            Console.Clear();
        }

        static void ShowSpecificContact()
        {
            Console.Clear();
            Console.WriteLine("Visa en specifik kontakt");

            Console.Write("Sök på en Epost adress: ");
            string email = Console.ReadLine() ?? string.Empty;
            var contact = contacts.Find(x => x.Email == email);
            if (contact != null)
            {
                Console.WriteLine($"Förnamn: {contact.FirstName} \nEfternamn: {contact.LastName} \nEpost adress: {contact.Email} \nTelefonnummer: {contact.PhoneNumber} \nAdress: {contact.Address}");
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte.");
            }
            Console.WriteLine("Tryck på valfri tanget för att komma vidare");
            Console.ReadLine();
            Console.Clear();
        }

        static void RemoveSpecificContact()
        {
            Console.Clear();
            Console.WriteLine("Ta bort en specifik kontakt");
            Console.Write("Sök på en epost adress. ");
            string email = Console.ReadLine() ?? string.Empty;
            var contact = contacts.Find(x => x.Email == email);
            if (contact != null)
            {
                Console.WriteLine($"Är du säker på att du vill ta bort kontakten med e-postadressen {email}? y / n");

                string userInput = Console.ReadLine() ?? string.Empty;
                if (userInput.ToLower() == "y")
                {
                    contacts.Remove(contact);
                    Console.WriteLine("Kontakten togs bort.");
                }
                else
                {
                    Console.WriteLine("Kontakten togs inte bort.");
                }
            }
            else
            {
                Console.WriteLine("Kontakten hittades inte");
            }
            Console.WriteLine("Tryck på valfri tanget för att komma vidare");
            Console.ReadLine();
            Console.Clear();
        }
        static void CloseDown()
        {
            Console.Clear();
            Console.WriteLine("Stänger ner");
            Environment.Exit(0);
        }
    }
}
