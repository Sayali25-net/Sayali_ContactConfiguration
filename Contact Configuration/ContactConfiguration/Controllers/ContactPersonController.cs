using ContactConfiguration.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactConfiguration.Repositories;

namespace ContactConfiguration.Controllers
{
    public class ContactPersonController : Controller
    {

        private IContactPersonRepository contactPersonRepository;


        public ContactPersonController(IContactPersonRepository repository)
        {
            this.contactPersonRepository = repository;
        }
        // GET: ContactPerson
        public ViewResult Index()
        {
            var contacts = from contact in contactPersonRepository.GetContacts()
                        select contact;
            return View(contacts);
            
        }
        public ViewResult Details(int id)
        {
            var contacts = contactPersonRepository.GetContactById(id);
                           
            return View(contacts);

        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Contact contactPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contactPersonRepository.InsertContact(contactPerson);
                  
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again");
            }
            return View(contactPerson);
        }


        public ActionResult Edit(int id)
        {
            Contact contactPerson = contactPersonRepository.GetContactById(id);
            return View(contactPerson);
        }
        [HttpPost]
        public ActionResult Edit(Contact contactPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contactPersonRepository.UpdateContact(contactPerson);
              
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again");
            }
            return View(contactPerson);
        }


        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Contact contactPerson = contactPersonRepository.GetContactById(id);
            return View(contactPerson);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Contact contactPerson = contactPersonRepository.GetContactById(id);
                contactPersonRepository.DeleteContact(id);
               
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}