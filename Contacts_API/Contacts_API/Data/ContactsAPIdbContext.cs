using Microsoft.EntityFrameworkCore;
using Contacts_API.Models;


namespace Contacts_API.Data
{

    public class ContactsAPIdbContext: DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }

        public ContactsAPIdbContext(DbContextOptions<ContactsAPIdbContext> options):base (options) { }
    }

}
