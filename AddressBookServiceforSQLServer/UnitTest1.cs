using AddressBookService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AddressBookServiceforSQLServer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
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
            var result = repo.AddContact(contact);
            Assert.IsTrue(result);
        }
    }
}
