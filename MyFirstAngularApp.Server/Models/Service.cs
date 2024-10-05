using System.ComponentModel.DataAnnotations;

namespace MyFirstAngularApp.Server.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }
        public string? ServiceImagePath { get; set; }

        [StringLength(500)]
        public string ServiceDescription { get; set; }

        public string ServiceImage { get; set; }

        // Navigation property to SubServices
        public ICollection<SubService> SubServices { get; set; }
    }
}
