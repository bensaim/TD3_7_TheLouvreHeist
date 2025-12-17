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
using static System.Net.Mime.MediaTypeNames;

namespace LouvreHeist
{
    /// <summary>
    /// Logique d'interaction pour UCDialogue.xaml
    /// </summary>
    public partial class UCDialogue : UserControl
    {
        private MainWindow _mainWindow;
        private string mechant;
        private string nomFichierImage;
        int indiceD = MainWindow.indiceDialogue;
        public UCDialogue(MainWindow mainWindow)
        {
            
            InitializeComponent();
            nomFichierImage = $"pack://application:,,,/images/JustinDialogue{MainWindow.Perso}.png";
            imgJustinDialogue.Source = new BitmapImage(new Uri(nomFichierImage));
            mechant = $"pack://application:,,,/images/oeufHomme{MainWindow.indiceOeuf}.png";
            string fond = $"pack://application:,,,/images/fond{MainWindow.indiceFond}.png";
            switch (MainWindow.indiceDialogue)
            {
                case 1:
                    labNom.Content = "Justin";
                    MainWindow.indiceFond++;
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
                case 3:
                    labNom.Content = "Justin";
                    MainWindow.indiceFond++;
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
                case 5:
                    labNom.Content = "Justin";
                    MainWindow.indiceFond++;
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
                case 7:
                    labNom.Content = "???";
                    imgJustinDialogue.Source = new BitmapImage(new Uri(mechant));
                    MainWindow.indiceOeuf++;
                    
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
                case 9:
                    labNom.Content = "Medecin Oeuf-Homme";
                    imgJustinDialogue.Source = new BitmapImage(new Uri(mechant));
                    MainWindow.indiceOeuf++;
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
                case 11:
                    labNom.Content = "Medecin Oeuf-Homme";
                    imgJustinDialogue.Source = new BitmapImage(new Uri(mechant));
                    MainWindow.indiceOeuf++;
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
                case 13:
                    labNom.Content = "Justin";
                    imgJustinDialogue.Source = new BitmapImage(new Uri(mechant));
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    MainWindow.indiceOeuf++;
                    break;
                default:
                    labNom.Content = "Justin";
                    imgJustinDialogue.Source = new BitmapImage(new Uri(nomFichierImage));
                    imgFond.Source = new BitmapImage(new Uri(fond));
                    break;
            }
            labDialoguePresentation.Content = MainWindow.DIALOGUE[MainWindow.indiceDialogue ];
            _mainWindow = mainWindow;
            butSuite.Content = MainWindow.BOUTONS[MainWindow.indiceBoutons];
            MainWindow.indiceBoutons++;
            butSuite.Visibility = Visibility.Hidden;
            MainWindow.indiceDialogue = MainWindow.indiceDialogue + 2;


        }




        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            butSuite.Visibility = Visibility.Visible;
            labDialoguePresentation.Content = MainWindow.DIALOGUE[indiceD + 1 ];
            if (indiceD + 1 == 10 || indiceD + 1 == 12)
            {
                labNom.Content = "Medecin Oeuf-Homme";
                imgJustinDialogue.Source = new BitmapImage(new Uri(mechant));

            }
            else if (indiceD + 1 == 8 || indiceD + 1 == 14)
            {
                labNom.Content = "Justin";
                imgJustinDialogue.Source = new BitmapImage(new Uri(nomFichierImage));

            }
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
