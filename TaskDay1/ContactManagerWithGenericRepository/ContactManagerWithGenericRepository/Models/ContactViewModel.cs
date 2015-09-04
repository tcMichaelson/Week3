using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagerWithGenericRepository.Models {
    public class ContactViewModel {
        public IList<Contact> Contacts { get; set; }
        public int TotalContacts { get; set; }
        public int CurrentPage { get; set; }
    }
}