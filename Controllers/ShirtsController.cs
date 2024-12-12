using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace shirt_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        [HttpGet]
        public string GetShirts()
        {
            return "Reading all shirts.";
        }

        [HttpGet("{id}")]
        public string GetShirtById(int id, [FromQuery] string? color)
        {
            return $"Reading shirt with ID: {id}, color: {color}";
        }

        [HttpPost]
        public string CreateShirt()
        {
            return "Creating a shirt";
        }

        [HttpPut("{id}")]
        public string UpdateShirt(int id)
        {
            return $"Updating shirt with ID: {id}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleting shirt with ID: {id}";
        }
    }
}
