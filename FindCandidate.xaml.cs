﻿using BL;
using Dal.Models;
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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for FindCandidate.xaml
    /// </summary>
    public partial class FindCandidate : Window
    { public List<string> candidates { get; set; }
      public List<Interview> listOfInterviews { get; set; }

        public FindCandidate()
        {
            InitializeComponent();
            candidates = employyeBL.Candidates();
            for (int i = 0; i < candidates.Count; ++i)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = candidates[i];
                ComboboxChooseCandidate.Items.Add(newItem);
            }
            listOfInterviews = employyeBL.Interviews(ComboboxChooseCandidate.SelectionBoxItem.ToString());
        }
        bl employyeBL = new bl();
        

    }
}
