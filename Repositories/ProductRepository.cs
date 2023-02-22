using Product_ExceptionalHandl.ExceptionHandling;
using Product_ExceptionalHandl.Interface;
using Product_ExceptionalHandl.Models;

namespace Product_ExceptionalHandl.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ProductdbContext _context;

        public ProductRepository(ProductdbContext context)
        {
            _context = context;
        }
        public List<Product> CreateProducts(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return _context.Products.ToList();
        }

        public string DeleteProduct(int id)
        {
            var oldProd = _context.Products.Find(id);
            if(id==null)
            {
                throw new ServiceException($"PLEASE ENTER VALID ID!");
            }
            _context.Remove(oldProd);
            _context.SaveChanges();
            return "Deleted Successfully";
        }


        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductByName(string name)
        {
            var prod = _context.Products.Where(x=>x.ProductName==name).FirstOrDefault();
            if (prod == null)
            {
                throw new ServiceException("Product with Name:" + name + " Not Found");
            }
            else { return (prod); };

        }

        public List<Product> updateProduct(Product product)
        {
           var existingProd=_context.Products.Find(product.Id);
            if(existingProd == null)
            {
                throw new ServiceException("NO PRODUCT FOUND WITH ID" +product.Id);
            }
            existingProd.ProductName= product.ProductName;
            existingProd.ProductDescription= product.ProductDescription;
            existingProd.ProductPrice= product.ProductPrice;
            existingProd.ProductCategory=product.ProductCategory;
            _context.SaveChanges();
            return _context.Products.ToList();
        }
    }
}





///to create MOQ ADD REFERENCE
///DEPENDENCIES:MOQ->MOQ,MOQ.ASPNET,NUNIT,XUNIT,MSTEST.TEST
///
//[TestClass]
//public class UnitTest1
//{

//    [Fact]
//    public async Task GetAllProducts_ReturnsAllProducts()
//    {
//        // Arrange
//        var mockDbContext = new Mock<ProductdbContext>();
//        var products = new List<Product>
//        {
//            new Product { Id = 1, ProductName = "IPhone", ProductDescription = "Description 1", ProductPrice = 10 , ProductCategory="Mobiles"},

//        };
//        var mockDbSet = new Mock<DbSet<Product>>();
//        mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.AsQueryable().Provider);
//        mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.AsQueryable().Expression);
//        mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.AsQueryable().ElementType);
//        mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());
//        mockDbContext.Setup(m => m.Products).Returns(mockDbSet.Object);

//        var productRepository = new ProductRepository(mockDbContext.Object);

//        // Act
//        var result = productRepository.GetProducts();

//        // Assert
//        Assert.AreEqual(products.Count, result.Count());
//        CollectionAssert.AreEqual(products, result.ToList());
//    }

/// just run "TEST"