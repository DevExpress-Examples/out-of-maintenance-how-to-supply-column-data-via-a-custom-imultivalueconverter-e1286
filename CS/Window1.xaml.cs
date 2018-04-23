using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using System.ComponentModel;
using System.Windows.Input;
using System.Globalization;
using System.Windows.Markup;
using System.Threading;
using System.Windows.Data;

namespace MultiValueConverter {

    public partial class Window1 : Window {
        BindingList<Order> list;

        public Window1() {
            InitializeComponent();

            list = new BindingList<Order>();
            list.Add(new Order() { Item = "Salad", Price = 6.99m, Quantity = 1 });
            list.Add(new Order() { Item = "Cheeseburger", Price = 2.75m, Quantity = 2 });
            list.Add(new Order() { Item = "Cola", Price = 1.50m, Quantity = 1 });

            grid1.DataSource = list;
        }
   }
    public class MyConverter : MarkupExtension, IMultiValueConverter {
        #region IValueConverter Members
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if(values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
                return decimal.Zero;
            return Convert.ToDecimal(values[0]) * Convert.ToInt32(values[1]);
        }
        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        #endregion

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }

    public class Order {
        public string Item { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
