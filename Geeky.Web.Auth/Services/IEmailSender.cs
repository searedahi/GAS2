using System.Threading.Tasks;

namespace Geeky.Web.Auth.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
