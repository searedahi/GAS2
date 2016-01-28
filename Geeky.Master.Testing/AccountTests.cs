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

            regModel.Email = RandomGenerator.Email(regModel.UserName);

            var data = JsonConvert.SerializeObject(regModel);

            var resp = GeekyRestCalls.HttpPost(targetUrl, data);
            
            Assert.IsNotNull(resp, "Register MVC Post is null.");

        }
    }
}
