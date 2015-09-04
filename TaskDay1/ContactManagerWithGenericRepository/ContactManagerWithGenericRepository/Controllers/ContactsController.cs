﻿using ContactManagerWithGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManagerWithGenericRepository.Controllers
{
    public class ContactsController : Controller {
        private IRepository _repo;

        public ContactsController(IRepository repo) {
            _repo = repo;
        }

        // GET: Contacts

        public ActionResult Index(int page)
        {
            ContactViewModel vm = new ContactViewModel();
            vm.Contacts = (from m in _repo.Query<Contact>() orderby m.LastName, m.FirstName select m).Skip((page-1) * 25).Take(25).ToList();
            vm.TotalContacts = (from m in _repo.Query<Contact>() select m).Count();
            vm.CurrentPage = page;
            return View(vm);

        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.Find<Contact>(id));
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    _repo.Add<Contact>(contact);
                    _repo.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.Find<Contact>(id));
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                // TODO: Add update logic here

                Contact newContact = _repo.Find<Contact>(id);
                newContact.Id = contact.Id;
                newContact.FirstName = contact.FirstName;
                newContact.LastName = contact.LastName;
                newContact.Birthday = contact.Birthday;
                newContact.PhoneNumber = contact.PhoneNumber;
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.Find<Contact>(id));
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Delete<Contact>(id);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
