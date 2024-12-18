using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shirt_api.Models;


namespace shirt_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        private List<Shirt> shirts = new List<Shirt>
        {
            new Shirt { ShirtId = 1, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 30, Size = 10},
            new Shirt { ShirtId = 2, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 35, Size = 12},
            new Shirt { ShirtId = 3, Brand = "Your Brand", Color = "Pink", Gender = "Women", Price = 28, Size = 8},
            new Shirt { ShirtId = 4, Brand = "Your Brand", Color = "Yellow", Gender = "Women", Price = 30, Size = 9}
        };

        [HttpGet]
        public string GetShirts()
        {
            return "Reading all shirts.";
        }

        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id)
        {
            
            var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);



            if(shirt == null)
            {
                return NotFound();
            }

            return Ok(shirt);
        }

        [HttpPost]
        public string CreateShirt([FromBody] Shirt shirt)
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
