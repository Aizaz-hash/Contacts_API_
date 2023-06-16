namespace Contacts_API.Models
{

    public class Contacts
    {
        public int Id { get; set; }
        public string fullName { get; set; }

        public string email { get; set; }

        public long phoneNo { get; set; }

        public string address { get; set; }
    }
}
