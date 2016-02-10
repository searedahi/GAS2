using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geeky.Master.Testing.Tooling
{
    public class RandomGenerator
    {


        public static string UserName()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("testUserName{0}",RandomString(8));
            return sb.ToString();
        }

        public static string Email(string userName = "defaultUser")
        {
            var sb = new StringBuilder();
            sb.AppendFormat("{0}@defaultEmail{1}.com", userName,RandomString(8));
            return sb.ToString();
        }


        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
