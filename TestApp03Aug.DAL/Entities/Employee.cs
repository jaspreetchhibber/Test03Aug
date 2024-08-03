using System.ComponentModel.DataAnnotations;

namespace TestApp03Aug.DAL.Entities
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
