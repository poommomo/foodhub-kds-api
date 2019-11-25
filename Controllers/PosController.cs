using Microsoft.AspNetCore.Mvc;
using FoodHub.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Controllers
{
    // [Route("api/pos")]
    // [ApiController]
    public class PosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/pos/menus
        [HttpGet]
        public IActionResult GetMenu() 
        {
            var menus = _context.Menus.ToList();

            if (menus.Any())
            {
                return  Ok(menus);
            } else
            {
                return NoContent();
            }
        }

        [HttpGet]
        public IActionResult GetTable() {
            var tables = _context.Locations.ToList();

            if (tables.Any())
            {
                return Ok(tables);
            } else {
                return NoContent();
            }
        }

        [HttpGet]
        public ActionResult OrderFood() {
            var data = _context.OrderItems.Include(x => x.Menu)
                                          .Where(x => x.Id == 5)
                                          .Select(x => x.Menu);
            return Ok(data);
        }

    }
}