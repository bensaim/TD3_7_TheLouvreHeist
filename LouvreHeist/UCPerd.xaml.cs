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

namespace LouvreHeist
{
    /// <summary>
    /// Logique d'interaction pour UCPerd.xaml
    /// </summary>
    public partial class UCPerd : UserControl
    {
        private MainWindow _mainWindow;
        public UCPerd(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void butRejouer_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCTenue();
        }
    }
}
