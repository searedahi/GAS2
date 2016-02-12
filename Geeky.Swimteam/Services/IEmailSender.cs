using System.Threading.Tasks;

namespace Geeky.Swimteam.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
