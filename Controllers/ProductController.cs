using Microsoft.AspNetCore.Mvc;
using Product_ExceptionalHandl.ExceptionHandling;
using Product_ExceptionalHandl.Interface;
using Product_ExceptionalHandl.Models;

namespace Product_ExceptionalHandl.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IProduct _repo;

        public ProductController(IProduct repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public List<Product> getAll()
        {
            try
            {     return _repo.GetProducts(); }
            catch (Exception ex) {
                throw new ServiceException($"An error occurred while retrieving the products", ex);
            }
        }
        [HttpGet("{ProductName}")]
        public Product getById(string ProductName)
        {
            try
            { return _repo.GetProductByName(ProductName); }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while retrieving the products", ex);
            }
        }
        [HttpDelete("{id}")]
        public String Delete(int id) {
            try { return _repo.DeleteProduct(id);  }
            catch (Exception ex){
                throw new ServiceException($"An error occurred while deleting the product with ID {id}", ex);
            }
        }
        [HttpPut]
        public List<Product> UpdateProducts([FromBody] Product product)
        {
            try { return _repo.updateProduct(product); }
            catch (Exception ex)
            {
                throw new ServiceException($"An error occurred while Updating the product", ex);
            }
        }
        [HttpPost]
        public List<Product> AddProducts([FromBody] Product product)
        {
            try { return _repo.CreateProducts(product); }
            catch (Exception ex) { throw new ServiceException("An error occurred while Creating the product", ex); }
        }
    }
}
