using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UCDemarrage uc = new UCDemarrage();
            ZoneJeu.Content = uc;
            uc.butStart.Click += AfficherTenue;
        }


        private void AfficherTenue(object sender, RoutedEventArgs e)
         {
             UCTenue uc = new UCTenue();
             ZoneJeu.Content = uc;
             uc.butValiderTenue.Click += AfficherDate;
         }

         private void AfficherDate(object sender, RoutedEventArgs e)
         {
             UCDate uc = new UCDate(this);
             ZoneJeu.Content = uc;

         }
        public void AfficheUCDebutRue()
        {
            UCDebutRue uc = new UCDebutRue(this);
            ZoneJeu.Content = uc;
        }

        public void AfficheUCQuestion()
        {
            UCQuestion uc = new UCQuestion();
            ZoneJeu.Content = uc;
        }

        public void AfficheUCEnigme()
        {
            UCEnigme uc = new UCEnigme();
            ZoneJeu.Content = uc;
        }

        public void AfficheUCFenetre()
        {
            UCFenetre uc = new UCFenetre();
            ZoneJeu.Content = uc;
        }
        public void AfficheUCBoss()
        {
            UCBoss uc = new UCBoss();
            ZoneJeu.Content = uc;
        }
        public void AfficheUCCinematiqueFin()
        {
            UCCinematiqueFin uc = new UCCinematiqueFin();
            ZoneJeu.Content = uc;
        }
        public void UCEchappe()
        {
            UCEchappe uc = new UCEchappe();
            ZoneJeu.Content = uc;
        }
    }
}