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
           

            butRep1.Content = MainWindow.REPONSES[MainWindow.indiceQuestions,MainWindow.indiceReponses];
            MainWindow.indiceReponses++;
            butRep2.Content = MainWindow.REPONSES[MainWindow.indiceQuestions,MainWindow.indiceReponses];
            MainWindow.indiceReponses++;
            butRep3.Content = MainWindow.REPONSES[MainWindow.indiceQuestions,MainWindow.indiceReponses];
            MainWindow.indiceReponses++;
            butRep4.Content = MainWindow.REPONSES[MainWindow.indiceQuestions,MainWindow.indiceReponses];
            MainWindow.indiceReponses = 0;
            MainWindow.indiceQuestions++;

        }

        private void butRep1_Click(object sender, RoutedEventArgs e)
        {
            if (1 == MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0])
                    if (MainWindow.indiceQuestions == 2)
                    {
                        MainWindow.Cinematique = 2;
                        _mainWindow.AfficheUCCinematique();
                    }
                    else if (MainWindow.indiceQuestions == 5)
                    {
                    MainWindow.Cinematique = 3;
                    _mainWindow.AfficheUCCinematique();
                    }
                    else
                    _mainWindow.AfficheUCDialogue();
            else
                _mainWindow.AfficheUCPerd();
        }

        private void butRep2_Click(object sender, RoutedEventArgs e)
        {
            if (2 == MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0])
                _mainWindow.AfficheUCDialogue();
            else
                _mainWindow.AfficheUCPerd();
        }

        private void butRep3_Click(object sender, RoutedEventArgs e)
        {
            if (3 == MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0])
                _mainWindow.AfficheUCDialogue();
            else
                _mainWindow.AfficheUCPerd();
        }

        private void butRep4_Click(object sender, RoutedEventArgs e)
        {
            if (4 == MainWindow.BONNEREP[MainWindow.indiceQuestions - 1, 0])
                _mainWindow.AfficheUCDialogue();
            else
                _mainWindow.AfficheUCPerd();
        }
    }
}
