using System.Collections.Generic;

namespace OfertaAcademicaApp.Core
{
    public interface IProductsManager
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetBestSellingProducts();
        IEnumerable<Product> GetPopularProducts();
    }
}