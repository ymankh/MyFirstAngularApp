using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstAngularApp.Server.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionID { get; set; }

        [ForeignKey("SubService")]
        public int SubServiceID { get; set; }

        [ForeignKey("CustomUser")]
        public int CustomUserId { get; set; }

        public CustomUser CustomUser { get; set; }

        public required string Plan { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }

        public SubService SubService { get; set; }
    }
}
