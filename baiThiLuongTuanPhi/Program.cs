using System;
using System.Collections;

class Contact
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public Contact(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
}

class ContactManager
{
    private Hashtable contacts = new Hashtable();

    public void AddContact(string name, string phone)
    {
        Contact contact = new Contact(name, phone);
        contacts[name] = contact;
    }

    public void FindContact(string name)
    {
        if (contacts.ContainsKey(name))
        {
            Contact contact = (Contact)contacts[name];
            Console.WriteLine($"Phone number of {name} is {contact.Phone}");
        }
        else
        {
            Console.WriteLine("Not found");
        }
    }

    public void DisplayContacts()
    {
        Console.WriteLine("Address Book");
        Console.WriteLine("{0,-20} {1,-15}", "Contact Name", "Phone number");
        foreach (DictionaryEntry entry in contacts)
        {
            Contact contact = (Contact)entry.Value;
            Console.WriteLine("{0,-20} {1,-15}", contact.Name, contact.Phone);
        }
    }
}

class Program
{
    static void Main()
    {
        ContactManager contactManager = new ContactManager();
        int choice;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add new contact");
            Console.WriteLine("2. Find a contact by name");
            Console.WriteLine("3. Display contacts");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter phone: ");
                    string phone = Console.ReadLine();
                    contactManager.AddContact(name, phone);
                    break;
                case 2:
                    Console.Write("Enter name to find: ");
                    name = Console.ReadLine();
                    contactManager.FindContact(name);
                    break;
                case 3:
                    contactManager.DisplayContacts();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        } while (choice != 4);
    }
}
