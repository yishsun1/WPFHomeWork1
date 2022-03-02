using NSubstitute;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFHomeWork1.Model;

namespace WPFHomeWork1.Design
{
    static class FakeVmFactory
    {
        public static IMainVM Create()
        {
            var vm = Substitute.For<IMainVM>();

            var types = Enumerable.Range(0, 5).Select(i => i % 2 == 0 ? $"_{i}" : $"{i}~")
                .Select(i => $"Type({i})")
                .ToArray();

            var stocks = Enumerable.Range(0, 2).Select(i =>
            {
                var isStock = i % 2 == 0;
                var newStock = new Stock
                {
                    ID = isStock ? $"Stock_{i}" : $"Future_{i}",
                    Name = isStock ? $"股_{i}" : $"期_{i}",
                    Price = i * 32,
                    Type = types[i%types.Length]
                };
                return newStock;
            });
            var command = new BaseCommand(_ =>
            {
                MessageBox.Show("AddStockCommand");
            });

            vm.ID.Returns("init_ID");
            vm.Name.Returns("init_Name");
            vm.Price.Returns("5566");

            vm.StockCollection.Returns(new ObservableCollection<Stock>(stocks));
            vm.StockTypeCollection.Returns(new ObservableCollection<string>(types));

            vm.SelectedType.Returns(types.Last());
            vm.SelectedStock.Returns(stocks.Last());

            vm.AddStockCommand.Returns(command);
            vm.Visible.Returns(true);

            return vm;
        }
    }
}
