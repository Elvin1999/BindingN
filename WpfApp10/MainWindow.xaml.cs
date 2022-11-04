using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged();  }
        }



        public Car MyCar { get; set; }

        public ObservableCollection<Car> Cars { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MyCar = new Car
            {
                Model = "Malibu",
                Vendor = "Chevrolet",
                Year = 2021
            };


            Cars = new ObservableCollection<Car>
            {
                new Car
                {
                    Model="CLS Sport",
                    Vendor="Mercedes",
                    Year=2020
                },
                new Car
                {
                    Model="Rs SportBack",
                    Vendor="AUDI",
                    Year=2020
                },
                new Car
                {
                    Model="Escalade",
                    Vendor="Cadillac",
                    Year=2022
                },
            };

            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            MyCar.Model = "No Model";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cars.Add(new Car
            {
                 Model="Kicks",
                 Vendor="Nissan",
                 Year=2022
            });
        }

        private void myListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var car=myListBox.SelectedItem as Car;
            // MessageBox.Show(car.Model);

            InfoWindow window = new InfoWindow();
            window.Car = SelectedCar;
            this.Hide();
            window.ShowDialog();
            this.Show();
        }
    }
}
