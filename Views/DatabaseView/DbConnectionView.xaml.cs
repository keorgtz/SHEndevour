using SHEndevour.ViewModels;
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

namespace SHEndevour.Views.DatabaseView
{
    /// <summary>
    /// Lógica de interacción para DbConnectionView.xaml
    /// </summary>
    public partial class DbConnectionView : Window
    {
        public DbConnectionView()
        {
            InitializeComponent();
            this.DataContext = new DbConnectionViewModel();
        }

        private void UnlockButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
