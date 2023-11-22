using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactRegistrationMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dataContext;

        public ContactRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ContactModel ListId(int id)
        {
            return _dataContext.Contact.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> GetAll(int userId)
        {
            return _dataContext.Contact.Where(x => x.UserId == userId).ToList();
        }

        public ContactModel Create(ContactModel contact)
        {
            _dataContext.Contact.Add(contact);
            _dataContext.SaveChanges();
            return contact;
        }

        public ContactModel Update(ContactModel contact)
        {
            var contactDB = ListId(contact.Id);

            if (contactDB == null) throw new System.Exception("ID not found!");

            contactDB.Name = contact.Name;
            contactDB.Email = contact.Email;
            contactDB.Number = contact.Number;

            _dataContext.Update(contactDB);
            _dataContext.SaveChanges();
            return contactDB;
        }

        public bool Delete(int id)
        {
            var contactDB = ListId(id);

            if (contactDB == null) throw new System.Exception("ID not found!");

            _dataContext.Contact.Remove(contactDB);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
