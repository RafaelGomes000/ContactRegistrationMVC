using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactRegistrationMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public UserModel FindByLogin(string login)
        {
            return _dataContext.User.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel FindByEmailAndLogin(string email, string login)
        {
            return _dataContext.User.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel ListId(int id)
        {
            return _dataContext.User.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetAll()
        {
            return _dataContext.User
                .Include(x => x.Contacts)
                .ToList();
        }

        public UserModel Create(UserModel user)
        {
            user.RegistrationDate = DateTime.Now;
            user.SetPasswordHash();
            _dataContext.User.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public UserModel Update(UserModel user)
        {
            var userDB = ListId(user.Id);

            if (userDB == null) throw new System.Exception("ID not found!");

            userDB.Name = user.Name;
            userDB.Email = user.Email;
            userDB.Login = user.Login;
            userDB.Profile = user.Profile;
            userDB.UpdateDate = DateTime.Now;

            _dataContext.Update(userDB);
            _dataContext.SaveChanges();
            return userDB;
        }

        public UserModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            UserModel userDB = ListId(changePasswordModel.Id);

            if (userDB == null) throw new Exception("An error occurred, user not found!");

            if (!userDB.PasswordIsValid(changePasswordModel.CurrentPassword)) throw new Exception("An error occurred, current password does not match!");

            if(userDB.PasswordIsValid(changePasswordModel.NewPassword)) throw new Exception("An error occurred, new password must be different!");

            userDB.SetNewPassword(changePasswordModel.NewPassword);
            userDB.UpdateDate= DateTime.Now;

            _dataContext.User.Update(userDB);
            _dataContext.SaveChanges();

            return userDB;
        }

        public bool Delete(int id)
        {
            var userDB = ListId(id);

            if (userDB == null) throw new System.Exception("ID not found!");

            _dataContext.User.Remove(userDB);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
