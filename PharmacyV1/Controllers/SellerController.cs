using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using System.Collections.Generic;
using Pharmacy.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private  ApplicationDbContext _db;
        public SellerController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            List<Seller> obj = await _db.Seller.ToListAsync();
            return Ok(obj);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Seller obj)
        {
            obj.Orders = new List<Order>();
            await _db.Seller.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok("Success");
        }
        
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Seller seller = await _db.Seller.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            _db.Seller.Remove(seller);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}
