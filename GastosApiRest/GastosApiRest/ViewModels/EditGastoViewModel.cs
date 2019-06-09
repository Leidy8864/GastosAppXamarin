using System;
using System.Windows.Input;
using GastosApiRest.Models;
using GastosApiRest.Services;
using Xamarin.Forms;

namespace GastosApiRest.ViewModels
{
    public class EditGastoViewModel
    {
        private DataService _dataService = new DataService();

        public Gasto SelectedGasto { get; set; }

        public ICommand EditGastoCommand => new Command(async () =>
        {
            SelectedGasto.FechaGasto = DateTime.UtcNow;

            await _dataService.PutGasto(SelectedGasto.Id, SelectedGasto);
        });

        public ICommand DeleteGastoCommand => new Command(async () =>
        {
            SelectedGasto.FechaGasto = DateTime.UtcNow;

            await _dataService.DeleteGasto(SelectedGasto.Id);
        });
    }
}
