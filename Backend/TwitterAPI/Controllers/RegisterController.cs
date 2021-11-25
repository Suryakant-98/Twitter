using DBContext;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace TwitterAPI.Controllers
{
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _IRegisterService;
        /// <summary>
        /// creating the parameterized constructor 
        /// here parameters are  interfaces       
        /// </summary>
        /// <param name="registerService"></param>
        public RegisterController(IRegisterService registerService)
        {
            _IRegisterService = registerService;

        }
         //create the end point of login api
        [HttpGet, Route("api/Register/LoginUser/")]
        public bool LoginUser(Login login)
        {
            if (_IRegisterService.UserLogin(login))
            {
                return true;
            }
            return false;
        }

        //create the end point of ForgetPassword api
        [HttpGet, Route("api/Register/ForgetPassword/")]
        public string ForgetPassword(string email)
        {
          return  _IRegisterService.ForgetPassword(email);
        }

        //create the end point of ForgetPassword api
        [HttpPost, Route("api/Register/RegisterUsers/")]
        public bool RegisterUsers(Register student)
        {
            if (_IRegisterService.UserRegister(student))
            {
                return true;
            }
            return false;
        }

        //create the end point of ChangePassword api
        [HttpPatch, Route("api/Register/ChangePassword/")]
        public bool ChangePassword(ChangePassword changePassword)
        {
            if (_IRegisterService.ChangePassword(changePassword))
            {
                return true;
            }
            return false;
        }

        //create the end point of TwitterMessage api
        [HttpPost, Route("api/Register/TwitterMessage/")]
        public bool TwitterMessage(string data)
        {
            if (_IRegisterService.UserTweet(data))
            {
                return true;
            }
            return false;
        }

        //create the end point of TwitterMessage api
        [HttpGet, Route("api/Register/TwitterUsers")]
        public IEnumerable<string> TwitterUsers()
        {
            return _IRegisterService.GetTwitterUsers();
        }

        //create the end point of TwitterMessage api
        [HttpDelete, Route("api/Register/AccountDelete/{id}")]
        public bool AccountDelete(int id)
        {
            if (_IRegisterService.DeleteUserAccount(id))
            {
                return true;
            }
            return false;
        }
        //create the end point of TwitterMessage api
        [HttpPut, Route("api/Register/ChangeUsername/")]
        public bool ChangeUsername(ChangeUser name)
        {
            if (_IRegisterService.UserNameUpdation(name))
            {
                return true;
            }
            return false;
        }
        //create the end point of TwitterMessage api
        [HttpGet, Route("api/Register/UploadProfile/")]
        public string UploadProfile()
        {
            return _IRegisterService.ImageChange();
        }
    }
}
