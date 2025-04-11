using DewiAPI.Models;
using DewiAPI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DewiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly DewiContext _context;
        private readonly IEmailService _emailService;
        public ContactController(DewiContext context,IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        [HttpPost("InsertContact")]
        public IActionResult InsertContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact); 
                _context.SaveChanges();
                var status = _emailService.SendEmail(contact);
                return Ok(status);
            }
            return Ok();
        }
    }
}
