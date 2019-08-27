using ContactConfiguration.Controllers;
using ContactConfiguration.Models;
using ContactConfiguration.Repositories;
using ContactConfiguration.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContactConfiguration.Tests.Controllers
{
    [TestClass]
    public class ContactControllerTest
    {

        [TestMethod]
        public void Index()
        {
            var contactcontroller = GetContactController(new TestContactRepository());

            ViewResult result = contactcontroller.Index();
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }



        private static ContactPersonController GetContactController(IContactPersonRepository emprepository)
            {
                ContactPersonController contactcontroller = new ContactPersonController(emprepository);
                contactcontroller.ControllerContext = new ControllerContext()
                {
                    Controller = contactcontroller,
                   
                };
                return contactcontroller;
            }

              
            [TestMethod]
            public void GetContacts()
            {
                 
                Contact contact1 = GetContactDetails("Neha", "Sahani", "nehasa@live.com", "9769854350", true);
                Contact contact2 = GetContactDetails("Rupali", "Saxena", "rupalisaxena@live.com", "9769854980", true);
                TestContactRepository testrepository = new TestContactRepository();
                testrepository.InsertContact(contact1);
                testrepository.InsertContact(contact2);
                var controller = GetContactController(testrepository);
                var result = controller.Index();
                var datamodel = (IEnumerable<Contact>)result.ViewData.Model;
                CollectionAssert.Contains(datamodel.ToList(), contact1);
                CollectionAssert.Contains(datamodel.ToList(), contact2);
            }

        
            Contact GetContactDetails(string FirstName, string LastName, string Email, string PhoneNumber, bool status)
            {
                return new Contact
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    Status = status

                };
            }

          
            [TestMethod]
            public void Create_PostContactInRepository()
            {
                TestContactRepository contactrepository = new TestContactRepository();
                ContactPersonController contactcontroller = GetContactController(contactrepository);
                Contact contact = GetContact();
                contactcontroller.Add(contact);
                IEnumerable<Contact> contacts = contactrepository.GetContacts();
                Assert.IsTrue(contacts.Contains(contact));
            }

               
            Contact GetContact()
            {
                return GetContactDetails("Rahul", "Saxena", "rahulsaxena@live.com", "9769854350", true);
            }



        }



    }

