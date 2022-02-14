using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using System.Linq;
using Pharmacy.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MedicineController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Medicine> obj = await _db.Medicine.ToListAsync();
            return Ok(obj);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult>  GetById(int id)
        {
            Medicine obj = await _db.Medicine.FindAsync(id);
            return Ok(obj);
        }
        
        [HttpPost]
        public async Task<IActionResult>  Post(Medicine obj)
        {
            obj.MedDepoInfos = new List<MedDepoInfo>();
            obj.Orders = new List<Order>();
            await _db.Medicine.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Medicine obj1 = await _db.Medicine.FindAsync(id);
            if (obj1 == null)
            {
                return NotFound();
            }
            _db.Medicine.Remove(obj1);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromBody] Medicine obj)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Medicine obj1 = await _db.Medicine.FindAsync(id);
            if(obj1 == null)
            {
                return NotFound();
            }
            if (obj1.Id != id)
            {
                return BadRequest();
            }
            _db.Medicine.Update(obj);
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
        
        [HttpGet("type")]
        public async Task<IActionResult> GetTypes()
        {
            List<Type> obj = await _db.Type.ToListAsync();
            return Ok(obj);
        }
        
        [HttpPost("type")]
        public async Task<IActionResult> Created(Type obj)
        {
            obj.Medicines = new List<Medicine>();
            await _db.Type.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("type/{id}")]
        public async Task<IActionResult> DeleteType(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Type obj = await _db.Type.FindAsync(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Type.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("type/{id}")]
        public  async Task<IActionResult> UpdateType(int? id, Type obj)
        {
            if(id == null)
            {
                return BadRequest();
            }
            if(obj.Id != id)
            {
                return BadRequest();
            }
            Type obj1 = await _db.Type.FindAsync(id);
            if(obj1 == null)
            {
                return NotFound();
            }
            _db.Type.Update(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
