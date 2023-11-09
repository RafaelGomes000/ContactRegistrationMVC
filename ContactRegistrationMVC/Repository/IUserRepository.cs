using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository
{
    public interface IUserRepository
    {
        UserModel FindByLogin(string login);
        UserModel ListId(int id);
        List<UserModel> GetAll();
        UserModel Create(UserModel user);
        UserModel Update(UserModel user);
        bool Delete(int id);
    }
}
