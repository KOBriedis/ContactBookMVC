using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactBookWeb.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DisplayName("Phone Number")]
        public int PhoneNumber { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
