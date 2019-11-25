using System;
using Microsoft.AspNetCore.Mvc;
using FoodHub.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FoodHub.Controllers
{
    public class DisplayController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public DisplayController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult UpdateOrderStatus(long OrderId, long MenuId, long StatusId)
        {
            var orderItem = _context.OrderItems.SingleOrDefault(x => x.Id == OrderId && x.MenuId == MenuId);
            
            try
            {
                if (orderItem != null)
                {
                    orderItem.OrderStatusId = StatusId;
                    _context.SaveChanges();
                    return Ok();
                } else
                {
                    return NotFound();
                }
            } 
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetOrder() 
        {
            var orders = _context.OrderInformations.Include(x => x.OrderItems)
                                                     .ThenInclude(x => x.Menu)
                                                 .Where(x => !x.IsFinished)
                                                 .Select(x => new DisplayOrder
                                                 {
                                                     Id = x.Id,
                                                     Name = x.Name,
                                                     OrderDateTime = x.OrderDateTime,
                                                     IsFinished = x.IsFinished,
                                                     Location = x.Location,
                                                     Menus = x.OrderItems.Select(y => new DisplayMenu
                                                     {
                                                         Id = y.Id,
                                                         Name = y.Menu.Name,
                                                         Quantity = y.Quantity
                                                     }).ToList()
                                                 });

            return Ok(orders);
        }
    } 
}