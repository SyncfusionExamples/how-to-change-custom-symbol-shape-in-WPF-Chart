using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CustomSymbolShape
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }

        public ViewModel()
        {
            Data = new ObservableCollection<Model>()
            {
                new Model() {XValue = 0, YValue= 30},
                new Model() {XValue = 1, YValue= 40},
                new Model() {XValue = 2, YValue= 15},
                new Model() {XValue = 3, YValue= 45},
                new Model() {XValue = 4, YValue= 25},
                new Model() {XValue = 5, YValue= 30},
                new Model() {XValue = 6, YValue= 13},
                new Model() {XValue = 7, YValue= 10},
                new Model() {XValue = 8, YValue= 30},
            };

        }
    }

    public class Model
    {
        public double XValue { get; set; }

        public double YValue { get; set; }

    }
}
