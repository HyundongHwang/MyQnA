using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

namespace ComboBoxSelTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.CbObj.SelectionChanged += CbObj_SelectionChanged;
            var items = new List<InspectionModel>();
            var rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                items.Add(new InspectionModel
                {
                    InspName = i.ToString(),
                    isVisible = i % 2 == 1 ? true : false,
                });
            }

            this.CbObj.ItemsSource = items;
            Trace.TraceInformation($"this.CbObj.SelectedIndex : {this.CbObj.SelectedIndex}");
        }

        private void CbObj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Trace.TraceInformation($"CbObj_SelectionChanged this.CbObj.SelectedIndex : {this.CbObj.SelectedIndex}");
        }
    }

    public class InspectionModel
    {
        public int InspIdx;
        public string InspName { get; set; }
        public List<string> seqNameList = new List<string>();
        public int AuthLevel;
        public bool isVisible;
        public int CamType;

        public override string ToString()
        {
            return $"InspName: {InspName}";
        }
    }

    public class ComboboxDisableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value;
            // You can add your custom logic here to disable combobox item
            if (((InspectionModel)value).isVisible)
                return true;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
