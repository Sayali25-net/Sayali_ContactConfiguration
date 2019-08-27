using ContactConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactConfiguration.Tests.Model
{
    class TestContactRepsitory :IContactRepository
    {
        private List<Contact> _db = new List<Contact>();

        public Exception ExceptionToThrow
        {
            get;
            set;
        }

        public List<Contact> GetContacts()
        {
            return _db.ToList();
        }

        public Contact GetContactById(int id)
        {
            return _db.FirstOrDefault(d => d.ID == id);
        }

        public void InsertContact(Contact contacttoadd)
        {


            _db.Add(contacttoadd);
        }

        public void DeleteContact(int id)
        {
            _db.Remove(GetContactById(id));
        }


        public void UpdateContact(Contact contacttobeupdated)
        {

            foreach (Contact contacts in _db)
            {
                if (contacts.ID == contacttobeupdated.ID)
                {
                    _db.Remove(contacts);
                    _db.Add(contacttobeupdated);
                    break;
                }
            }
        }

        public int Save()
        {
            return 1;
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //Dispose Object Here    
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
}
