using ContactRegistrationMVC.Models;

namespace ContactRegistrationMVC.Helper
{
    public interface ISession
    {
        void CreateUserSession(UserModel user);
        void RemoveUserSession();
        UserModel FindUserSession();
    }
}
