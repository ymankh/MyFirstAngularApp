using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAngularApp.Server.DTOs.SubscriptionDTOs
{
    public class CreateSubscriptionDto
    {
        public string Plan { get; set; }
        public int SubServiceID { get; set; }
        public int CustomUserId { get; set; }
    }
}