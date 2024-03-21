using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenApp2.Models;
using ExamenApp2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenApp2.ViewModels
{
    public partial class AddProveedorPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string? nombre;

        [ObservableProperty]
        public string? email;

        [ObservableProperty]
        public string? telefono;

        [ObservableProperty]
        public string? direccion;

        private readonly ProveedorService _proveedorService;

        public AddProveedorPageViewModel()
        {
            _proveedorService = new ProveedorService();
        }

        public AddProveedorPageViewModel(Proveedor proveedor)
        {
            Id = proveedor.Id;
            Nombre = proveedor.Nombre;
            Email = proveedor.Email;
            Telefono = proveedor.Telefono;
            Direccion = proveedor.Direccion;
            _proveedorService = new ProveedorService();
        }

        [RelayCommand]
        private async Task AddUpdate() 
        {
            try 
            {
                Proveedor proveedor = new Proveedor
                {
                    Id = Id,
                    Nombre = Nombre,
                    Email = Email,
                    Telefono = Telefono,
                    Direccion = Direccion,
                };
                if (Validar(proveedor)) 
                {
                    if (Id == 0)
                    {
                        _proveedorService.Insert(proveedor);
                    }
                    else
                    {
                        _proveedorService.Update(proveedor);
                    }
                    await App.Current.MainPage.Navigation.PopAsync();
                }
                
            }catch (Exception ex) 
            {
                Alerta("ERROR", ex.Message);
            }
        }

        private bool Validar(Proveedor proveedor)
        {
            try
            {
                if (string.IsNullOrEmpty(proveedor.Nombre))
                {
                    Alerta("ADVERTENCIA", "Escriba el nombre del proveedor");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Email))
                {
                    Alerta("ADVERTENCIA", "Escriba el email del proveedor");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Telefono))
                {
                    Alerta("ADVERTENCIA", "Escriba el telefono del proveedor");
                    return false;
                }
                else if (string.IsNullOrEmpty(proveedor.Direccion))
                {
                    Alerta("ADVERTENCIA", "Escriba la dirección del proveedor");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
                return false;
            }
        }

        private void Alerta(string tipo, string mensaje)
        {
            Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert(tipo, mensaje, "Aceptar"));
        }

    }
    }
