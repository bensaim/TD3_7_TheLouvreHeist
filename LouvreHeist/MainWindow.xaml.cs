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
        public static string[] DIALOGUE = ["test1", "test2"];
        public static string[] QUESTIONS = ["Tu as bien le code des caméras, pas vrai ?", "blablabla", "Finis les paroles ! 'Shine bright like a...'", "Sais-tu à qui tu as affaire ?", "Quel objet tombe sur Newton dans la légende?", "Combien de diamants y avait-il sur l'écran d'accueil ?"];
        public static string[,] REPONSES = { { "Sortie", "Louvre", "chmod u+x camera.camera", "Chaton999" }, { "", "", "", "" }, { "Vampire", "Fairy", "Cookie", "Diamond" }, { "Gonandarf", "Médecin Oeuf-Homme", "Light Vador", "Thonas" }, { "Pomme", "Monte-Charge", "Titanic", "Caillou" }, { "1", "2", "3", "4" } };


        public static int indiceDebutUCRue = 0;
        public MainWindow()
        {
            InitializeComponent();
            UCDemarrage uc = new UCDemarrage();
            ZoneJeu.Content = uc;
            uc.butStart.Click += AfficherTenue;
        }
        public static string Perso { get; set; }

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
        public void AfficheUCDialogue()
        {
            UCDialogue uc = new UCDialogue(this);
            ZoneJeu.Content = uc;
        }

        public void AfficheUCQuestion()
        {
            UCQuestion uc = new UCQuestion();
            ZoneJeu.Content = uc;
        }

    }
}