using System.ComponentModel.DataAnnotations;

namespace Leave_Managment.Models
{
    public class DetailsLeaveTypeViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
    }

    public class CreateLeaveTypeViewModel
    {
        [Required]
        public string Name { get; set; }
        
    }
}
