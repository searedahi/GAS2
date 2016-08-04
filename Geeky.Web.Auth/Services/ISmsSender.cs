using System.Threading.Tasks;

namespace Geeky.Web.Auth.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
