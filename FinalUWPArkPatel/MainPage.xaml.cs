﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalUWPArkPatel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if(txt1.Text=="")
            {
                tb1.Text = "Text box cannot be empty";
            }
            else
            {
                Calculate();
            }
        }

       
        private void Calculate()
        {
            double temprature;
            if (r1.IsChecked  == true)
            {
                temprature = (Double.Parse(txt1.Text) * 9.0 / 5.0) + 32;
                tb1.Text = temprature.ToString("0.##") + "\u00B0" + "F";
            }
            else if (r2.IsChecked == true)

            {
                temprature = (Double.Parse(txt1.Text) - 32) * 5.0 / 9.0;
                tb1.Text = temprature.ToString("0.##") + "\u00B0" + "C";
            }
           
        }
    }
}
