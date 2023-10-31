using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository
{
    public interface IContactRepository
    {
        ContactModel ListId(int id);
        List<ContactModel> GetAll();
        ContactModel Create(ContactModel contact);
    }
}
