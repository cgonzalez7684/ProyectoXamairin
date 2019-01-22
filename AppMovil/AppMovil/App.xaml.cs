using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppMovil
{
    public partial class App : Application
    {
        public static ApiServices.ApiViewQ Servicio { get; set; }
        public static Entidades.InfoCliente objCliente { get; set; }

        public App()
        {
            InitializeComponent();
            Servicio = new ApiServices.ApiViewQ();
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new LoginPage();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
