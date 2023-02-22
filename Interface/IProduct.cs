using Product_ExceptionalHandl.Models;

namespace Product_ExceptionalHandl.Interface
{
    public interface IProduct
    {
        //GET-PRODUCTS
        List<Product> GetProducts();
        //GET-PRODUCTS-BY-ID
        Product GetProductByName(string name);
        //CREATE[POST]-NEW-PRODUCT
        List<Product> CreateProducts(Product product);
        //DELETE-PRODUCT
        string DeleteProduct(int id);
        //UPDATE-[PUT] PRODUCT
        List<Product> updateProduct(Product product);
    }
}
