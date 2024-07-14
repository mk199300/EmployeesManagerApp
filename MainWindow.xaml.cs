using BL;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<string> rules { get; set; }
        public ObservableCollection<Employee> ListOfEmployees { get; set; }

        public ObservableCollection<Employee> EmployeesToDisplay { get; set; }
        public MainWindow()
        {
            
            InitializeComponent();
            ListOfEmployees = new ObservableCollection<Employee>(employyeBL.AllEmployees());
            PropertyChanged(this, new PropertyChangedEventArgs("ListOfEmployees"));
            EmployeesToDisplay = new ObservableCollection<Employee>(employyeBL.AllEmployees());
            PropertyChanged(this, new PropertyChangedEventArgs("EmployeesToDisplay"));
            rules = employyeBL.Rules();
            PropertyChanged(this, new PropertyChangedEventArgs("rules"));
            
        }
        bl employyeBL=new bl();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployeeWin = new AddEmployee();
            addEmployeeWin.ShowDialog();
        }
        
        private void ComboBoxFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CandidateDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ComboBoxFilterCategory_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string rule = string.Empty;
            if (e.AddedItems.Count == 1)
            {
                rule = (string)e.AddedItems[0];
            }
            EmployeesToDisplay = new ObservableCollection<Employee>(ListOfEmployees.Where(x => x.RoleInCompany == rule));
            PropertyChanged(this, new PropertyChangedEventArgs("EmployeesToDisplay"));
        }

        private void ComboBoxFilterOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
