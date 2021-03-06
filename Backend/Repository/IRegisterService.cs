using DBContext;
using System;
using System.Collections.Generic;

namespace Repository
{
    //creating interface
    public interface IRegisterService
    {
        /// <summary>
        /// defining all methods by default it is abstract
        /// </summary>
        
        public bool UserRegister(Register register);

        public List<string> GetTwitterUsers();
        public bool UserLogin(Login login);
        public bool UserTweet(string data);
        public bool ChangePassword(ChangePassword changePassword);
        public bool DeleteUserAccount(int id);
        public bool UserNameUpdation(ChangeUser name);
        public string ImageChange();
        public string ForgetPassword(string email);
    }
}
