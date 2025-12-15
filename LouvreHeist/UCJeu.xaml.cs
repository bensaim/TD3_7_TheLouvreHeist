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
using System.Windows.Threading;

namespace LouvreHeist
{
    /// <summary>
    /// Logique d'interaction pour UCJeu.xaml
    /// </summary>
    public partial class UCJeu : UserControl
    {
        private static int pasSol = 8;
        private static int pasFond = 2;
        public static int vitesse = 2;
        private DispatcherTimer minuterie;

        public UCJeu()
        {
            InitializeComponent();
            InitializeTimer();
            string nomFichierImage = $"pack://application:,,,/images/JustinJeu{MainWindow.Perso}.png";
            imgJustinJeu.Source = new BitmapImage(new Uri(nomFichierImage));
        }
        private void InitializeTimer()
        {
            minuterie = new DispatcherTimer();
            // configure l'intervalle du Timer :62 images par s
            minuterie.Interval = TimeSpan.FromMilliseconds(16);
            // associe l’appel de la méthode Jeu à la fin de la minuterie
            minuterie.Tick += Jeu;
            // lancement du timer
            minuterie.Start();
        }
        private void Jeu(object? sender, EventArgs e)
        {
            Deplace(imgFond1, pasFond);
            Deplace(imgFond2, pasFond);
            Deplace(imgSol1, pasSol);
            Deplace(imgSol2, pasSol);
            Deplace(imgPolicier, pasSol);

            if (saut)
                Canvas.SetBottom(imgJustinJeu, Canvas.GetBottom(imgJustinJeu) + 50);
        }


        public void Deplace(Image image, int pas)
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - pas);

            if (Canvas.GetLeft(image) + image.ActualWidth <= 0)
                Canvas.SetLeft(image, canvasJeu.ActualWidth);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            minuterie.Stop();
            ParametresWindow parametreWindow = new ParametresWindow();
            bool? rep = parametreWindow.ShowDialog();
            if (rep == true)
            {
                minuterie.Start();
                vitesse = (int)parametreWindow.slidVitesse.Value;

                // ATTENTION : LES PAS DOIVENT ETRE DES MULTIPLES
                // DE LA TAILLE DE L’IMAGE A DEPLACER
                if (vitesse == 2)
                {
                    pasSol = 8;
                    pasFond = 2;
                }
                else if (vitesse == 1)
                {
                    pasSol = 4;
                    pasFond = 1;
                }
                if (vitesse == 3)
                {
                    pasSol = 16;
                    pasFond = 4;
                }
            }
        }
        private static bool saut;

        private void imgJustinJeu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            saut=true;
        }

        private void imgJustinJeu_MouseUp(object sender, MouseButtonEventArgs e)
        {
            saut=false;
        }
    }
}
