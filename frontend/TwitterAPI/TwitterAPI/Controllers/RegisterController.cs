using DBContext;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwitterAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _IRegisterService;
        public RegisterController(IRegisterService registerService)
        {
            _IRegisterService = registerService;

        }
        // GET: api/<RegisterController>
        [HttpGet, Route("api/Register/LoginUser/")]
        public bool LoginUser(Login login)
        {
            if (_IRegisterService.UserLogin(login))
            {
                return true;
            }
            return false;
        }
        [HttpGet, Route("api/Register/ForgetPassword/")]
        public string ForgetPassword(string email)
        {
          return  _IRegisterService.ForgetPassword(email);
        }

        [HttpPost, Route("api/Register/RegisterUsers/")]

        public bool RegisterUsers(Register student)
        {
            if (_IRegisterService.UserRegister(student))
            {
                return true;
            }
            return false;

        }


        [HttpPatch, Route("api/Register/ChangePassword/")]
        public bool ChangePassword(ChangePassword changePassword)
        {
            if (_IRegisterService.ChangePassword(changePassword))
            {
                return true;
            }

            return false;
        }

       
        [HttpPost, Route("api/Register/TwitterMessage/")]

        public bool TwitterMessage(string data)
        {
            if (_IRegisterService.UserTweet(data))
            {
                return true;
            }
            return false;

        }

        [HttpGet, Route("api/Register/TwitterUsers")]

        public IEnumerable<string> TwitterUsers()
        {
            return _IRegisterService.GetTwitterUsers();
        }

        [HttpDelete, Route("api/Register/AccountDelete/{id}")]
        public bool AccountDelete(int id)
        {
            if (_IRegisterService.DeleteUserAccount(id))
            {
                return true;
            }

            return false;
        }


        [HttpPut, Route("api/Register/ChangeUsername/")]
        public bool ChangeUsername(ChangeUser name)
        {
            if (_IRegisterService.UserNameUpdation(name))
            {
                return true;
            }

            return false;
        }

    }
}
