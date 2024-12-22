using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shirt_api.Models;
using shirt_api.Models.Repositories;
using shirt_api.Models.Filters;

namespace shirt_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {



        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {

            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId}, shirt);
        }


        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        public IActionResult UpdateShirt(int id,Shirt shirt)
        {
            // if(id != shirt.ShirtId) return BadRequest();

            try
            {
                ShirtRepository.ModifyShirt(shirt);
            }
            catch
            {
                if(!ShirtRepository.ShirtExists(id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);

            ShirtRepository.RemoveShirt(id);

            return Ok(shirt);
        }
    }
}
