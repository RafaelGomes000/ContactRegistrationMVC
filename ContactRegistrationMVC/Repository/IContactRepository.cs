using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository
{
    public interface IContactRepository
    {
        ContactModel ListId(int id);
        List<ContactModel> GetAll(int userId);
        ContactModel Create(ContactModel contact);
        ContactModel Update(ContactModel contact);
        bool Delete(int id);
    }
}
