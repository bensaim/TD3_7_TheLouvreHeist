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
    /// <summary>
    /// Logique d'interaction pour UCQuestion.xaml
    /// </summary>
    public partial class UCQuestion : UserControl
    {
        private MainWindow _mainWindow;
        public UCQuestion(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            labQuestion.Content = MainWindow.QUESTIONS[MainWindow.indiceQuestions];


            Button[] boutons = { butRep1, butRep2, butRep3, butRep4 };

            for (int i = 0; i < boutons.Length; i++)
            {
                boutons[i].Content = MainWindow.REPONSES[MainWindow.indiceQuestions, MainWindow.indiceReponses];
                MainWindow.indiceReponses++;
            }

            MainWindow.indiceReponses = 0;
            MainWindow.indiceQuestions++;

        }

        private void butRep1_Click(object sender, RoutedEventArgs e)
        {
            if (1 == MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0])
                if (MainWindow.indiceQuestions == 3)
                {
                    MainWindow.Cinematique = 2;
                    _mainWindow.AfficheUCCinematique();
                }
                else if (MainWindow.indiceQuestions == 6)
                {
                    MainWindow.Cinematique = 3;
                    _mainWindow.AfficheUCCinematique();
                }
                else
                    _mainWindow.AfficheUCDialogue();
            else
                _mainWindow.AfficheUCPerd();
        }

        private void butRep_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button)
                return;

            int reponseChoisie = int.Parse(button.Tag.ToString());
            TraiterReponse(reponseChoisie);
        }

        private void TraiterReponse(int reponseChoisie)
        {
            int bonneRep = MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0];

            if (reponseChoisie != bonneRep)
            {
                _mainWindow.AfficheUCPerd();
                return;
            }

            switch (MainWindow.indiceQuestions)
            {
                case 3:
                    MainWindow.Cinematique = 2;
                    _mainWindow.AfficheUCCinematique();
                    break;

                case 6:
                    MainWindow.Cinematique = 3;
                    _mainWindow.AfficheUCCinematique();
                    break;

                default:
                    _mainWindow.AfficheUCDialogue();
                    break;
            }
        }

    
    }
}
