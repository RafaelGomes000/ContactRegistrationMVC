using ContactRegistrationMVC.Data;
using ContactRegistrationMVC.Models;
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

        public UserModel ListId(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetAll()
        {
            return _dataContext.Users.ToList();
        }

        public UserModel Create(UserModel user)
        {
                user.RegistrationDate = DateTime.Now;
                _dataContext.Users.Add(user);
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
            userDB.UpdateDate = DateTime.Now;

            _dataContext.Update(userDB);
            _dataContext.SaveChanges();
            return userDB;
        }

        public bool Delete(int id)
        {
            var userDB = ListId(id);

            if (userDB == null) throw new System.Exception("ID not found!");

            _dataContext.Users.Remove(userDB);
            _dataContext.SaveChanges();

            return true;
        }
    }
}
