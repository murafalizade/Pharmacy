using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pharmacy.Data;
using Pharmacy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmacy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedDepoInfoController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public MedDepoInfoController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<MedDepoInfo> obj = await _db.MedDepoInfo.ToListAsync();
            return Ok(obj);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if(id== null)
            {
                return BadRequest();
            }
            MedDepoInfo obj = await _db.MedDepoInfo.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(MedDepoInfo obj)
        {
            await _db.MedDepoInfo.AddAsync(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id,MedDepoInfo obj)
        {
            if(id == null)
            {
                return BadRequest();
            }
            if (id != obj.Id)
            {
                return BadRequest();
            }
            MedDepoInfo obj1 = await _db.MedDepoInfo.FindAsync(id);
            if(obj1 == null)
            {
                return NotFound();
            }
            _db.MedDepoInfo.Update(obj);
            await _db.SaveChangesAsync();
            return Ok(obj);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int? id)
        {
            if(id== null)
            {
                return BadRequest();
            }
            MedDepoInfo obj = await _db.MedDepoInfo.FindAsync(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.MedDepoInfo.Remove(obj);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
