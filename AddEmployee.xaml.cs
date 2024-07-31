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
    public delegate bool Check(Employee e);
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public event Check EventCheck;
        public List<string> rules{ set; get; }
       
        public AddEmployee()
        {
            InitializeComponent();
            rules = employyeBL.Rules();
            for (int i = 0; i < rules.Count; ++i)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = rules[i];
                JobTitleTextBox.Items.Add(newItem);
            }

        }
        bl employyeBL = new bl();
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Utilities.CheckIdValidation(IdTextBox.Text))
            {
                MessageBox.Show("Invalid Id");
            }
            else if (!Utilities.CheckNameValidation(FirstNameTextBox.Text))
            {
                MessageBox.Show("Invalid First Name");
            }
            else if (!Utilities.CheckNameValidation(LastNameTextBox.Text))
            {
                MessageBox.Show("Invalid Last Name");
            }
            else if (!Utilities.CheckAgeValidation(AgeTextBox.Text))
            {
                MessageBox.Show("Invalid Age");
            }
            else if (!Utilities.CheckStartYearValidation(StartOfWorkingYearTextBox.Text))
            {
                MessageBox.Show("Invalid Start Of Working Year");
            }
            else if (!Utilities.CheckPhoneValidation(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Invalid Phone Number");
            }
            else if (!Utilities.EmailValidation(MailAddressTextBox.Text))
            {
                MessageBox.Show("Invalid Email");
            }
            else
            {
                EventCheck(new Employee(int.Parse(IdTextBox.Text), FirstNameTextBox.Text, LastNameTextBox.Text, int.Parse(AgeTextBox.Text), int.Parse(StartOfWorkingYearTextBox.Text), CityAddressTextBox.Text, StreetAddressTextBox.Text, JobTitleTextBox.SelectionBoxItem.ToString(), PhoneNumberTextBox.Text, MailAddressTextBox.Text));
                MessageBox.Show("Employee added Successfully");
                this.Close();
            }
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
           
        }
    }
    
}
