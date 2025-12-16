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
        public static string[] DIALOGUE = ["Choisis la tenue pour ton équipe afin de passer incognito !", "Salut ! Moi c'est Justin. Je serai ton acolyte durant ce casse !", "Je peux désactiver les caméras avec ma tablette. Tu as bien le mot de passe ?", "Super les caméras sont désactivées, on peut y aller !", "Regarde une énigme cachée sous le monte-charge, on doit la résoudre !", "Maintenant, on doit casser la fenêtre, prends la disqueuse.", "Oh mince, tu t'es trompé tu as pris un lecteur de disque ! C'est quoi cette chanson...", "MOUHAHAHA !! Le diamant est à moi !", "Rendez les bijoux de la couronne !", "MOUAHAHAH c'est bien moi !!", "On passe aux choses sérieuses, maintenant...", "C'est la chance du débutant...", "Voyons-voir si vous arrivez à suivre", "Trop bien on a enfin battu Oeuf-Homme !", "Oh non, la police arrive on doit s'échapper !"];
        public static string[] QUESTIONS = ["Tu as bien le code des caméras, pas vrai ?", "Premier est le titre du conjoint de la femme après un mariage, Mon deuxième est le mal aimé, mon troisième est la moitié de l'isere : Mon tout va perdre son diamant aujourd'hui !", "Finis les paroles ! 'Shine bright like a...'", "Sais-tu à qui tu as affaire ?", "Quel objet tombe sur Newton dans la légende?", "Combien de diamants y avait-il sur l'écran d'accueil ?"];
        public static string[,] REPONSES = { { "Sortie", "Louvre", "chmod u+x camera.camera", "Chaton999" }, { "Marie-Amelie", "Marie-Antoinette", "Marie-Louise", "Benoit" }, { "Vampire", "Fairy", "Cookie", "Diamond" }, { "Gonandarf", "Médecin Oeuf-Homme", "Light Vador", "Thonas" }, { "Pomme", "Monte-Charge", "Titanic", "Caillou" }, { "1", "2", "3", "4" } };
        public static string[] BOUTONS = ["Je l'ai.", "Hum...", "Shine bright like a...", "Boss Fight", "En garde crâne d'oeuf !", "YAAAAAAAAAAAA", "S'échapper"];
        public static int[,] BONNEREP = { { 2 }, { 3 }, { 4 }, { 2 }, { 1 }, { 2 } };



        public static int indiceDialogue = 0;
        public static int indiceBoutons = 0;
        public static int indiceQuestions = 0;
        public static int indiceReponses = 0;
        public static int Cinematique = 1;
        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            UCDemarrage uc = new UCDemarrage(this);
            ZoneJeu.Content = uc;


        }
        public static string Perso { get; set; }
        public void AfficheUCTenue()
          {
              UCTenue uc = new UCTenue(this);
              ZoneJeu.Content = uc;
          }

          public void AfficheUCCinematique()
          {
              UCCinematique uc = new UCCinematique(this);
              ZoneJeu.Content = uc;

          }
         public void AfficheUCDialogue()
         {
             UCDialogue uc = new UCDialogue(this);
             ZoneJeu.Content = uc;
         }

         public void AfficheUCQuestion()
         {
             UCQuestion uc = new UCQuestion(this);
             ZoneJeu.Content = uc;
         }
         public void AfficheUCJeu()
         {
             UCJeu uc = new UCJeu(this);
             ZoneJeu.Content = uc;
         }

        public void AfficheUCPerd()
        {
            UCPerd uc = new UCPerd(this);
            ZoneJeu.Content = uc;
        }
        public void AfficheUCGagner()
        {
            UCGagner uc = new UCGagner();
            ZoneJeu.Content = uc;
        }

    }
}