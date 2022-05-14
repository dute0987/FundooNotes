using Common_Layer.Users;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness_Layer.Interfaces
{
    public interface IUserBL
    {
        public void AddUser(UserPostModel user);
        public string LoginUser(string Email, string Passward);
        public bool ForgetPassward(string Email);
        public bool changePassward(changePasswardModel changePasswardModel, string Email);

    }
}
