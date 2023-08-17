using OfertaAcademicaApp.Core;
using OfertaAcademicaApp.Maui.Services;
using OfertaAcademicaApp.Maui.Views.Pages;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace OfertaAcademicaApp.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MADE Tommy Soft Medium.otf", "BoldFont");
                    fonts.AddFont("GlacialIndifference-Regular.otf", "RegularFont");
                });

            builder.UseSimpleToolkit();
            builder.UseSimpleShell();

            builder.DisplayContentBehindBars();

            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<ICartManager, CartManager>();
            builder.Services.AddSingleton<IProductsManager, ProductsManager>();

            // Do not forget to register pages when using DI
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<BalancePage>();
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<FavoritesPage>();
            builder.Services.AddTransient<HelpPage>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<ProductDetailPage>();

            builder.Services.AddTransient<IHomePageViewModel, HomePageViewModel>();
            builder.Services.AddTransient<IProductDetailPageViewModel, ProductDetailPageViewModel>();

            return builder.Build();
        }
    }
}