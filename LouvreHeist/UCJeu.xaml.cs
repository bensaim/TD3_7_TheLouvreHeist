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
        private MainWindow _mainWindow;
        private static int pasSol = 8;
        private static int pasFond = 2;
        public static int vitesse = 2;

        private DispatcherTimer minuterie;
        private DispatcherTimer _timer;
        int _tempsRestant = 8; //ref au vrai heist (8 minutes)

        // Saut non parabolique
        private bool enSaut = false;
        private double solY;
        private double hauteurSaut = 180;
        private double vitesseVerticale = 12;
        private int tempsEnAir = 25;
        private int compteurEnAir = 0;


        public UCJeu(MainWindow mainWindow )
        {
            InitializeComponent();
            InitializeTimer();
            _mainWindow = mainWindow;
            // Image du personnage
            string nomFichierImage = $"pack://application:,,,/images/JustinJeu{MainWindow.Perso}.png";
            imgJustinJeu.Source = new BitmapImage(new Uri(nomFichierImage));

            // Abonnement à SizeChanged (une seule fois)
            canvasJeu.SizeChanged += CanvasJeu_SizeChanged;

            
        }

        private void InitializeTimer()
        {
            minuterie = new DispatcherTimer();
            minuterie.Interval = TimeSpan.FromMilliseconds(10); // ~62 FPS
            minuterie.Tick += Jeu;
            minuterie.Start();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1); // Déclenchement toutes les secondes
            _timer.Tick += Timer_Tick;
            _timer.Start();

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _tempsRestant--;

            if (_tempsRestant > 0)
            {
                timer.Content = _tempsRestant.ToString();
            }
            else
            {
                minuterie.Stop();
                _timer.Stop();
                timer.Content = "FELICITATION TU T'ES ECHAPPER!!!!";
                timer.Visibility = Visibility.Hidden;
                labFeliz.Visibility = Visibility.Visible;
                butFin.Visibility = Visibility.Visible;
            }
        }

        private void Jeu(object? sender, EventArgs e)
        {
            // Déplacements
            Deplace(imgFond1, pasFond);
            Deplace(imgFond2, pasFond);
            Deplace(imgSol1, pasSol);
            Deplace(imgSol2, pasSol);
            Deplace(imgPolicier, pasSol);

            if (enSaut)
            {
                double top = Canvas.GetTop(imgJustinJeu);

                // Monter
                if (top > solY - hauteurSaut && compteurEnAir == 0)
                {
                    Canvas.SetTop(imgJustinJeu, top - vitesseVerticale);
                }
                // Pause en l’air
                else if (compteurEnAir < tempsEnAir)
                {
                    compteurEnAir++;
                }
                // Descendre
                else if (top < solY)
                {
                    Canvas.SetTop(imgJustinJeu, top + vitesseVerticale);
                }
                // Fin du saut
                else
                {
                    Canvas.SetTop(imgJustinJeu, solY);
                    enSaut = false;
                    compteurEnAir = 0;
                }
            }



            // Collision
            bool justinAuSol = Canvas.GetTop(imgJustinJeu) >= solY - 1;

            if (justinAuSol)
            {
                Rect rectJustin = new Rect(
                    Canvas.GetLeft(imgJustinJeu),
                    Canvas.GetTop(imgJustinJeu),
                    imgJustinJeu.Width,
                    imgJustinJeu.Height);

                Rect rectPolicier = new Rect(
                    Canvas.GetLeft(imgPolicier),
                    Canvas.GetTop(imgPolicier),
                    imgPolicier.Width,
                    imgPolicier.Height);

                if (rectJustin.IntersectsWith(rectPolicier))
                {
                    minuterie.Stop();
                    _timer.Stop();
                    MessageBox.Show("Attrapé par le policier !");
                    _mainWindow.AfficheUCJeu();
                }
            }

        }

        public void Deplace(Image image, int pas)
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - pas);
            if (Canvas.GetLeft(image) + image.ActualWidth <= 0)
                Canvas.SetLeft(image, canvasJeu.ActualWidth);
        }

        /*private void MenuItem_Click(object sender, RoutedEventArgs e)
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
        }*/

        private void CanvasJeu_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            double largeur = canvasJeu.ActualWidth;
            double hauteur = canvasJeu.ActualHeight;
            double hauteurSol = 109;
            double hauteurFond = hauteur - hauteurSol;
            solY = hauteurFond - hauteurSol;
            Canvas.SetTop(imgJustinJeu, solY);


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
            solY = hauteurFond - hauteurSol;
            Canvas.SetTop(imgJustinJeu, solY);

            // Policier
            imgPolicier.Width = 200;
            imgPolicier.Height = 200;
            Canvas.SetLeft(imgPolicier, largeur * 0.6);
            Canvas.SetTop(imgPolicier, hauteurFond - hauteurSol);
        }

        private void canvasJeu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!enSaut)
            {
                enSaut = true;
            }
        }

        private void butFin_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCGagner();
        }
    }
}
