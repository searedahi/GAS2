using System.Linq;
using HtmlAgilityPack;

namespace Geeky.Master.Testing.Tooling
{
    public class GeekyRestCalls
    {
        public static string HttpPost(string uri, string parameters, string token = "")
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);

            //Add these, as we're doing a POST
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            if (!string.IsNullOrEmpty(token))
            {
                req.Headers.Add("__RequestVerificationToken", token);
            }
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parameters);
            req.ContentLength = bytes.Length;

            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();

            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }


        public static string HttpGet(string uri)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(uri);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }

        public static string GetAntiforgeryToken(string uri)
        {
            var resp = HttpGet(uri);
            var doc = new HtmlDocument();
            doc.LoadHtml(resp);

            var input = doc.DocumentNode
                .Descendants("input")
                .FirstOrDefault(n => n.Attributes["name"] != null && n.Attributes["name"].Value == "__RequestVerificationToken");

            var val = input.Attributes["value"].Value;
            return val;
        }
    }



}
