using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactConfiguration.Models;

namespace ContactConfiguration.Repositories
{
    public interface IContactPersonRepository
    {
         List<Contact> GetContacts();
        void InsertContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int ID);
        Contact GetContactById(int ID);
      

    }
}
