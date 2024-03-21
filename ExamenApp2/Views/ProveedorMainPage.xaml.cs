using ExamenApp2.ViewModels;
using ExamenApp2.Views;

namespace ExamenApp2.Views;

public partial class ProveedorMainPage : ContentPage
{
	private ProveedorMainPageViewModel _viewModel;

	public ProveedorMainPage()
	{
		InitializeComponent();
		_viewModel = new ProveedorMainPageViewModel();
		this.BindingContext = _viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetAll();
    }
}