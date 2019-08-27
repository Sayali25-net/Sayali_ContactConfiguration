using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using ContactConfiguration.Models;

namespace ContactConfiguration.Repositories
{
    public class ContactRepository : IContactPersonRepository,IDisposable
    {
        [Dependency]
        ContactConfigurationEntities context = new ContactConfigurationEntities();
        public void DeleteContact(int ID)
        {
            Contact contact = context.Contacts.Find(ID);
            context.Contacts.Remove(contact);
            context.SaveChanges();
        }

       

        public Contact GetContactById(int ID)
        {
            return context.Contacts.Find(ID);
        }
        
        public List<Contact> GetContacts()
        {
            return context.Contacts.ToList();
        }

        public void InsertContact(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();


        }

       

        public void UpdateContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}