using ApiProject.WebAPI.Context;
using ApiProject.WebAPI.Dtos.ProductDtos;
using ApiProject.WebAPI.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;

        public ProductsController(ApiContext context, IValidator<Product> validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList() 
        {
            var values=_context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else 
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün Ekleme İşlemi Başarılı");
            }            
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id) 
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Ürün Silme İşlemi Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product) 
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün Güncelleme İşlemi Başarılı");
            }
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id) 
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value= _context.Products.Include(c=>c.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(value));
        }
    }
}
