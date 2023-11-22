using ContactRegistrationMVC.Models;
using System.Collections.Generic;

namespace ContactRegistrationMVC.Repository
{
    public interface IUserRepository
    {
        UserModel FindByLogin(string login);
        UserModel FindByEmailAndLogin(string email, string login);
        UserModel ListId(int id);
        List<UserModel> GetAll();
        UserModel Create(UserModel user);
        UserModel Update(UserModel user);
        UserModel ChangePassword(ChangePasswordModel changePasswordModel);
        bool Delete(int id);
    }
}
