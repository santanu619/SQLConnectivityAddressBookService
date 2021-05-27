using AddressBookService;
using System;

namespace EmployeePayrollService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook Management System!");
            AddressBookRepo repo = new AddressBookRepo();
            Contact contact = new Contact();
            contact.FirstName = "Santanu";
            contact.LastName = "Mohapatra";
            contact.Address = "Block-C,Chandrama Complex";
            contact.City = "Bhubaneswar";
            contact.State = "Odisha";
            contact.Zip = "751001";
            contact.PhoneNumber = "6294476694";
            contact.Email = "mohapatra.santanu123@gmail.com";
            contact.Type = "Family";
            if (repo.AddContact(contact))
                Console.WriteLine("Records added successfully");
            repo.GetAllData();
            Console.ReadKey();
        }


    }
}