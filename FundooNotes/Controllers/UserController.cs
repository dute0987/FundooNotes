using Businness_Layer.Interfaces;
using Common_Layer.Users;
using Microsoft.AspNetCore.Mvc;
using Repositary_Layer.FundooContext;
using System;
using System.Linq;

namespace FundooNotes.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        FundooContextDB fundooContext;
        IUserBL userBL;

        //public string Password { get; private set; }

        public UserController(FundooContextDB fundoos ,IUserBL userBL)
        {
            this.fundooContext = fundoos;
            this.userBL = userBL;
        }

        //public string Password { get; private set; }

        [HttpPost("Register")]

        public ActionResult AddUser(UserPostModel user)
        {
            try
            {
                this.userBL.AddUser(user);
                return this.Ok(new {success = true, message = $"User Added Successful " });

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("Login")]

        public ActionResult LoginUser( string Email,string Passward)
        {
            try
            {
                var userdata = fundooContext.User.FirstOrDefault(u => u.Email == Email && u.Password == Passward);
                if (userdata == null)
                {
                    return this.BadRequest(new { Success = false, message = $"Email and Password Invalid. " });
                }
               var check= this.userBL.LoginUser(Email,Passward);

                return this.Ok(new { success = true, message = $"User login Successful{check} " });

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = this.userBL.ForgetPassward(email);
                if (result != false)
                {
                    return this.Ok(new
                    {
                        success = true,
                        message = $"Mail Sent Successfully " +
                        $" token:  {result}"
                    });

                }
                return this.BadRequest(new { success = false, message = $"mail not sent" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

