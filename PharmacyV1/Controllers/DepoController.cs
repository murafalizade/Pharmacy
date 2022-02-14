using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Pharmacy.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pharmacy.Data;
namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DepoController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            List<Depo> obj = await _db.Depo.ToListAsync();
            return Ok(obj);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Depo obj2 = await _db.Depo.FindAsync(id);
            if(obj2 == null)
            {
                return NotFound();
            }
            return Ok(obj2);
        }
        
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] Depo obj)
        {
            if (!obj.MedDepoInfos.Any())
            {
                obj.MedDepoInfos = new List<MedDepoInfo>();
            }
            await _db.Depo.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok("Success");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int? id)
        {

            if(id == null)
            {
                return BadRequest();
            }
            Depo obj1 = await _db.Depo.FindAsync(id);
            if(obj1 == null)
            {
                return NotFound();
            }
            _db.Depo.Remove(obj1);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, Depo obj) 
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (obj == null)
            {
                return BadRequest();
            }
            if (id != obj.Id)
            {
                return NotFound();
            }
            Depo obj2 = await _db.Depo.FindAsync(id);
            if(obj2== null)
            {
                return NotFound();
            }
            obj2.Name = obj.Name;
            obj2.Location = obj.Location;
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
    }
}
