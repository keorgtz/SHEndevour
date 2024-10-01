﻿using SHEndevour.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace SHEndevour.Views
{
    /// <summary>
    /// Lógica de interacción para HotelRack.xaml
    /// </summary>
    public partial class HotelRack : UserControl
    {
        public HotelRack()
        {
            InitializeComponent();
            this.DataContext = new RackHotelViewModel();
        }
    }
}