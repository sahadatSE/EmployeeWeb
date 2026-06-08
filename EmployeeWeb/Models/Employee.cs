using System.ComponentModel.DataAnnotations;

namespace EmployeeWeb.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; } 

        [Required]
        [StringLength(100)]
        public string? LastName { get; set; } 

        [Required]
        [StringLength(100)]
        public string?   Position { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}