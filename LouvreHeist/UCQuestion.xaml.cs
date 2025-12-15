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

            _mainWindow.AfficheUCDialogue();
        }

        private void butRep2_Click(object sender, RoutedEventArgs e)
        {
               _mainWindow.AfficheUCDialogue();
        }

        private void butRep3_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCDialogue();
        }

        private void butRep4_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AfficheUCDialogue();
        }
    }
}
