﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactList
{
    public class Methods : Contact
    {
        public int input;
        public List<Contact> ListOfContacts = new List<Contact>();



        public void InputOption()
        {
            if (!Int32.TryParse(Console.ReadLine(), out input) || input > 4 || input < 0)
            {
                Console.WriteLine("Error, Please input valid option");
                InputOption();
            }
            ChooseOption();
        }

        public void ShowMenu()
        {
            Console.WriteLine("Please Choose an Option:");
            Console.WriteLine("1.Add Contact");
            Console.WriteLine("2.View All Contacts");
            Console.WriteLine("3.Search Conatcts");
            Console.WriteLine("4.Exit\n");
            InputOption();
        }
        public Contact AddContact()
        {
            Contact newContact = new Contact();

            Console.Write("Enter Contacts Name: ");
            newContact.Name = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(newContact.Name))
            {
                Console.WriteLine("Name is Empty. Try Again.\nEnter Contacts Name: ");
                newContact.Name = Console.ReadLine().Trim();
            }

            Console.Write("Enter Contacts Number: ");
            newContact.PhoneNumber = Console.ReadLine();

            while (string.IsNullOrEmpty(newContact.PhoneNumber) || newContact.PhoneNumber.Length != 9)
            {
                Console.Write("Phone Number is incorrect. Try Again. \nEnter Contacts Number:");
                newContact.PhoneNumber = Console.ReadLine();
            }

            Console.Write("Enter Contacts Email: ");
            newContact.Email = Console.ReadLine().Trim();

            while (!EmailIsValid(newContact.Email))
            {
                Console.Write("Email is not valid. Try Again.\nEnter Contacts Email: ");
                newContact.Email = Console.ReadLine().Trim();
            }

            ListOfContacts.Add(newContact);

            return newContact;
        }
        public bool EmailIsValid(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        public void ViewAllContacts()
        {
            foreach (Contact contact in ListOfContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone Number: {contact.PhoneNumber}, Email: {contact.Email}");
            }
            if (ListOfContacts == null || ListOfContacts.Count == 0)
            {
                Console.WriteLine("There are no contacts. \n");
                ShowMenu();
            }
        }


        public void SearchContact()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine().ToLower();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Error, Try Again:");
                name = Console.ReadLine();
            }

            Console.WriteLine("\n Searching... \n");

            var searchResult = ListOfContacts.Where(c => c.Name.ToLower() == name);

            if (searchResult.Count() == 0)
            {
                Console.WriteLine("Error, try again.");
            }
            foreach(Contact contact in searchResult)
            {
                Console.WriteLine($"Name: {contact.Name}, Number : {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }

        public void ChooseOption()
        {
            if (input == 1)
            {
                AddContact();
            }
            else if (input == 2)
            {
                ViewAllContacts();
            }
            else if (input == 3)
            {
                SearchContact();
            }
        }
    }
}
