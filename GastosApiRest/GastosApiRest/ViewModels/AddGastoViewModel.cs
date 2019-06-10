using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using GastosApiRest.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GastosApiRest.ViewModels
{
    public class AddGastoViewModel : ViewModelBase
    {
        private DataService _dataService = new DataService();

        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        string apellidos;
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (apellidos != value)
                {
                    apellidos = value;
                    OnPropertyChanged();
                }
            }
        }

        string monto;
        public string Monto
        {
            get { return monto; }
            set
            {
                if (monto != value)
                {
                    monto = value;
                    OnPropertyChanged();
                }
            }
        }

        string tipoGasto;
        public string TipoGasto
        {
            get { return tipoGasto; }
            set
            {
                if (tipoGasto != value)
                {
                    tipoGasto = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SendGastoCommand { protected set; get; }

        public AddGastoViewModel()
        {        
            SendGastoCommand = new Command( async() =>
            {
                var SelectedGasto = new Gasto
                {
                    nombre = Nombre,
                    apellidos = Apellidos,
                    monto = Double.Parse(Monto),
                    fechaGasto = DateTime.UtcNow,
                    tipoGasto = TipoGasto
                };
                Console.WriteLine(Apellidos + Nombre);
                Console.WriteLine(JsonConvert.SerializeObject(SelectedGasto));
                await _dataService.PostGasto(SelectedGasto);
            });
        }
    }
}
