using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geeky.Web.Auth.Test
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void LoginWorking()
        {

            var wc = new WebClient();
            //byte[] resultBytes = {};
            var resultBytes = "";

            using (wc)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                resultBytes = wc.DownloadString("https://localhost:44364/api/home");
            }

            Assert.IsNotNull(wc);
            Assert.IsNotNull(resultBytes);
        }
    }
}
