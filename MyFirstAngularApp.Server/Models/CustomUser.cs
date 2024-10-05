﻿namespace MyFirstAngularApp.Server.Models
{
    public class CustomUser
    {
        public int CustomUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

    }
}
