using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    readonly IProductWriteRespository _productWriteRespository;
    readonly IProductReadRepository _productReadRepository;
    public ProductsController(IProductWriteRespository productWriteRespository,
                                IProductReadRepository productReadRepository)
    {
      _productWriteRespository = productWriteRespository;
      _productReadRepository = productReadRepository;
    }

    [HttpGet]
    public async Task<IActionResult> get()
    {
      return Ok(_productReadRepository.GetAll(false).Select(p => new
      {
        p.Id,
        p.Name,
        p.Stock,
        p.Price,
        p.CreatedDate,
        p.UpdatedDate 
      }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
      return Ok( await _productReadRepository.GetByIdAsync(id,false));

    }

    [HttpPost]
    public async Task<IActionResult> Post(VM_Create_Product model)
    {
      await _productWriteRespository.AddAsync(new()
      {
        Name = model.Name,
        Stock = model.Stock,
        Price = model.Stock
      });

      await _productWriteRespository.SaveAsync();
      return StatusCode((int)(HttpStatusCode.Created));
    }
    [HttpPut]
    public async Task<IActionResult> Put(VM_Update_Product model)
    {
      Product product = await _productReadRepository.GetByIdAsync(model.Id);
      product.Stock = model.Stock;
      product.Price = model.Price;
      product.Name = model.Name;
      await _productWriteRespository.SaveAsync();
      return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
      await _productWriteRespository.RemoveAsync(id);
      await _productWriteRespository.SaveAsync();
      return Ok();
    }

      


  }
}
