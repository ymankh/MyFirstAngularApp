using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstAngularApp.Server.DTOs.SubscriptionDTOs;
using MyFirstAngularApp.Server.Models;

namespace MyFirstAngularApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController(ApplicationDbContext context) : ControllerBase
    {


        [Authorize]
        [HttpGet("GetSubscriptions")]
        public IActionResult GetSubscriptions()
        {
            var user = GetCurrentUser();
            var subscriptions = context.Subscriptions.Where(s => s.CustomUserId == user.CustomUserId);
            return Ok(subscriptions);
        }
        [Authorize]
        [HttpPost("CreateSubscription")]
        public IActionResult CreateSubscription([FromBody] CreateSubscriptionDto createSubscription)
        {
            var user = GetCurrentUser();
            DateTime endDate;
            switch (createSubscription.Plan.ToLower())
            {
                case "monthly":
                    endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                    break;
                case "annual":
                    endDate = new DateTime(DateTime.Now.Year, 12, 31);
                    break;
                case "weekly":
                    endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 7);
                    break;
                default:
                    return BadRequest("Invalid plan. plan must be one of the following: Monthly, Annual, Weekly");
            }
            var subscription = new Subscription
            {
                CustomUserId = user.CustomUserId,
                Plan = createSubscription.Plan,
                StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                EndDate = endDate,
                SubServiceID = createSubscription.SubServiceID
            };
            context.Subscriptions.Add(subscription);
            context.SaveChanges();
            return Created();
        }
        CustomUser GetCurrentUser()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var user = context.CustomUsers.Find(userId);
            return user;
        }
    }
}