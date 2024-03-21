using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenApp2.Models;
using ExamenApp2.Services;
using ExamenApp2.Views;
using System.Collections.ObjectModel;

namespace ExamenApp2.ViewModels
{
    public partial class ProveedorMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();

        private readonly ProveedorService _proveedorService;

        public ProveedorMainPageViewModel()
        {
            _proveedorService = new ProveedorService();
        }

        public void GetAll()
        {
            var getAll = _proveedorService.GetAll();

            if (getAll?.Count > 0)
            {
                ProveedorCollection.Clear();
                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddProveedorPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddProveedorPage());
        }
       
        [RelayCommand]
        private async Task SelectProveedor(Proveedor proveedor)
        {
            try
            {
                string res = await App.Current.MainPage.DisplayActionSheet("Operación", "Cancelar", null, "Actualizar", "Eliminar");

                switch (res)
                {
                    case "Actualizar":
                        await App.Current.MainPage.Navigation.PushAsync(new AddProveedorPage(proveedor));
                        break;
                    case "Eliminar":
                        bool respuesta = await App.Current.MainPage.DisplayAlert("Eliminar Proveedor", "¿Desea eliminar el Proveedor?", "Si", "No");

                        if (respuesta)
                        {
                            int del = _proveedorService.Delete(proveedor);
                            if (del > 0)
                            {
                                ProveedorCollection.Remove(proveedor);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private void Alerta(string Tipo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert(Tipo, Mensaje, "Aceptar"));
        }
    }

}

