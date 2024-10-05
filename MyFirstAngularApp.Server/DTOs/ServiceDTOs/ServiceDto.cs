using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAngularApp.Server.DTOs.ServiceDTOs
{
    public class CreateServiceDto
    {
        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public IFormFile ServiceImage { get; set; }

        // Navigation property to SubServices
    }
}