using System.ComponentModel.DataAnnotations;

namespace BSVEFCore.Models
{
    public class Department
    {
        [Key]
        public Guid D_Id { get; set; }
        [Required]
        public string? D_Name { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
