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
        public IActionResult GetPreviousOrder()
        {
            var orders = _context.OrderInformations
                                                    .Where(x => x.IsFinished)
                                                    .Include(x => x.OrderItems)
                                                    .ThenInclude(x => x.Menu)
                                                 .Select(x => new DisplayOrder
                                                 {
                                                     Id = x.Id,
                                                     Name = x.Name,
                                                     OrderDateTime = x.OrderDateTime.AddTicks( - (x.OrderDateTime.Ticks % TimeSpan.TicksPerSecond)),
                                                     IsFinished = x.IsFinished,
                                                     Location = x.Location,
                                                     Menus = x.OrderItems.Select(y => new DisplayMenu
                                                     {
                                                         Id = y.Id,
                                                         Name = y.Menu.Name,
                                                         Quantity = y.Quantity,
                                                         OrderStatus = y.OrderStatus
                                                     }).ToList()
                                                 });

            return Ok(orders);
        }

        [HttpGet]
        public IActionResult UpdateOrderStatus(long OrderId, bool IsFinished)
        {
            var order = _context.OrderInformations.SingleOrDefault(x => x.Id == OrderId);

            try
            {
                if (order != null)
                {
                    order.IsFinished = IsFinished;
                    if (IsFinished) {
                        order.FinishDateTime = DateTime.Now;
                    }
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
        public IActionResult UpdateMenuStatus(long OrderId, long MenuId, long StatusId)
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
            var orders = _context.OrderInformations
                                                    .Where(x => !x.IsFinished)
                                                    .Include(x => x.OrderItems)
                                                    .ThenInclude(x => x.Menu)
                                                 .Select(x => new DisplayOrder
                                                 {
                                                     Id = x.Id,
                                                     Name = x.Name,
                                                     OrderDateTime = x.OrderDateTime.AddTicks( - (x.OrderDateTime.Ticks % TimeSpan.TicksPerSecond)),
                                                     IsFinished = x.IsFinished,
                                                     Location = x.Location,
                                                     Menus = x.OrderItems.Select(y => new DisplayMenu
                                                     {
                                                         Id = y.Menu.Id,
                                                         Name = y.Menu.Name,
                                                         Quantity = y.Quantity,
                                                         OrderStatus = y.OrderStatus
                                                     }).ToList()
                                                 });

            return Ok(orders);
        }
    } 

}