using DewiAPI.Models;

namespace DewiAPI.Service
{
    public interface IEmailService
    {
        public bool SendEmail(Contact email);
    }
}
