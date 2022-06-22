namespace Leave_Managment.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string TaxId { get; set; }
        public DateTime dateOfBirth { get; set; }
        public DateTime dateJoined { get; set; }
    }
}
