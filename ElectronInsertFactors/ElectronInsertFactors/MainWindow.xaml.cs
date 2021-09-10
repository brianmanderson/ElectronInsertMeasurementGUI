using System;
using System.IO;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ElectronInsertFactors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<string> _machine_names_list = new List<string> { "Select a machine", "Del Mar", "La Jolla"};
        private List<string> _energy_list = new List<string> { "Select an energy", "6e", "9e", "12e", "16e", "20e"};
        private List<string> ssdList = new List<string> { "Select an SSD", "105", "110"};
        private List<string> chamberList = new List<string> { "Select a chamber", "Markus Chamber (23343)", "Advanced Markus (34045)" };
        private string _dmax;
        public List<string> MachineNamesList
        {
            get
            {
                return _machine_names_list;
            }
            set
            {
                _machine_names_list = value;
                OnPropertyChanged("MachineNamesList");
            }
        }
        public List<string> EnergyList
        {
            get
            {
                return _energy_list;
            }
            set
            {
                _machine_names_list = value;
                OnPropertyChanged("EnergyList");
            }
        }
        public List<string> SSDList
        {
            get
            {
                return ssdList;
            }
            set
            {
                _machine_names_list = value;
                OnPropertyChanged("SSDList");
            }
        }
        public List<string> ChamberList
        {
            get
            {
                return chamberList;
            }
            set
            {
                chamberList = value;
                OnPropertyChanged("ChamberList");
            }
        }
        public string Dmax
        {
            get
            {
                return _dmax;
            }
            set
            {
                _dmax = value;
                OnPropertyChanged("Dmax");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Binding machine_binding = new Binding("MachineNamesList");
            machine_binding.Source = this;
            MachineComboBox.SetBinding(ComboBox.ItemsSourceProperty, machine_binding);
            MachineComboBox.SelectedIndex = 0;

            Binding energy_binding = new Binding("EnergyList");
            energy_binding.Source = this;
            EnergyComboBox.SetBinding(ComboBox.ItemsSourceProperty, energy_binding);
            EnergyComboBox.SelectedIndex = 0;

            Binding ssd_binding = new Binding("SSDList");
            ssd_binding.Source = this;
            SSDComboBox.SetBinding(ComboBox.ItemsSourceProperty, ssd_binding);
            SSDComboBox.SelectedIndex = 0;

            Binding chamber_binding = new Binding("ChamberList");
            chamber_binding.Source = this;
            ChamberComboBox.SetBinding(ComboBox.ItemsSourceProperty, chamber_binding);
            ChamberComboBox.SelectedIndex = 0;

            Binding dmax_binding = new Binding("Dmax");
            dmax_binding.Source = this;
            Dmax_Label.SetBinding(Label.ContentProperty, dmax_binding);

        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private void EnergyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string energy = EnergyList[EnergyComboBox.SelectedIndex];
            if (energy.Contains("Select"))
            {
                Dmax = "";
            }
            else if (energy == "6e")
            {
                Dmax = "Dmax: 1.5 cm";
            }
            else if (energy == "9e")
            {
                Dmax = "Dmax: 2 cm";
            }
            else
            {
                Dmax = "Dmax: 3 cm";
            }
        }
    }
}
