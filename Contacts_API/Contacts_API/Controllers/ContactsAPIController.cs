using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Contacts_API.Data;
using Contacts_API.Models;

namespace Contacts_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ContactsAPIdbContext _context;

        public HotelBookingController(ContactsAPIdbContext context)
        {
            _context = context;
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

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Contacts booking)
        {
            if (booking.Id == 0)
            {
                _context.Contacts.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Contacts.Find(booking.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));

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