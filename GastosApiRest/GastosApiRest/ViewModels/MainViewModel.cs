using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using GastosApiRest.Services;
using Xamarin.Forms;

namespace GastosApiRest.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Gasto> _todos;
        private DataService _dataService = new DataService();
        private bool _isRefreshing;

        public List<Gasto> Gastos
        {
            get { return _todos; }
            set
            {
                _todos = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand => new Command(async () =>
        {
            await GetGastos();
        });

        public MainViewModel()
        {
            GetGastos();
        }

        private async Task GetGastos()
        {
            IsRefreshing = true;

            Gastos = await _dataService.GetGastos();

            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
