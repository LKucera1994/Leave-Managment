using Microsoft.AspNetCore.Identity;

namespace Leave_Managment.Data
{
    public class Employee : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string TaxId { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateJoined { get; set; }




    }
}
