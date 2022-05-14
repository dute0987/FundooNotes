using Common_Layer.Users;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositaryLayer.Interface
{
    public interface IUserRL
    {
        public void AddUser(UserPostModel user);
        public string LoginUser(string Email, string Passward);
        public bool ForgetPassward(string Email);
        public bool changePassward(changePasswardModel changePasswardModel,string Email);
        
    }
}
