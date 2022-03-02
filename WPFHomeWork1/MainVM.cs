using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFHomeWork1.Model;

namespace WPFHomeWork1
{
    public class MainVM : BaseViewModel
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; OnpPropertyChanged(); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnpPropertyChanged(); }
        }

        private string _Price;
        public string Price
        {
            get { return _Price; }
            set { _Price = value; OnpPropertyChanged(); }
        }

        private ObservableCollection<string> _StockTypeCollection = new ObservableCollection<string>();
        public ObservableCollection<string> StockTypeCollection
        {
            get { return _StockTypeCollection; }
            set { _StockTypeCollection = value; OnpPropertyChanged(); }
        }

        private ICommand _AddStockCommand;
        public ICommand AddStockCommand
        {
            get { return _AddStockCommand; }
            set { _AddStockCommand = value; }
        }

        private ObservableCollection<Stock> _stockCollection = new ObservableCollection<Stock>();
        public ObservableCollection<Stock> StockCollection
        {
            get { return _stockCollection; }
            set { _stockCollection = value; OnpPropertyChanged(); }
        }

        private Stock _SelectedStock;
        public Stock SelectedStock
        {
            get { return _SelectedStock; }
            set
            { 
                _SelectedStock = value;
                if (value != null && !Visible)
                    Visible = true;
                OnpPropertyChanged(); 
            }
        }

        private string _SelectedType;
        public string SelectedType
        {
            get { return _SelectedType; }
            set { _SelectedType = value; OnpPropertyChanged(); }
        }


        private bool _Visible = false;
        public bool Visible
        {
            get { return _Visible; }
            set { _Visible = value; OnpPropertyChanged(); }
        }

        public MainVM()
        {
            AddStockCommand = new BaseCommand(a => { AddStock();});
            StockTypeCollection.Add("電子股");
            StockTypeCollection.Add("金融股");
        }

        void AddStock()
        {
            double tempPrice = 0;
            if (double.TryParse(Price, out tempPrice))
            {
                Stock stock = new Stock();
                stock.Type = SelectedType;
                stock.ID = ID;
                stock.Name = Name;
                stock.Price = tempPrice;
                StockCollection.Add(stock);

                ID = "";
                Name = "";
                Price = "";
            }
            Price = "";
        }


    }
}
