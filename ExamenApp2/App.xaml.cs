using ExamenApp2.Views;

namespace ExamenApp2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProveedorMainPage());
        }
    }
}
