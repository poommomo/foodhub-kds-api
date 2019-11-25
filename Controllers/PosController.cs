using System;
using Microsoft.AspNetCore.Mvc;
using FoodHub.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace FoodHub.Controllers
{
    public class PosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: pos/getmenu
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

        [HttpPost]
        public ActionResult Order([FromBody] FoodOrder order)
        {
            try
            {
                var orderInformation = new OrderInformation
                {
                    Name = order.Name,
                    TotalPrice = order.TotalPrice,
                    IsFinished = false,
                    LocationId = order.LocationId,
                };
                _context.Add(orderInformation);
                _context.SaveChanges();

                var orderItems = new List<OrderItem>();
                foreach (OrderMenu menu in order.MenuList)
                {
                    var orderItem = new OrderItem
                    {
                        OrderInformationId = orderInformation.Id,
                        MenuId = menu.MenuId,
                        OrderStatusId = 1,
                        Quantity = menu.Quantity
                    };
                    orderItems.Add(orderItem);
                }
                _context.AddRange(orderItems);
                _context.SaveChanges();

                return Ok();
            } 
            catch (Exception e) 
            {
                Console.Write(e);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}