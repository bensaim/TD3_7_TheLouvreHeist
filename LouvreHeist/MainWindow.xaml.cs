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
        public static string[] DIALOGUE = ["Choisis la tenue pour ton équipe afin de passer incognito !","Salut ! Moi c'est Justin. Je serai ton acolyte durant ce casse !", "Je peux désactiver les caméras avec ma tablette. Tu as bien le mot de passe ?", "Super les caméras sont désactivées, on peut y aller !", "Regarde une énigme cachée sous le monte-charge, on doit la résoudre !", "Maintenant, on doit casser la fenêtre, prends la disqueuse.", "Oh mince, tu t'es trompé tu as pris un lecteur de disque ! C'est quoi cette chanson...", "MOUHAHAHA !! Le diamant est à moi !" , "Rendez les bijoux de la couronne !", "Trop bien on a enfin battu Oeuf-Homme !", "Oh non, la police arrive on doit s'échapper !"];
        public static string[] QUESTIONS = ["Tu as bien le code des caméras, pas vrai ?", "blablabla", "Finis les paroles ! 'Shine bright like a...'", "Sais-tu à qui tu as affaire ?", "Quel objet tombe sur Newton dans la légende?", "Combien de diamants y avait-il sur l'écran d'accueil ?"];
        public static string[,] REPONSES = { { "Sortie", "Louvre", "chmod u+x camera.camera", "Chaton999" }, { "", "", "", "" }, { "Vampire", "Fairy", "Cookie", "Diamond" }, { "Gonandarf", "Médecin Oeuf-Homme", "Light Vador", "Thonas" }, { "Pomme", "Monte-Charge", "Titanic", "Caillou" }, { "1", "2", "3", "4" } };
        public static string[] BOUTONS = ["Je l'ai.", "Hum...", "Shine bright like a...", "Boss Fight"];

        public static int indiceDialogue = 0;
        public static int indiceBoutons = 0;
        public static int indiceQuestions = 0;
        public static int indiceReponses = 0;

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
        public void AfficheUCJeu()
        {
            UCJeu uc = new UCJeu();
            ZoneJeu.Content = uc;
        }

    }
}