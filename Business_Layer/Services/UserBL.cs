using Businness_Layer.Interfaces;
using Common_Layer.Users;
using CommonLayer;
using RepositaryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businness_Layer.Services
{
    public class UserBL : IUserBL

    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void AddUser(UserPostModel user)
        {
            try
            {
                this.userRL.AddUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string LoginUser(string Email, string Passward)
        {
            try
            {
                return this.userRL.LoginUser(Email, Passward);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ForgetPassward(string Email)
        {
            try
            {
                return this.userRL.ForgetPassward(Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool changePassward(changePasswardModel changePassward, string Email)
        {
            try
            {
                return this.userRL.changePassward(changePassward,Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
