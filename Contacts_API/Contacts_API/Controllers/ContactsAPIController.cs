using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contacts_API.Data;
using Contacts_API.Models;

namespace Contacts_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsAPIdbContext _context;

        public ContactsController(ContactsAPIdbContext context)
        {
            _context = context;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult createAndEdit(Contacts contacts)
        {
            if (contacts.Id == 0)
            {
                _context.Contacts.Add(contacts);
            }
            else
            {
                var contactsInDb = _context.Contacts.Find(contacts.Id);

                if (contactsInDb == null)
                    return new JsonResult(NotFound());

                contactsInDb = contacts;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(contacts));

        }


        // Get all
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result = _context.Contacts.ToList();

            return new JsonResult(Ok(result));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Contacts.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

 



        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Contacts.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Contacts.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }


    }
}