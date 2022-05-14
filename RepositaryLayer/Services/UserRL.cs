using Common_Layer.Users;
using CommonLayer;
using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositary_Layer.Entities;
using Repositary_Layer.FundooContext;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace Repositary_Layer.Services
{
    public class UserRL : IUserRL
    {
        FundooContextDB fundooContext;
        public IConfiguration configuraion { get; }

        public UserRL(FundooContextDB fundooContext, IConfiguration configuraion)
        {
            this.fundooContext = fundooContext;
            this.configuraion = configuraion;
        }

        public void AddUser(UserPostModel user)
        {
            try
            {
                User userdata = new User();
                userdata.FirstName = user.FirstName;
                userdata.LastName = user.LastName;
                userdata.Email = user.Email;
                userdata.Password = EncryptPassword(user.Password);
                fundooContext.Add(userdata);
                fundooContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string EncryptPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    return null;
                }
                else
                {
                    Byte[] b = Encoding.ASCII.GetBytes(password);
                    string encrypted = Convert.ToBase64String(b);
                    return encrypted;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string LoginUser(string Email, string Passward)
        {
            try
            {
                var user = fundooContext.User.FirstOrDefault(u => u.Email == Email && u.Password == Passward);
                if (user == null)
                {
                    return null;
                }
                return GenerateJWTToken(Email, user.UserID);
            }
            catch (Exception)
            {
                throw;
            }

        }
        private string GenerateJWTToken(string email, int userId)
        {
            //generate token

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),
                    new Claim("userId",userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public bool ForgetPassward(string Email)
        {
            try
            {

                var userdata = fundooContext.User.FirstOrDefault(u => u.Email == Email);
                if (userdata == null)
                {
                    return false;
                }
                MessageQueue queue;

                //Add message to Queue
                if (MessageQueue.Exists(@".\private$\FundooQueue"))
                {
                    queue = new MessageQueue(@".\private$\FundooQueue");
                }
                else
                {
                    queue = MessageQueue.Create(@".\private$\FundooQueue");
                }
                Message Mymessage = new Message();
                Mymessage.Formatter = new BinaryMessageFormatter();
                Mymessage.Body = GenerateJWTToken(Email, userdata.UserID);
                Mymessage.Label = "Forgot Password email";
                queue.Send(Mymessage);

                Message msg = queue.Receive();
                msg.Formatter = new BinaryMessageFormatter();
                EmailService.SendMail(Email, Mymessage.Body.ToString());
                queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmqQueue_ReceiveCompleted);


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void msmqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue queue = (MessageQueue)sender;
                Message msg = queue.EndReceive(e.AsyncResult);
                EmailService.SendMail(e.Message.ToString(), GenerateToken(e.Message.ToString()));
                queue.BeginReceive();

            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.AccessDenied)
                {
                    Console.WriteLine("Access is denied." + "Queue might be a system queue.");
                }
            }
        }
        public string GenerateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),

                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool changePassward(changePasswardModel changePassward, string Email)
        {
            try
            {
                var User = fundooContext.User.FirstOrDefault(u => u.Email ==Email);
                if (changePassward.Passward.Equals(changePassward.conformpassward))
                {

                    User.Password = EncryptPassword(changePassward.conformpassward);
                    fundooContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}




