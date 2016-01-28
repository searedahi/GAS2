using System;
using System.Net;
using Geeky.Master.Testing.Tooling;
using Geeky.Models.Base.ViewModels.Account;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Geeky.Master.Testing
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Register_PositivePath()
        {
            var targetUrl = "http://localhost:51138/account/register";

            var regModel = new RegisterViewModel
            {
                Password = "P@$$worD",
                ConfirmPassword = "P@$$worD",
                PhoneNumber = "1234567890",
                UserName = RandomGenerator.UserName()
            };


            var strData = "{'Email':'testUserNameRKBW1YNX @defaultEmailRKBW1YNX.com','UserName':'testUserNameRKBW1YNX','PhoneNumber':'1234567890','Password':'P@$$worD','ConfirmPassword':'P@$$worD'}";

            regModel.Email = RandomGenerator.Email(regModel.UserName);

            var data = JsonConvert.SerializeObject(regModel);

            var resp = GeekyRestCalls.HttpPost(targetUrl, strData);
            
            Assert.IsNotNull(resp, "Register MVC Post is null.");

        }

        [TestMethod]
        public void Login_PositivePath()
        {
            var targetUrl = "http://localhost:51138/account/login";

            var token = GeekyRestCalls.GetAntiforgeryToken(targetUrl);

            var model = new LoginViewModel
            {
                Password = "Azsxdc12#",
                UserName = "searedahi",
                __RequestVerificationToken = token
            };

            var data = JsonConvert.SerializeObject(model);
            
            var resp = GeekyRestCalls.HttpPost(targetUrl, data);

            Assert.IsNotNull(resp, "Register MVC Post is null.");

        }
    }
}
