using System.Collections.Generic;

namespace OfertaAcademicaApp.Core
{
    public interface ICartManager
    {
        int Count { get; }
        IReadOnlyCollection<Product> ProductsInCart { get; }
        void AddToCart(Product item);
    }
}