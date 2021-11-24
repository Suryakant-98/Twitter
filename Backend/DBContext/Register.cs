using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext
{
    //creating a class
   public class Register
    {
        //declared properties
    
        public string UserName { set; get; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
       
    }
    public class ChangePassword
    {
        public string EmailID { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
   
    public class ChangeUser
    {
        public string EmailID { get; set; }
        public string ChangeUserName { set; get; }
        

    }
    
}
