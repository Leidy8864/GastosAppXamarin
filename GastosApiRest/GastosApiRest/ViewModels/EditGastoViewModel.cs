using System;
using System.Windows.Input;
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
            SelectedGasto.fechaGasto = DateTime.UtcNow;

            await _dataService.PutGasto(SelectedGasto._id, SelectedGasto);
        });

        public ICommand DeleteGastoCommand => new Command(async () =>
        {
            SelectedGasto.fechaGasto = DateTime.UtcNow;

            await _dataService.DeleteGasto(SelectedGasto._id);
        });
    }
}
