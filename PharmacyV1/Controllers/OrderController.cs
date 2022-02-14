using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using System.Linq;
using Pharmacy.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Order> obj = await _db.Order.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Order obj = await _db.Order.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> BuyMedicine(Order obj)
        {
            MedDepoInfo obj1 = await  _db.MedDepoInfo.FirstOrDefaultAsync(p => p.MedicineId == obj.MedicineId);
            obj.OrderId = Guid.NewGuid().ToString();
            if (obj1 == null)
            {
                return NotFound();
            }
            if (obj1.Count >= obj.Count)
            {
                obj1.Count -= obj.Count;
                obj.TotalPrice = obj1.Price * obj.Count;
                await _db.Order.AddAsync(obj);
            }
            else
            {
                return BadRequest("Doesn't exist enough medicine");
            }
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            
            Order obj = await _db.Order.FindAsync(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Order.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, Order obj)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if(obj == null)
            {
                return BadRequest();
            }
            if(obj.Id != id)
            {
                return NotFound();
            }
            Order obj2 = await _db.Order.FindAsync(id);
            if (obj2 == null)
            {
                return NotFound();
            }
            _db.Order.Update(obj);
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
      
    }
}
