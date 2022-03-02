using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFHomeWork1.Model;

namespace WPFHomeWork1
{
    public interface IMainVM
    {
        string ID { get; set; }
        string Name { get; set; }
        string Price { get; set; }
        Stock SelectedStock { get; set; }
        string SelectedType { get; set; }

        ICommand AddStockCommand { get; }
        ObservableCollection<Stock> StockCollection { get; }
        ObservableCollection<string> StockTypeCollection { get; }

        bool Visible { get; }
    }
}