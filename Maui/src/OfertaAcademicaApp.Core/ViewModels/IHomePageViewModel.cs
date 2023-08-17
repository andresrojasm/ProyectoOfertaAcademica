using System.Collections.Generic;
using System.Windows.Input;

namespace OfertaAcademicaApp.Core
{
    public interface IHomePageViewModel
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> BestSellingProducts { get; }
        ICommand OpenFlyoutCommand { get; }
        IEnumerable<Product> PopularProducts { get; }
        ICommand ProductSelectedCommand { get; }
    }
}