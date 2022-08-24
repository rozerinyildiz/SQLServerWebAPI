using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSSQLWebAPI.Models
{
    [Table("User")]
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long customerID { get; set; }
        [Required, MaxLength(100)]
        public string email { get; set; }
        [Required, MaxLength(100)]
        public string password { get; set; }
        [Required, MaxLength(100)]
        public string salt { get; set; }
    }
}
