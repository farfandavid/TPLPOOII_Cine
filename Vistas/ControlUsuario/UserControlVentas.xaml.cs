using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using LiveCharts;
using LiveCharts.Configurations;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Helpers;
using ClasesBase;
using ClasesBase.TrabajarABM;
using System.Data;
using System.Globalization;

namespace Vistas.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para UserControlVentas.xaml
    /// </summary>
    public partial class UserControlVentas : UserControl, INotifyPropertyChanged {

        private ZoomingOptions _zoomingMode;
        string[] total;
        IList<Peli> peliTotal;
        public UserControlVentas()
        {
            InitializeComponent();
            iniciarChartFecha();
            llenarPeli();
            iniciarCharPelicula();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        //Columnas
        public class Peli {
            public string titulo { get; set; }
            public int total { get; set; }
        }

        private void llenarPeli() {
            DataTable dtpel = new DataTable();
            dtpel = ABMVenta.traer_ventaPelicula();
            peliTotal = dtpel.AsEnumerable().Select(row =>
            new Peli {
                titulo = row.Field<string>("peli_Titulo"),
                total = row.Field<int>("Total")
            }).ToList();
        }
        private void iniciarCharPelicula() {
            Mapper = Mappers.Xy<Peli>()
                .X((peli, index) => index)
                .Y(peli => peli.total);

            var records = peliTotal.ToList();
            Results = records.AsChartValues();
            Labels = new ObservableCollection<string>(records.Select(x => x.titulo));

            MillionFormatter = value => "$" + (value / 1).ToString("N");

            DataContext = this;
        }
        public string[] Total {
            get {
                return total;
            }

            set {
                total = value;
            }
        }
        public ChartValues<Peli> Results { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        public Func<double, string> MillionFormatter { get; set; }

        public object Mapper { get; set; }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e) {
            var q = (Query.Text ?? string.Empty).ToUpper();
            var records = peliTotal.Where(x => x.titulo.ToUpper().Contains(q)).ToArray();

            Results.Clear();
            Results.AddRange(records);

            Labels.Clear();
            foreach (var record in records) Labels.Add(record.titulo);

        }

        //Cartesian
        private void iniciarChartFecha() {
            var gradientBrush = new LinearGradientBrush {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
            gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(219, 13, 255), 0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = GetData(),
                    Fill = gradientBrush,
                    StrokeThickness = 1,
                    PointGeometrySize = 0,
                    Stroke = new SolidColorBrush(Colors.Purple),

                }
            };

            ZoomingMode = ZoomingOptions.X;

            XFormatter = val => new DateTime((long)val).ToString("dd MMM");
            YFormatter = val => val.ToString("$ 0");

            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public ZoomingOptions ZoomingMode {
            get { return _zoomingMode; }
            set {
                _zoomingMode = value;
                OnPropertyChanged();
            }
        }



        private void ToogleZoomingMode(object sender, RoutedEventArgs e) {
            switch (ZoomingMode) {
                case ZoomingOptions.None:
                    ZoomingMode = ZoomingOptions.X;
                    break;
                case ZoomingOptions.X:
                    ZoomingMode = ZoomingOptions.Y;
                    break;
                case ZoomingOptions.Y:
                    ZoomingMode = ZoomingOptions.Xy;
                    break;
                case ZoomingOptions.Xy:
                    ZoomingMode = ZoomingOptions.None;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private ChartValues<DateTimePoint> GetData() {
            DataTable dt = new DataTable();
            dt = ABMVenta.traer_ventaFecha();

            var values = new ChartValues<DateTimePoint>();

            for (var i = 0; i < dt.Rows.Count; i++) {


                var seed = double.Parse(dt.Rows[i]["Precio"].ToString());

                values.Add(new DateTimePoint(DateTime.Parse(dt.Rows[i]["vent_Fecha"].ToString()), seed));

            }

            return values;
        }

        
        protected virtual void OnPropertyChanged(string propertyName = null) {
            if (PropertyChanged != null) PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ResetZoomOnClick(object sender, RoutedEventArgs e) {
            //Use the axis MinValue/MaxValue properties to specify the values to display.
            //use double.Nan to clear it.

            X.MinValue = double.NaN;
            X.MaxValue = double.NaN;
            Y.MinValue = double.NaN;
            Y.MaxValue = double.NaN;
        }

        

        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    public class ZoomingModeCoverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            switch ((ZoomingOptions)value) {
                case ZoomingOptions.None:
                    return "None";
                case ZoomingOptions.X:
                    return "X";
                case ZoomingOptions.Y:
                    return "Y";
                case ZoomingOptions.Xy:
                    return "XY";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
