using ExamenApp2.Models;
using ExamenApp2.ViewModels;

namespace ExamenApp2.Views;

public partial class AddProveedorPage : ContentPage
{
	private AddProveedorPageViewModel _viewModel;
	public AddProveedorPage()
	{
		InitializeComponent();
		_viewModel = new AddProveedorPageViewModel();	
		this.BindingContext = _viewModel;
	}

	public AddProveedorPage(Proveedor proveedor)
	{

		InitializeComponent();
		_viewModel = new AddProveedorPageViewModel(proveedor);
		this.BindingContext = _viewModel;

    }
}