using System.ComponentModel.DataAnnotations;

namespace BSVEFCore.Models
{
    public class Employee
    {
        [Key]
        public Guid E_Id { get; set; }
        [Required]
        public string? E_Name { get; set; }
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string? E_Phone { get; set; }
        public Guid D_Id { get; set; }
        public virtual Department? Departments { get; set; }
    }
}
