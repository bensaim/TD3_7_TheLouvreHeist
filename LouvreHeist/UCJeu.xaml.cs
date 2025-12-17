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
            _tempsRestant--; // Décrémente le temps restant de 1 seconde 

            if (_tempsRestant > 0)
            {
                timer.Content = _tempsRestant.ToString(); // Met à jour l'affichage du temps restant
            }
            else
            {
                minuterie.Stop(); //quand on a réussi on stop la minuterie et le timer du jeu
                _timer.Stop();
                timer.Content = "FELICITATION TU T'ES ECHAPPER!!!!";
                timer.Visibility = Visibility.Hidden; // On cache le timer
                labFelicitation.Visibility = Visibility.Visible; // On affiche le message de félicitation
                butFin.Visibility = Visibility.Visible; //On affiche le bouton rejouer
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
                double top = Canvas.GetTop(imgJustinJeu); // Position verticale actuelle de Justin

                // Monter
                if (top > solY - hauteurSaut && compteurEnAir == 0) // Tant qu'on n'a pas atteint la hauteur maximale du saut
                {
                    Canvas.SetTop(imgJustinJeu, top - vitesseVerticale); // Déplacer Justin vers le haut
                }
                // Pause en l’air
                else if (compteurEnAir < tempsEnAir) //on incrémente le compteur jusqu'à amorcer la descente en atteignant tempsEnAir
                {
                    compteurEnAir++;
                }
                // Descendre
                else if (top < solY) // Tant qu'on n'est pas encore au sol
                {
                    Canvas.SetTop(imgJustinJeu, top + vitesseVerticale); // Déplacer Justin vers le bas
                }
                // Fin du saut
                else
                {
                    Canvas.SetTop(imgJustinJeu, solY); // S'assurer que Justin est bien au sol 
                    enSaut = false;
                    compteurEnAir = 0;
                }
            }



            // Collision
            bool justinAuSol = Canvas.GetTop(imgJustinJeu) >= solY - 1; // Vérifie si Justin est au sol

            if (justinAuSol) // La collision n'est vérifiée que si Justin est au sol
            {
                Rect rectJustin = new Rect( 
                    Canvas.GetLeft(imgJustinJeu),
                    Canvas.GetTop(imgJustinJeu),
                    imgJustinJeu.Width,
                    imgJustinJeu.Height); // Rectangle englobant Justin

                Rect rectPolicier = new Rect(
                    Canvas.GetLeft(imgPolicier),
                    Canvas.GetTop(imgPolicier),
                    imgPolicier.Width,
                    imgPolicier.Height); // Rectangle englobant le policier

                if (rectJustin.IntersectsWith(rectPolicier)) //si y'a collision entre les deux rectangles c'est perdu
                {
                    minuterie.Stop();
                    _timer.Stop();
                    MessageBox.Show("Attrapé par le policier !");
                    _mainWindow.AfficheUCJeu(); //on revient au début du jeu avec timer et minuterie réinitialisés
                }
            }

        }

        public void Deplace(Image image, int pas) //deplacer le decor
        {
            Canvas.SetLeft(image, Canvas.GetLeft(image) - pas);
            if (Canvas.GetLeft(image) + image.ActualWidth <= 0)
                Canvas.SetLeft(image, canvasJeu.ActualWidth);
        }

        

        private void CanvasJeu_SizeChanged(object sender, SizeChangedEventArgs e) //redimensionner les éléments du jeu en fonction de la taille de la fenêtre
        {
            
            double largeur = canvasJeu.ActualWidth; //largeur de la fenêtre
            double hauteur = canvasJeu.ActualHeight; //hauteur de la fenêtre
            double hauteurSol = 109;
            double hauteurFond = hauteur - hauteurSol;
            solY = hauteurFond - hauteurSol; //position Y du sol pour le déplacement des persos (on enlève la hauteur du fond qui fait tout la fenêtre moins la hauteur du sol)
            Canvas.SetTop(imgJustinJeu, solY); //on repositionne Justin au sol lors du redimensionnement


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
            Canvas.SetLeft(imgJustinJeu, largeur*0.1); //redimensionnement (jusitn carré de base 200x200)
            solY = hauteurFond - hauteurSol;
            Canvas.SetTop(imgJustinJeu, solY);

            // Policier
            imgPolicier.Width = 200;
            imgPolicier.Height = 200;
            Canvas.SetLeft(imgPolicier, largeur *0.6); //redimensionnement (policier rectangle fin de base)
            Canvas.SetTop(imgPolicier, hauteurFond - hauteurSol);
        }

        private void canvasJeu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!enSaut) // Si Justin n'est pas déjà en train de sauter
            {
                enSaut = true;
            }
        }

        private void butFin_Click(object sender, RoutedEventArgs e) //affiche cinematique de fin
        {
            _mainWindow.AfficheUCGagner();
        }
    }
}
