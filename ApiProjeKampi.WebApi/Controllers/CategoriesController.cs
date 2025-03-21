using ApiProjeKampi.WebApi.Context;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value= _context.Categories.ToList();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category); //parametreden gelen değeri categories sınıfına ekle
        _context.SaveChanges();//değişiklikleri kaydet
            return Ok("Kategori ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori silme işlemi başarılı");

        }
        [HttpGet("GetCategory")] //HttpGet isteğini aynı sınıfta iki kez yaparsan hata verir hata vermemesi için "" içinde isim vermelisin
        public IActionResult GetCategory(int id)
        {
            var value= _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        { // hem bir id hemde name alacak parametre olarak
            var value = _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok(  "Kategori güncelleme işlemi başarılı");
        }
    }
}
