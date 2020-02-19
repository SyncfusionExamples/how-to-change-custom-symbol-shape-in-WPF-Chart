using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomSymbolShape
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class SymbolDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HighValueTemplate { get; set; }
        public DataTemplate LowValueTemplate { get; set; }
        public DataTemplate EmptyValueTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return EmptyValueTemplate;

            var adornment = item as ChartAdornment;

            var model = adornment.Item as Model;

            if (model.YValue < 20)
            {
                return HighValueTemplate;
            }
            else
            {
                return LowValueTemplate;
            }
        }
    }

}
