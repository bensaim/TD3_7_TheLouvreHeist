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
    public partial class UCQuestion : UserControl
    {
        private MainWindow _mainWindow;
        public UCQuestion(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            labQuestion.Content = MainWindow.QUESTIONS[MainWindow.indiceQuestions]; //Affiche la question du tableau en fonction du moment dans le jeu.


            Button[] boutons = { butRep1, butRep2, butRep3, butRep4 }; //Tableaux de nos 4 boutons, afin d'optimiser l'affichage des réponses.

            for (int i = 0; i < boutons.Length; i++)
            {
                boutons[i].Content = MainWindow.REPONSES[MainWindow.indiceQuestions, MainWindow.indiceReponses]; //Modifie chaque boutons par la réponse (indiceReponses entre 0 et 3 car 4 choix de réponses.)
                MainWindow.indiceReponses++; 
            }

            MainWindow.indiceReponses = 0;
            MainWindow.indiceQuestions++; //Passe les indice à la question d'après, donc réinitialise le compte des réponses.

        }



        private void butRep_Click(object sender, RoutedEventArgs e) //Tout les boutons renvoient à la même méthode click.
        {
            if (sender is not Button button)
                return;

            int reponseChoisie = int.Parse(button.Tag.ToString()); //l'id du bouton est stocké dans une variable.
            TraiterReponse(reponseChoisie); //compare la réponse avec la bonne réponse stockée dans BONNEREP.
        }

        private void TraiterReponse(int reponseChoisie)
        {
            int bonneRep = MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0]; //variable de la bonne réponse instanciée.

            if (reponseChoisie != bonneRep) //Si choisi la mauvaise réponse, perdu !
            {
                _mainWindow.AfficheUCPerd();
                return;
            }

            switch (MainWindow.indiceQuestions)
            {
                case 3:
                    MainWindow.Cinematique = 2; //Si nous sommes au troisième dialogue, renvoie à la deuxième cinématique.
                    _mainWindow.AfficheUCCinematique(); 
                    break;

                case 6:
                    MainWindow.Cinematique = 3; //Si nous sommes au sixième dialogue, renvoie à la troisième cinématique.
                    _mainWindow.AfficheUCCinematique();
                    break;

                default:
                    _mainWindow.AfficheUCDialogue(); //Continue si il n'y a aucune cinématique contextuelle à afficher.
                    break;
            }
        }

    
    }
}
