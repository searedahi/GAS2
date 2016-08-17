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
            byte[] resultBytes = {};

            using (wc)
            {
                resultBytes = wc.DownloadData("https://localhost:44364/");
            }

            Assert.IsNotNull(wc);
            Assert.IsNotNull(resultBytes);

        }
    }
}
