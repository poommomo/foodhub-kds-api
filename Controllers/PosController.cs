using Microsoft.AspNetCore.Mvc;
using FoodHub.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FoodHub.Controllers
{
    [Route("api/pos")]
    [ApiController]
    public class PosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/pos/menus
        [HttpGet]
        public  IEnumerable<Menu> GetMenu() 
        {
            var menus = _context.Menus.ToList();

            return  menus;
        }

    }
}