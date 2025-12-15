using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LouvreHeist
{
    public partial class UCJeu : UserControl
    {
        private static int pasSol = 8;
        private static int pasFond = 2;
        public static int vitesse = 2;

        private DispatcherTimer minuterie;

        // Gestion du saut
        private double vitesseSaut = 0;
        private const double gravite = 3;
        private const double impulsion = -40;
        private double solY;

        public UCJeu(MainWindow mainWindow )
        {
            InitializeComponent();
            InitializeTimer();

            // Image du personnage
            //string nomFichierImage = $"pack://application:,,,/images/JustinJeu{MainWindow.Perso}.png";
            //imgJustinJeu.Source = new BitmapImage(new Uri(nomFichierImage));

            // Abonnement à SizeChanged (une seule fois)
            canvasJeu.SizeChanged += CanvasJeu_SizeChanged;
        }

        private void InitializeTimer()
        {
            minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(16); // ~62 FPS
            minuterie.Tick += Jeu;
            minuterie.Start();
        }

        private void Jeu(object? sender, EventArgs e)
        {
            // Déplacements
            Deplace(imgFond1, pasFond);
            Deplace(imgFond2, pasFond);
            Deplace(imgSol1, pasSol);
            Deplace(imgSol2, pasSol);
            Deplace(imgPolicier, pasSol);

            // Saut avec gravité
            double newTop = Canvas.GetTop(imgJustinJeu) + vitesseSaut;
            if (newTop < solY)
            {
                Canvas.SetTop(imgJustinJeu, newTop);
                vitesseSaut += gravite;
            }
            else
            {
                Canvas.SetTop(imgJustinJeu, solY);
                vitesseSaut = 0;
            }

            // Collision
            Rect rectJustin = new Rect(Canvas.GetLeft(imgJustinJeu)-20, Canvas.GetTop(imgJustinJeu)- 20,
                                       imgJustinJeu.Width- 20, imgJustinJeu.Height - 20);
            Rect rectPolicier = new Rect(Canvas.GetLeft(imgPolicier) - 20, Canvas.GetTop(imgPolicier) - 20,
                                         imgPolicier.Width - 20, imgPolicier.Height - 20);

            if (rectJustin.IntersectsWith(rectPolicier))
            {
                minuterie.Stop();
                MessageBox.Show("Attrapé par le policier !");
            }
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

                if (vitesse == 1) { pasSol = 4; pasFond = 1; }
                else if (vitesse == 2) { pasSol = 8; pasFond = 2; }
                else if (vitesse == 3) { pasSol = 16; pasFond = 4; }
            }
        }

        

        private void CanvasJeu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double largeur = canvasJeu.ActualWidth;
            double hauteur = canvasJeu.ActualHeight;
            double hauteurSol = 109;
            double hauteurFond = hauteur - hauteurSol;

            // Fond
            imgFond1.Width = largeur;
            imgFond1.Height = hauteurFond;
            Canvas.SetLeft(imgFond1, 0);
            Canvas.SetTop(imgFond1, 0);

            imgFond2.Width = largeur;
            imgFond2.Height = hauteurFond;
            Canvas.SetLeft(imgFond2, largeur);
            Canvas.SetTop(imgFond2, 0);

            // Sol
            imgSol1.Width = largeur;
            imgSol1.Height = hauteurSol;
            Canvas.SetLeft(imgSol1, 0);
            Canvas.SetTop(imgSol1, hauteurFond);

            imgSol2.Width = largeur;
            imgSol2.Height = hauteurSol;
            Canvas.SetLeft(imgSol2, largeur);
            Canvas.SetTop(imgSol2, hauteurFond);

            // Justin
            imgJustinJeu.Width = 200;
            imgJustinJeu.Height = 200;
            Canvas.SetLeft(imgJustinJeu, largeur * 0.1);
            solY = hauteurFond - imgJustinJeu.Height;
            Canvas.SetTop(imgJustinJeu, solY);

            // Policier
            imgPolicier.Width = 201;
            imgPolicier.Height = 298;
            Canvas.SetLeft(imgPolicier, largeur * 0.6);
            Canvas.SetTop(imgPolicier, hauteurFond - imgPolicier.Height);
        }

        private void canvasJeu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Canvas.GetTop(imgJustinJeu) >= solY)
            {
                vitesseSaut = impulsion; // impulsion vers le haut
            }
        }
    }
}
