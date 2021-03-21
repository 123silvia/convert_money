﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Globalization;

namespace PI.ConvertMoneyOther
{

    public partial class ValueElement : UserControl
    {
        public event RoutedEventHandler ConvertButtonClick;
        public event RoutedEventHandler TextChangedConvertSum;
        public ValueElement()
        {
            InitializeComponent();
            
        }
        
        protected virtual void OnButton_Click(object sender, RoutedEventArgs e)
        {
            if (ConvertButtonClick != null) 
                ConvertButtonClick(sender, e);

        }

        private void textBoxConvert1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".") && (!convertSum.Text.Contains(".")
                && convertSum.Text.Length != 0)))
            {
                 e.Handled = true;
            }
        }

        protected virtual void OntextBoxConvert1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextChangedConvertSum != null) 
                TextChangedConvertSum(sender, e);
        }
    }
}
