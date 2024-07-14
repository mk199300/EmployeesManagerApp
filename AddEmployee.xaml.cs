using BL;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
using System.Windows.Shapes;

namespace UI
{
    delegate bool Check(Employee e);
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public List<string> rules { get; set; }
        public ObservableCollection<Employee> ListOfEmployees { get; set; }
        public ObservableCollection<Employee> EmployeesToDisplay { get; set; }
        public AddEmployee()
        {
            InitializeComponent();
            EmployeesToDisplay = new ObservableCollection<Employee>(employyeBL.AllEmployees());
            rules = employyeBL.Rules();
            //PropertyChanged(this, new PropertyChangedEventArgs("rules"));
        }
        bl employyeBL = new bl();
        public event PropertyChangedEventHandler? PropertyChanged;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Utilities.CheckIdValidation(IdTextBox.Text))
            {
                MessageBox.Show("Invalid Id");
            }
            if (!Utilities.CheckNameValidation(FirstNameTextBox.Text))
            {
                MessageBox.Show("Invalid First Name");
            }
            if (!Utilities.CheckNameValidation(LastNameTextBox.Text))
            {
                MessageBox.Show("Invalid Last Name");
            }
            if (!Utilities.CheckAgeValidation(AgeTextBox.Text))
            {
                MessageBox.Show("Invalid Age");
            }
            if (!Utilities.CheckStartYearValidation(StartOfWorkingYearTextBox.Text))
            {
                MessageBox.Show("Invalid Start Of Working Year");
            }
            if (!Utilities.CheckPhoneValidation(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Invalid Phone Number");
            }
            if (!Utilities.EmailValidation(MailAddressTextBox.Text))
            {
                MessageBox.Show("Invalid Email");
            }

            MessageBox.Show("Employee added Successfully");
            this.Close();
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void JobTitleTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string rule = string.Empty;
            if (e.AddedItems.Count == 1)
            {
                rule = (string)e.AddedItems[0];
            }
            EmployeesToDisplay = new ObservableCollection<Employee>(ListOfEmployees.Where(x => x.RoleInCompany == rule));
            PropertyChanged(this, new PropertyChangedEventArgs("EmployeesToDisplay"));
        }
    }
    
}
