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

        List<ContactModel> IContactRepository.GetAll()
        {
            return _dataContext.Contact.ToList();
        }

        public ContactModel Create(ContactModel contact)
        {
            _dataContext.Contact.Add(contact);
            _dataContext.SaveChanges();
            return contact;
        }
    }
}
