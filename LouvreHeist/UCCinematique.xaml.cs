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
    /// Logique d'interaction pour UCCinematique.xaml
    /// </summary>
    public partial class UCCinematique : UserControl
    {
        private MainWindow _mainWindow;
        public UCCinematique(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            string nomFichierImage = $"pack://application:,,,/images/cine{MainWindow.Cinematique}.png";
            cine.ImageSource = new BitmapImage(new Uri(nomFichierImage));
        }

        private void UCCine_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.Cinematique != 4)
                _mainWindow.AfficheUCDialogue();
            else
                _mainWindow.AfficheUCJeu();

        }
    }
}
