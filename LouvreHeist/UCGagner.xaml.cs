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
    /// Logique d'interaction pour UCGagner.xaml
    /// </summary>
    public partial class UCGagner : UserControl
    {
        private MainWindow _mainWindow;
        public UCGagner(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void butQuitter_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void butRejouer_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.indiceDialogue = 0;
            MainWindow.indiceBoutons = 0;
            MainWindow.indiceQuestions = 0;
            MainWindow.indiceReponses = 0;
            MainWindow.Cinematique = 1;
            MainWindow.indiceOeuf = 1;
            MainWindow.indiceFond = 1;
        _mainWindow.AfficheUCTenue();
        }
    }
}
