using System.ComponentModel.DataAnnotations;

namespace MSSQLWebAPI.Models
{
    public class DeviceLocation
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long id { get; set; }
        [Required, MaxLength(100)]
        public string imei { get; set; }
        [Required]
        public double latitude { get; set; }
        [Required]
        public double longitude { get; set; }
    }
}
