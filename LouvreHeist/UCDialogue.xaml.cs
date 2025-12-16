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
    /// Logique d'interaction pour UCDialogue.xaml
    /// </summary>
    public partial class UCDialogue : UserControl
    {
        private MainWindow _mainWindow;
        int indiceD = MainWindow.indiceDialogue;
        public UCDialogue(MainWindow mainWindow)
        {
 
            InitializeComponent();
            string nomFichierImage = $"pack://application:,,,/images/JustinDialogue{MainWindow.Perso}.png";
            imgJustinDialogue.Source = new BitmapImage(new Uri(nomFichierImage));
            labDialoguePresentation.Content = MainWindow.DIALOGUE[MainWindow.indiceDialogue ];
            _mainWindow = mainWindow;
            butSuite.Content = MainWindow.BOUTONS[MainWindow.indiceBoutons];
            MainWindow.indiceBoutons++;
            butSuite.Visibility = Visibility.Hidden;
            MainWindow.indiceDialogue = MainWindow.indiceDialogue + 2;
            switch (MainWindow.indiceDialogue)
            {
                case 9:
                    labNom.Content="???";
                    break;

                case 8:
                    labNom.Content = "Medecin Oeuf-Homme";
                    break;

                default:
                    labNom.Content = "Justin";
                    break;
            }
        }




        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            butSuite.Visibility = Visibility.Visible;
            labDialoguePresentation.Content = MainWindow.DIALOGUE[indiceD + 1 ];
        }

        private void butSuite_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.indiceBoutons == MainWindow.BOUTONS.Length)
            {
                MainWindow.Cinematique = 4;
                _mainWindow.AfficheUCCinematique();
            }
            else
                _mainWindow.AfficheUCQuestion();

        }
        
    }
}
