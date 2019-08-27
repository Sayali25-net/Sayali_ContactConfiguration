using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactConfiguration.Models;
using ContactConfiguration.Repositories;

namespace ContactConfiguration.Tests.Models
{
    public class TestContactRepository : IContactPersonRepository
    {
        private List<Contact> testlist = new List<Contact>();
        public void DeleteContact(int ID)
        {
            testlist.Remove(GetContactById(ID));
        }

        public Contact GetContactById(int ID)
        {
            return testlist.FirstOrDefault(n => n.ID == ID);
        }

        public List<Contact> GetContacts()
        {
            return testlist.ToList();
        }

        public void InsertContact(Contact contact)
        {
            testlist.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            foreach (Contact con in testlist)
            {
                if (con.ID == contact.ID)
                {
                    testlist.Remove(con);
                    testlist.Add(contact);
                    break;
                }
            }
        }
    }
}
