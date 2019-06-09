using System;
using System.Windows.Input;
using GastosApiRest.Models;
using GastosApiRest.Services;
using Xamarin.Forms;

namespace GastosApiRest.ViewModels
{
    public class AddGastoViewModel
    {
        private DataService _dataService = new DataService();

        public Gasto SelectedGasto { get; set; }

        public ICommand SendGastoCommand => new Command(async () =>
        {
            SelectedGasto.FechaGasto = DateTime.UtcNow;

            await _dataService.PostGasto(SelectedGasto);
        });

        public AddGastoViewModel()
        {
            SelectedGasto = new Gasto();
        }
    }
}
