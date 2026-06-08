using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Position { get; set; } = null!;

        [Required]
        public decimal Salary { get; set; }
    }
}