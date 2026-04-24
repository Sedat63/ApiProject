using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetList() 
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateChefs(Chef chefs)
        {
            _context.Chefs.Add(chefs);
            _context.SaveChanges();
            return Ok("Şef Aşçı Ekleme İşlemi Başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id) 
        {
            var values = _context.Chefs.Find(id);
            _context.Chefs.Remove(values);
            _context.SaveChanges();
            return Ok("Şef Aşçı Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {           
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Şef Aşçı Güncelleme İşlemi Başarılı");
        }

        [HttpGet("GetChefById")]
        public ActionResult GetChefById(int id) 
        {
            var values= _context.Chefs.Find(id);
            return Ok(values);
        }
    }
    
}
