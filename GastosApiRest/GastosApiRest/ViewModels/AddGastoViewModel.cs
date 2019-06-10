using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using GastosApiRest.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GastosApiRest.ViewModels
{
    public class AddGastoViewModel
    {
        private DataService _dataService = new DataService();

        public Gasto SelectedGasto { get; set; }

        public ICommand SendGastoCommand => new Command(async () =>
        {
            SelectedGasto.fechaGasto = DateTime.UtcNow;

            await _dataService.PostGasto(SelectedGasto);
        });

        public AddGastoViewModel()
        {
            SelectedGasto = new Gasto();
        }
    }
}
