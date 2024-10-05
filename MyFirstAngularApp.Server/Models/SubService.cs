using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyFirstAngularApp.Server.Models
{
    public class SubService
    {
        [Key]
        public int SubServiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string SubServiceName { get; set; }
        public string? SubServiceImagePath { get; set; }


        [StringLength(500)]
        public string SubServiceDescription { get; set; }

        public string SubServiceImage { get; set; }

        // Foreign key reference to Service
        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        // Navigation property to Service
        public Service Service { get; set; }
    }
}
